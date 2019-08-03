using System;
using System.Collections.Generic;
using System.Text;

namespace PED3
{
    class ListaESimple : ILista //Lista enlazada simple
    {

        public ListaESimple() //constructor parametrizado donde tanto la raiz y hoja se vuelven null
        {
            raiz = null;
            hoja = null;
        }

        public int getElementos() //retorna la cantidad de elementos en la lista
        {
            return elementos;
        }

        public int getSize() //No se ocupa
        {
            return int.MaxValue;
        }

        public void InsertarDato(int dato) //metodo para insertar elementos por datos
        {
            Nodo nuevo = new Nodo(dato); //Se crea un nuevo nodo y se le pasa el dato ha insertar
            if (raiz == null) //si no hay elementos en la lista, osea raiz nula
            {
                raiz = nuevo; //se guardan el nuevo nodo en la raiz y la hoja
                hoja = nuevo;
            }
            else //en caso de que si haya elementos o nodos en la lista
            {
                hoja.Siguiente = nuevo; //el nodo de hoja ahora apunta al nuevo nodo
                hoja = nuevo; //y el nuevo se guarda en la hoja
            }
            elementos++; //se incrementa la variable de elementos
            Console.WriteLine("\nElemento insertado.");
        }

        public void InsertarPosicion(int n, int dato) //metodo para insertar elementos por posicion
        {
            Nodo nuevo = new Nodo(dato); //Se crea un nuevo nodo, y se le pasa el dato ha insertar
            if (raiz == null && n == 1) //si no hay raiz o elementos, y se quiere insertar en la posicion 1
            {
                raiz = nuevo;//se guarda el nuevo nodo en la raiz y la hoja
                hoja = nuevo;
                Console.WriteLine("\nElemento insertado.");
                elementos++; //se incrementa la variable de elementos
            } else //De lo contrario
            {
                if (n == 1) //Si es la posicion primera de la lista
                {
                    nuevo.Siguiente = raiz; //el nuevo.siguiendo apuntara a raiz
                    raiz = nuevo;   //La raiz ahora es el nuevo nodo
                    Console.WriteLine("\nElemento insertado.");
                    elementos++; //se incrementa elementos
                }
                else //si la posicion no es la primera de la lista
                {
                    if (n >= elementos) //Si la posicion es mayor o igual a la cantidad de elementos que hay, osea el ultimo elemento o mayor
                    {
                        if (n == elementos || n == elementos + 1) //si la posicion es el ultimo elemento o elemento + 1
                        {
                            hoja.Siguiente = nuevo; //hoja.siguiente apuntará al nuevo nodo
                            hoja = nuevo; //ahora hoja será el nuevo nodo
                            Console.WriteLine("\nElemento insertado.");
                            elementos++; //se incrementa elementos
                        } else //en caso de que la posicion que se quiera ingresar sea mayor pues se manda mensaje
                        {
                            Console.WriteLine("\nLa posición esta fuera del rango de elementos existentes.");
                        }
                    }
                    else //en caso de que la posicion ha insertar no este al inicio o al final
                    {
                        Nodo anterior, actual; //se necesitaran dos nodos, uno que guarda el anterior, y el actual
                        anterior = null;
                        actual = raiz; //En actual se guarda la raiz
                        int cont = 1; //se inicializa el cont en 1

                        while(actual != null) //mientras actual no sea nulo
                        {
                            if(cont == n) //si el cont es igual a la posicion que se quiere insertar
                            {
                                anterior.Siguiente = nuevo; //el anterior.siguiente apuntará ahora al nuevo nodo
                                nuevo.Siguiente = actual; //el nuevo nodo.siguiente apuntará ahora al actual
                                Console.WriteLine("\nElemento insertado.");
                                elementos++; //se incrementa elementos
                            }
                            anterior = actual; //en cada ciclo en anterior se guarda el actual y en actual, actual.siguiente
                            actual = actual.Siguiente;
                            cont++; //se incrementa cont
                        }

                    }
                }
            }
        }

        public void Mostrar() //Metodo para mostrar la lista
        {
            Nodo Modo = raiz; //Se crea un nodo para recorrer la raiz

            if (Modo == null) //si modo es nulo, no hay elementos
            {
                Console.WriteLine("\nNo hay elementos en la lista");
            }
            else //de lo contrario
            {
                while (Modo != null) //mientras que modo no sea nulo
                {
                    Console.Write(Modo.Dato + " "); //se van imprimiendo los datos
                    Modo = Modo.Siguiente; //modo pasa a ser el modo.siguiente
                }
            }

        }

        public void Ordenar() //metodo para ordenar la lista
        {
            if (elementos > 1) //Si elementos es mayor a 1 elemento
            {
                Nodo actual; //se necesitaran dos nodos uno actual y otro el siguiente
                Nodo siguiente;
                for (int i = 0; i < elementos; i++) //se realiza el ordenamiento burbuja
                {
                    actual = raiz; //en cada ciclo se vuelve, el actual en raiz, y siguiente pues en raiz.siguiente
                    siguiente = raiz.Siguiente;
                    for (int k = 0; k < elementos - 1; k++)
                    {
                        if (actual.Dato > siguiente.Dato)
                        {
                            int temp = actual.Dato; //solo se intercambia el atributo que guarda el dato
                            actual.Dato = siguiente.Dato;
                            siguiente.Dato = temp;
                        }
                        actual = siguiente; //el actual pasa a ser el siguiente
                        siguiente = siguiente.Siguiente; //el siguiente, el siguiente.siguiente
                    }
                }
                Console.WriteLine("\nLista ordenada.");
            }
            else
            {
                if(elementos == 0) //si elementos es igual a 0
                    Console.WriteLine("\nNo hay elementos en la lista");
                else //en caso de que solo sea 1 elemento
                    Console.WriteLine("\nLa lista ya esta ordenada");
            }
        }

