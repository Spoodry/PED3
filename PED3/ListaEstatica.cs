using System;
using System.Collections.Generic;
using System.Text;

namespace PED3
{
    class ListaEstatica : ILista    //Lista estatica
    {

        public ListaEstatica(int n) //constructor parametrizado que recibe el tamaño de la lista
        {
            arreglo = new int[n];   //se crea el arreglo de tamaño n
            size = arreglo.Length;  //se guarda en size el tamaño del arreglo
            for (int i = 0; i < arreglo.Length; i++)    //se llena el arreglo con la constante VACIO
                arreglo[i] = VACIO;

        }

        public int getElementos()   //metodo get para retornar la cantidad de elementos de la lista
        {
            return elementos;
        }

        public int getSize()    //metodo get para retornar el tamaño de la lista
        {
            return size;
        }

        public void InsertarDato(int dato) //metodo para insertar un elemento dado un dato
        {
            if(elementos == arreglo.Length) //si la cantidad de elementos en la lista es igual al tamaño del arreglo, entonces...
            {
                Console.WriteLine("\nNo se puede insertar. Se ha alcanzado el limite.");
            }
            else //de lo contrario, quiere decir que hay espacios disponibles
            {
                arreglo[elementos] = dato;  //se guarda en esa posicion el dato
                Console.WriteLine("\nElemento insertado.");
                elementos++; //se incrementa la cantidad de elementos en uno
            }
        }

