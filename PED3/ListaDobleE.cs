using System;
using System.Collections.Generic;
using System.Text;

namespace PED3
{
    class ListaDobleE : ILista  //Lista doblemente enlazada
    {   
        //El codigo se explica en la clase de la lista enlazada simple, 
        //por lo que solo comentaré las variaciones que tiene el codigo en esta lista
        //aplica solo para la lista doblemente enlazada y la lista circular

        public ListaDobleE() //constructor vacio
        {
            raiz = null; //se inicializan con nulo ambos nodos
            hoja = null;
        }

        public int getElementos() //metodo getter para retornar la cantidad de elementos en la lista
        {
            return elementos;
        }

        public int getSize() //No se utiliza, solo en la lista estatica
        {
            return int.MaxValue;
        }

        public void InsertarDato(int dato) //metodo para insertar por dato
        {
            Nodo nuevo = new Nodo(dato);
            if (raiz == null)
            {
                raiz = nuevo;
                hoja = nuevo;
            }
            else
            {
                nuevo.Anterior = hoja; //el nuevo nodo apunta a la hora en su referencia al anterior nodo
                hoja.Siguiente = nuevo; //la hoja a punta al nuevo nodo en siguiente
                hoja = nuevo; //la nuevo nodo se vuelve en la hoja
            }
            elementos++;
            Console.WriteLine("\nElemento insertado.");
        }

        public void InsertarPosicion(int n, int dato) //metodo para insertar por posicion
        {
            Nodo nuevo = new Nodo(dato);
            if (raiz == null && n == 1)
            {
                raiz = nuevo;
                hoja = nuevo;
                Console.WriteLine("\nElemento insertado.");
                elementos++;
            }
            else
            {
                if (n == 1) //insertar al principio
                {
                    nuevo.Siguiente = raiz; //el nuevo nodo a punta a la raiz en siguiente
                    raiz.Anterior = nuevo; //la raiz apunta al nuevo en el anterior
                    raiz = nuevo; //El nuevo nodo ahora es la raiz
                    Console.WriteLine("\nElemento insertado.");
                    elementos++; 
                }
                else
                {
                    if (n >= elementos)
                    {
                        if (n == elementos || n == elementos + 1) //insertar al ultimo
                        {
                            nuevo.Anterior = hoja; //el nuevo nodo apunta a la hoja en el anterior
                            hoja.Siguiente = nuevo; //la hoja apunta al nuevo nodo en siguiente
                            hoja = nuevo; //El nuevo se vuelve en la hoja
                            Console.WriteLine("\nElemento insertado.");
                            elementos++;
                        }
                        else
                        {
                            Console.WriteLine("\nLa posición esta fuera del rango de elementos existentes.");
                        }
                    }
                    else
                    {
                        Nodo actual; //En este caso no se utiliza un anterior, 
                        actual = raiz; //dado que los nodos pueden referencial al anterior tambien
                        int cont = 1;

                        while (actual != null)
                        {
                            if (cont == n) //si coincide la posicion actual con la que se quiere insertar
                            {
                                nuevo.Anterior = actual.Anterior; //el anterior al nodo nuevo apunta al nodo que esta en actual anterior
                                actual.Anterior.Siguiente = nuevo; //el nodo anterior al actual apunta ahora al nuevo nodo
                                nuevo.Siguiente = actual; //el siguiente nodo del nuevo apunta al actual
                                actual.Anterior = nuevo; //y el anterior nodo al actual apunta al nuevo
                                Console.WriteLine("\nElemento insertado.");
                                elementos++;//elementos incrementa en uno
                            }
                            actual = actual.Siguiente; //el nodo siguiente de actual ahora es el actual
                            cont++;
                        }

                    }
                }
            }
        }

        public void Mostrar() //metodo para mostrar la lista
        {
            Nodo Modo = raiz;

            if (Modo == null)
            {
                Console.WriteLine("\nNo hay elementos en la lista");
            }
            else
            {
                while (Modo != null)
                {
                    Console.Write(Modo.Dato + " ");
                    Modo = Modo.Siguiente;
                }
            }
        }

