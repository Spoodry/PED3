using System;
using System.Collections.Generic;
using System.Text;

namespace PED3
{
    interface ILista
    {   //Interfaz donde se declaran todos los metodos que las listas tendran en comun
        //Mas que nada es para hacer menos pesado el programa principal, y evitar tener que hacer menus separados para cada lista
        void InsertarDato(int dato);

        void InsertarPosicion(int n, int dato);

        int RemoverDato(int dato);

        int RemoverPosicion(int n);

        void Mostrar();

        void Ordenar();

        int getElementos();

        int getSize();

  /*1) Lista estatica
    2) Lista enlazada simple
    3) Lista doblemente enlazada
    4) Lista circular

    - Ordenar
    - Insertar
    - Remover
    - Buscar
    - Mostrar

    Insertar
    {
	    1) Insertar al Inicio
	    2) Insertar al Final
	    3) Insertar en Medio
    }*/

    }
}
