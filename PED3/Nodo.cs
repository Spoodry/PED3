using System;
using System.Collections.Generic;
using System.Text;

namespace PED3
{
    class Nodo
    {   //Clase para crear nodos, donde almacenaremos los elementos, y que referenciaran a otros nodos

        public Nodo(int dato)   //constructor parametrizado, recibe un entero y lo guarda en el dato
        {
            this.dato = dato;
        }

        private Nodo anterior; //referencia al nodo anterior   Nota: solo usado en la lista doble
        private Nodo siguiente;//referencia al siguiente nodo
        private int dato;

        public int Dato { get => dato; set => dato = value; }
        public Nodo Siguiente { get => siguiente; set => siguiente = value; }
        public Nodo Anterior { get => anterior; set => anterior = value; }

    }
}