        public void Ordenar() //metodo para ordenar la lista
        {
            if (elementos > 1)
            {
                Nodo actual;
                Nodo siguiente;
                for (int i = 0; i < elementos; i++)
                {
                    actual = raiz;
                    siguiente = raiz.Siguiente;
                    for (int k = 0; k < elementos - 1; k++)
                    {
                        if (actual.Dato > siguiente.Dato)
                        {
                            int temp = actual.Dato;
                            actual.Dato = siguiente.Dato;
                            siguiente.Dato = temp;
                        }
                        actual = siguiente;
                        siguiente = siguiente.Siguiente;
                    }
                }
                Console.WriteLine("\nLista ordenada.");
            }
            else
            {
                if (elementos == 0)
                    Console.WriteLine("\nNo hay elementos en la lista");
                else
                    Console.WriteLine("\nLa lista ya esta ordenada");
            }
        }

        public int RemoverDato(int dato) //metodo para remover por dato
        {
            bool noEncontrado = true;
            int datoE = int.MaxValue;
            int cont = 1;
            Nodo actual;

            if (raiz != null)
            {
                actual = raiz;
                while (actual != null)
                {
                    if (dato == actual.Dato)
                    {
                        noEncontrado = false;
                        datoE = actual.Dato;
                        if (cont == 1) //remover al principio
                        {
                            raiz = raiz.Siguiente; //el nodo siguiente a la raiz, ahora es la raiz
                            raiz.Anterior = null; //el nodo anterior, se vuelve nula
                            actual = raiz;
                        }
                        else if (cont == elementos) //remover al final
                        {
                            hoja = hoja.Anterior; //el nodo anterior a la hoja ahora es la hoja
                            hoja.Siguiente = null; //el nodo siguiente se vuelve nula
                        }
                        else //remover en medio
                        {
                            actual.Anterior.Siguiente = actual.Siguiente; //el nodo anterior al actual ahora apunta al nodo siguiente del actual
                            actual.Siguiente.Anterior = actual.Anterior; // el nodo siguiente del actual apuntara al nodo anterior al actual en anterior
                        }
                        elementos--;
                        break;
                    }
                    actual = actual.Siguiente;
                    cont++;
                }
            }

            if (noEncontrado)
            {
                Console.WriteLine("\nElemento no encontrado en la lista");
            }

            return datoE;
        }

        public int RemoverPosicion(int n) //metodo para remover por posicion
        {
            int dato = int.MaxValue;
            if (raiz == null)
            {
                Console.WriteLine("\nNo se puede eliminar elementos.");
            }
            else if (n <= elementos)
            {
                int tipo = (n == 1) ? RAIZ : RAMA;
                Nodo actual;

                switch (tipo)
                {
                    case RAIZ: //remover desde el principio
                        dato = raiz.Dato; //se guarda el valor de la raiz, en la variable dato
                        raiz = raiz.Siguiente; //el nodo siguiente a la raiz ahora es la raiz
                        if (raiz != null) //se puede dar el caso de que el siguiente a la raiz haya sido nulo, por lo que
                            raiz.Anterior = null; //el nodo anterior a la raiz, tiene que ser nulo, dado que es el primer elemento de la lista
                        elementos--;
                        break;
                    case RAMA: //remover desde donde no sea el principio
                        actual = raiz;
                        int cont = 1;

                        while (actual != null)
                        {
                            if (cont == n)
                            {
                                dato = actual.Dato;
                                if (actual.Siguiente == null) //remover el ultimo
                                {
                                    hoja = hoja.Anterior; //el nodo anterior a hoja
                                    hoja.Siguiente = null; //el nodo siguiente a la hoja, se vuelve nulo
                                }
                                else //remover en medio
                                {
                                    actual.Anterior.Siguiente = actual.Siguiente; //el nodo siguiente al nodo anterior del actual apunta al nodo siguiente del actual
                                    actual.Siguiente.Anterior = actual.Anterior; //el nodo anterior del nodo siguiente del actual apunta al nodo anterior del actual
                                }
                                elementos--;
                            }
                            actual = actual.Siguiente;
                            cont++;
                        }
                        break;
                }

            }
            else
            {
                Console.WriteLine("\nPosición a eliminar fuera de la cantidad de elementos de la lista.");
            }
            return dato;
        }

        private Nodo raiz;
        private Nodo hoja;

        private int elementos;

        const int RAIZ = 1;
        const int RAMA = 2;

    }
}