        public int RemoverDato(int dato) //metodo para remover un dato, buscandolo
        {
            bool noEncontrado = true; //Variable bool para saber si se encontro el elemento
            int datoE = int.MaxValue; //Donde se guardara el dato encontrado
            int cont = 1; //Contador que comienza en 1
            Nodo anterior, actual; //se necesitará un nodo anterior y actual
            
            if(raiz != null) //si raiz no es nulo, osea de que hay elementos
            {
                anterior = null; //anterior se vuelve nulo
                actual = raiz; //en actual se guarda la raiz
                while(actual != null) //Mientras que actual no sea nulo
                {
                    if(dato == actual.Dato) //si en el nodo actual es igual al dato a remover
                    {
                        noEncontrado = false; //no encontrado se vuelve falso
                        datoE = actual.Dato; //en dato encontrado se guarda el dato en el nodo actual
                        if (cont == 1) //si cont es igual a 1 lo que quiere decir que es el primer elemento de la lista
                        {
                            raiz = raiz.Siguiente; //raiz apuntara a raiz.siguiente
                            actual = raiz; //No es necesario esto
                        }
                        else if (cont == elementos) //si es el ultimo elemento
                        {
                            hoja = anterior; //hoja ahora apuntara al anterior
                            hoja.Siguiente = null; //el nodo que era anterior y que apuntaba a la hoja ahora será nulo
                        }
                        else //si esta en medio de la lista el elemento a eliminar
                            anterior.Siguiente = actual.Siguiente;  //el nodo anterior.siguiente ahora apuntara al actual.siguiente
                        elementos--; //se decrementa los elementos
                        break; //se rompe el ciclo
                    }
                    anterior = actual; //en cada ciclo, el anterior se vuelve el actual
                    actual = actual.Siguiente; //y el actual.siguiente en el actual
                    cont++; //cont incrementa 1
                }
            }

            if(noEncontrado) //si no se ha encontrado entonces se imprime un mensaje
            {   
                Console.WriteLine("\nElemento no encontrado en la lista");
            }

            return datoE; //se retorna el dato encontrado
        }

        public int RemoverPosicion(int n) //metodo para remover por posicion
        {
            int dato = 0; //variable para guardar el dato eliminado
            if (raiz == null) //si la raiz es nulo, osea de que no hay elementos
            {
                Console.WriteLine("\nNo se puede eliminar elementos.");
                dato = VACIO; //dato se guarda el valor que representa vacio
            }
            else if(n <= elementos) //en caso contrario, de que la posicion sea menor a los elementos que hay
            {
                int tipo = (n == 1) ? RAIZ : RAMA; //si n es 1, se tiene que remover el primer elemento
                Nodo anterior, actual; //se necesitará un nodo anterior y otro actual

                switch (tipo) //se evalua la variable tipo
                {
                    case RAIZ: //en caso de que se tenga que eliminar el primer elemento
                        dato = raiz.Dato; //se guarda el dato en la variable
                        raiz = raiz.Siguiente; //En raiz se guarda la raiz.siguiente
                        elementos--; //elemento decrementa
                        break;
                    case RAMA: //En este caso es por si se tiene que eliminar lo que no sea el primer elemento
                        anterior = null; //anterior se establece nulo
                        actual = raiz; //el actual toma toda la lista
                        int cont = 1; //variable contadora que inicia en 1, nos indica en que posicion de la lista vamos

                        while (actual != null) //Mientras que el actual es indistinto a nulo
                        {
                            if(cont == n) //si cont es igual a la posicion a eliminar
                            {
                                dato = actual.Dato; //en dato se guarda el valor del nodo
                                anterior.Siguiente = actual.Siguiente; //el nodo anterior.siguiente ahora apunta a actual.siguiente
                                elementos--; //decrementa elementos
                            }
                            anterior = actual; //en cada vuelta de ciclo el actual se vuelve el anterior 
                            actual = actual.Siguiente; //y el actual.siguiente en el actual
                            cont++; //cont incrementa
                        }
                        break; 
                }

            }
            else //en caso de que la posicion a eliminar se salga de los elementos que hay en la lista
            {
                Console.WriteLine("\nPosición a eliminar fuera de la cantidad de elementos de la lista.");
                dato = VACIO; //En dato se guarda el valor que representa vacio
            }
            return dato; //se retorna nulo
        }

        private Nodo raiz; //estos nodos guardaran la lista
        private Nodo hoja;

        private int elementos = 0; //Para mantener el conteo de los elementos que hay en la lista

        const int RAIZ = 1;
        const int RAMA = 2;
        const int HOJA = 3;
        const int VACIO = -1;

    }
}
