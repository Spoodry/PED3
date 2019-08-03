using System;
using System.Collections.Generic;
using System.Text;

namespace PED3
{
    class ListaCircula : ILista //Lista circular
    {
        //El codigo se explica en la clase de la lista enlazada simple, 
        //por lo que solo comentaré las variaciones que tiene el codigo en esta lista
        //aplica solo para la lista doblemente enlazada y la lista circular

        public ListaCircula() //constructor vacio
        {
            raiz = null;
            hoja = null;
            elementos = 0;
        }

        public int getElementos() //metodo getter para retornar elementos
        {
            return elementos;
        }

        public int getSize() //no se utiliza, solo en la estatica
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
            { //elemento insertado al ultimo
                hoja.Siguiente = nuevo;//el nodo siguiente a la hoja apunta al nuevo nodo
                hoja = nuevo; //el nuevo nodo ahora es la hoja
                hoja.Siguiente = raiz; //el nodo siguiente a hoja apunta a la raiz
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
                    nuevo.Siguiente = raiz; //el siguiente nodo del nuevo apunta a la raiz
                    hoja.Siguiente = nuevo; //el siguiente nodo de la hoja apunta al nuevo
                    raiz = nuevo; //el nuevo ahora es la raiz
                    Console.WriteLine("\nElemento insertado.");
                    elementos++;
                }
                else
                {
                    if (n >= elementos)
                    {
                        if (n == elementos || n == elementos + 1) //insertar al final
                        {
                            hoja.Siguiente = nuevo; //el siguiente nodo de la hoja apunta al nuevo
                            nuevo.Siguiente = raiz; //el siguiente nodo del nuevo apunta a la raiz
                            hoja = nuevo; //el nuevo nodo ahora es la hoja
                            Console.WriteLine("\nElemento insertado.");
                            elementos++;
                        }
                        else
                        {
                            Console.WriteLine("\nLa posición esta fuera del rango de elementos existentes.");
                        }
                    }
                    else //insertar en medio
                    {
                        Nodo anterior, actual; 
                        anterior = null;
                        actual = raiz;
                        int cont = 1;

                        while (actual != null && cont < elementos) 
                        {
                            if (cont == n) //en caso de que coincida el conteo de posicion con n
                            {
                                anterior.Siguiente = nuevo; //el siguiente nodo del anterior apunta al nuevo
                                nuevo.Siguiente = actual; //el siguiente nodo del nuevo al actual
                                Console.WriteLine("\nElemento insertado.");
                                elementos++;
                            }
                            anterior = actual;
                            actual = actual.Siguiente;
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
                int cont = elementos; //la diferencia esta en que hay que tener un contador que ira 
                while (Modo != null && cont > 0) //decrementando conforme se van imprimiendo hasta llegar a 0
                {                               //dado que es una lista circular sin esto el ciclo se vuelve infinito
                    Console.Write(Modo.Dato + " ");
                    Modo = Modo.Siguiente;
                    cont--;
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
            Nodo anterior, actual;

            if (raiz != null)
            {
                anterior = null;
                actual = raiz;
                while (actual != null && cont <= elementos)
                {
                    if (dato == actual.Dato)
                    {
                        noEncontrado = false;
                        datoE = actual.Dato;
                        if (cont == 1) //remover al principio
                        {
                            raiz = raiz.Siguiente; //el nodo siguiente de la raiz, ahora es la raiz
                            hoja.Siguiente = raiz; //el nodo siguiente de la hoja ahora apunta a la nueva raiz
                            actual = raiz; //no necesario
                        }
                        else if (cont == elementos) //remover al final
                        {
                            hoja = anterior; //el nodo anterior ahora es la hoja
                            hoja.Siguiente = raiz; //el nodo siguiente ahora tendrá que apuntar a la raiz
                        }
                        else
                            anterior.Siguiente = actual.Siguiente; //el nodo siguiente del anterior ahora apunta al nodo siguiente del actual
                        elementos--;
                        break;
                    }
                    anterior = actual;
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
                Nodo anterior, actual;

                switch (tipo)
                {
                    case RAIZ: //remover al principio
                        dato = raiz.Dato; //se guarda el valor del nodo en dato
                        raiz = raiz.Siguiente; //el nodo siguiente de la raiz, ahora es la raiz
                        hoja.Siguiente = raiz; //el nodo siguiente de la hoja ahora apunta a la raiz
                        elementos--;
                        break;
                    case RAMA: //remover, pero no al principio
                        anterior = null;
                        actual = raiz;
                        int cont = 1;

                        while (actual != null)
                        {
                            if (cont == n) 
                            {
                                dato = actual.Dato;
                                if(cont == elementos) //remover al final
                                {
                                    anterior.Siguiente = raiz; //el nodo siguiente del anterior ahora apunta a la raiz
                                }
                                else //remover en medio
                                    anterior.Siguiente = actual.Siguiente; //el nodo siguiente del anterior ahora apunta al nodo siguiente del actual
                                elementos--;
                                break;
                            }
                            anterior = actual;
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