        public void InsertarPosicion(int n, int dato) //metodo para insertar un elemento dada la posicion y el dato
        {
            int tipo = (n == 0) ? INICIO : (n > 0 || n < elementos - 1) ? MEDIO : FINAL;
            //En esta variable guardara el tipo de insercion, si es al inicio, en medio o al final
            if (n <= elementos)//si la cantidad de elementos en la lista no es igual al tamaño del arreglo, entonces...
            {
                if (arreglo[n] == VACIO) //si la posicion en el arreglo esta vacia, pues se inserta el dato
                {
                    arreglo[n] = dato;
                    elementos++;
                    Console.WriteLine("\nElemento insertado.");
                }
                else //en caso de que no este vacia
                {
                    if (elementos == arreglo.Length) //si la lista esta llena, se manda un mensaje
                        Console.WriteLine("\nNo se puede insertar. Se ha alcanzado el limite.");
                    else //si no
                    {
                        HacerEspacio(tipo, n);//se manda a llamar un metodo que recorre los elementos de la lista, para hacer espacio
                        arreglo[n] = dato; //se inserta el dato
                        elementos++;
                        Console.WriteLine("\nElemento insertado.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nLa posición esta fuera de la cantidad de elementos.");
            }
            if(n >= arreglo.Length) //en caso de que se quiera añadir en una posicion fuera del tamaño del arreglo, se manda mensaje
                Console.WriteLine("\nLa posición esta fuera de los limites de la lista."); 

        }

        public void Mostrar()//metodo para mostrar la lista
        {
            if (elementos == 0) //en caso de que no hay elementos en la lista, se manda el mensaje
            {
                Console.WriteLine("\nNo hay elementos en la lista.");
            }
            else //de lo contrario
            {
                for (int i = 0; i < arreglo.Length; i++) // se van imprimiendo los datos
                {
                    if (arreglo[i] != int.MaxValue) //si la posicion no esta vacia
                        Console.Write(arreglo[i] + " ");
                }
            }
        }

        public void Ordenar() //metodo para ordenar la lista
        {
            if (elementos > 0) //si la lista es tiene elementos
            {
                for (int i = 0; i < arreglo.Length; i++) //se realiza el ordenamiento burbuja
                {
                    for (int k = 0; k < arreglo.Length - 1; k++)
                    {
                        if (arreglo[k] > arreglo[k + 1])
                        {
                            int temp = arreglo[k];
                            arreglo[k] = arreglo[k + 1];
                            arreglo[k + 1] = temp;
                        }
                    }
                }
                Console.WriteLine("\nLista ordenada");
            }
            else //en caso de que no tenga elementos, se imprime un mensaje
            {
                Console.WriteLine("\nLa lista no tiene elementos");
            }

        }

        public void comprimirLista(int posicion)
        {

            for(int i = posicion; i < arreglo.Length; i++)
            {
                if (i < arreglo.Length - 1)
                    arreglo[i] = arreglo[i + 1];
                if (i >= elementos - 1)
                    arreglo[i] = VACIO;
            }

        }

        public int RemoverDato(int dato) //metodo para remover dato, buscandolo
        {
            bool noRemovido = true; //variable bool para saber si se ha removido o no el dato
            for(int i = 0; i < arreglo.Length; i++) //se recorre el arreglo
            {
                if(arreglo[i] == dato) //si el dato en el arreglo es igual al dato entonces...
                {
                    int elemento = arreglo[i]; //se guarda el dato en la variable elemento
                    comprimirLista(i); //en el arreglo se guarda el valor que representa vacio
                    elementos--;    //se decrementan los elementos
                    noRemovido = false; //la variable de no removido se vuelve false
                    return elemento; //y se retorna el elemento encontrado
                }
            }

            if(noRemovido) //en caso de que el dato no se haya removido, se imprime un mensaje
            {   //Nota: esta condicional no es necesaria, si no se encuentra el valor no se retornara nada, y podra ejecutar el mensaje
                Console.WriteLine("\nNo se encontro el dato ha eliminar.");
            }

            return VACIO; //si no se encontro, retorna el valor que representa vacio
        }

        public int RemoverPosicion(int n) //metodo para remover un elemento por su posicion
        {
            if (arreglo[n] == VACIO)    //Si la posicion del arreglo esta vacia entonces...
            {
                Console.WriteLine("\nPosición vacia"); 
                return VACIO; //se retorna el valor que representa el vacio
            }
            else    //en caso de que haya un elemento
            {
                int dato = arreglo[n]; //se guarda el dato en la variable dato
                comprimirLista(n); //La posicion del arreglo se vuelve vacio
                elementos--; //se decrementa la variable elementos
                return dato; //se retorna el dato
            }
        }

        private void HacerEspacio(int tipo, int n) //metodo para recorrer elementos para hacer espacio
        {
            switch(tipo) //se evalua la variable tipo
            {
                case INICIO: //en caso de que se quiera recorrer desde el principio
                    for(int i = 1; i < arreglo.Length; i++) //se recorre el arreglo desde el segundo elemento
                    {
                        if(arreglo[i] == VACIO) //en caso de que la posicion este vacia
                        {
                            for(int j = i; j > 0; j--) //se recorre el arreglo para atras y se van recorriendo los datos
                            {
                                arreglo[j] = arreglo[j - 1];
                            }
                            arreglo[0] = VACIO; //El primer elemento se vuelve vacio
                            break; //se rompe el ciclo
                        }
                    }
                    break;
                case MEDIO: //en caso de que se quiera hacer espacio en medio del arreglo
                    Boolean hayEspacio = true;  //variable para saber si ya se encontro el espacio

                    for(int i = n; i < arreglo.Length; i++) //se recorre el arreglo desde n hasta el final del arreglo
                    {
                        if(arreglo[i] == VACIO) //si se encuentra un elemento vacio
                        {
                            for(int j = i; j > n; j--) //se recorre desde el elemento vacio para atras hasta n
                            {
                                arreglo[j] = arreglo[j - 1]; //se va recorriendo los elementos
                            }
                            arreglo[n] = VACIO; //la posicion n se vuelve vacio
                            hayEspacio = false; //la variable hayEspacio se vuelve falsa
                            break;  //se rompe el ciclo
                        }
                    }

                    if(hayEspacio) //en caso de que no se haya encontrado el espacio
                    {
                        for(int i = n - 1; i >= 0; i--) //se recorre desde n - 1 hasta el 0 decrementando
                        {
                            if(arreglo[i] == VACIO) //si se encuentra un elemento vacio
                            {
                                for(int j = i; j < n; j++) //se recorre desde  el elemento vacio hacia delante hasta n
                                {
                                    arreglo[j] = arreglo[j + 1]; //se va recorriendo los elementos
                                }
                                arreglo[n] = VACIO; //la posicion n se vuelve vacio
                                break; //se rompe el ciclo
                            }
                        }
                    }

                    break;
                case FINAL:
                    for(int i = arreglo.Length - 2; i >= 0; i--) //se recorre el arreglo desde el penultimo elemento hasta 0
                    {
                        if(arreglo[i] == VACIO) //si se encuentra un elemento vacio
                        {
                            for(int j = i; j < arreglo.Length - 1; j++) //se recorre el arreglo desde el elemento vacio hacia delante hasta n
                            {
                                arreglo[j] = arreglo[j + 1]; //se van recorriendo los elementos
                            }
                            arreglo[arreglo.Length - 1] = VACIO; //la posicion se vuelve vacio
                            break; //se rompe el ciclo
                        }
                    }
                    break;
            }
        }

        private int[] arreglo;  //Aquí se guardan los elementos de la lista
        private int size;   //Se almacena el tamaño de la lista
        private int elementos = 0;  //Aqui se guarda la cantidad de elementos que se han ingresado en la lista

        const int INICIO = 0;
        const int MEDIO = 1;
        const int FINAL = 2;
        const int VACIO = int.MaxValue; //dado que es un arreglo, me vi en la necesidad de 
                                        //identificar las posiciones del arreglo vacias, por lo que cree la constante VACIO


    }
}
