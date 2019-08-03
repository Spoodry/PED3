using System;

namespace PED3
{
    class Program
    {
        static void Main(string[] args)
        {

            ILista lista = null; //Variable tipo ILista, para poder instancias ahí los tipos de listas
            int tipo = SIN_LISTA; //se guarda aquí el tipo de lista con la que se trabaja

            while(true) //ciclo "infinito"
            {
                Console.WriteLine("======================Listas======================"); //se imprime el menu
                Console.Write("\nTipo: " + ListaTipo(tipo)); //se imprime el tipo de lista con la funcion ListaTipo
                if(tipo != SIN_LISTA) //si el tipo no es SIN_LISTA
                    Console.Write((tipo == ESTATICA) ? "\tTamaño: " + lista.getSize() + "\tElementos: " + lista.getElementos() : 
                        "\tElementos: " + lista.getElementos()); //se imprimira el tamaño de la lista en el caso de la lista estatica y la cantidad de elementos actuales
                Console.WriteLine("\n\nOpciones");
                Console.WriteLine("1) Crear lista");
                Console.WriteLine("2) Insertar");
                Console.WriteLine("3) Remover");
                Console.WriteLine("4) Ordenar");
                Console.WriteLine("5) Mostrar");
                Console.WriteLine("6) Salir");
                Console.Write("\nOpcion: ");

                try
                {
                    int opcion = int.Parse(Console.ReadLine()); //se guarda desde el teclado la opcion escogida

                    switch(opcion) //se evalua en el switch opcion
                    {
                        case 1: //en caso de crear lista
                            Console.Clear();
                            Console.WriteLine("====================Crear lista====================");
                            Console.WriteLine("\nTipo de lista");
                            Console.WriteLine("1) Lista estatica");
                            Console.WriteLine("2) Lista enlazada simple");
                            Console.WriteLine("3) Lista doblemente enlazada");
                            Console.WriteLine("4) Lista circular");
                            Console.Write("\nOpción: ");
                            int tipoLista = int.Parse(Console.ReadLine()); //se guarda la opcion seleccionada

                            switch(tipoLista) //se evalua
                            {
                                case ESTATICA: //en caso de ser la estatica se intancia, y se pide el tamaño que tendrá
                                    Console.Write("\nIngresar tamaño de la lista: ");
                                    lista = new ListaEstatica(int.Parse(Console.ReadLine()));
                                    tipo = tipoLista;//se guarda el tipo de lista en la variable tipo
                                    Console.WriteLine("\nLista creada.");
                                    break;
                                case ENLAZADA_SIMPLE: //se repite el mismo proceso con las demas listas, sin pedir el tamaño claro
                                    lista = new ListaESimple();
                                    tipo = tipoLista;
                                    Console.WriteLine("\nLista creada.");
                                    break;
                                case DOBLEMENTE_ENLAZADA:
                                    lista = new ListaDobleE();
                                    tipo = tipoLista;
                                    Console.WriteLine("\nLista creada.");
                                    break;
                                case CIRCULAR:
                                    lista = new ListaCircula();
                                    tipo = tipoLista;
                                    Console.WriteLine("\nLista creada.");
                                    break;
                                default: //En caso de ingresar una opcion no valida se envia un mensaje de lista no creada
                                    Console.WriteLine("\nLista no creada, opción invalida.");
                                    break;
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2: //en caso de insertar
                            Console.Clear();
                            if (lista != null) //en caso de que la lista no sea nula
                            {
                                Console.WriteLine("=======================Insertar=======================");
                                Console.Write("\nTipo: " + ListaTipo(tipo)); //se imprime lo mismo del menu principal
                                if (tipo != SIN_LISTA)
                                    Console.Write((tipo == ESTATICA) ? "\tTamaño: " + lista.getSize() + "\tElementos: " + lista.getElementos() :
                                        "\tElementos: " + lista.getElementos());
                                Console.WriteLine("\n\nTipo de inserción");
                                Console.WriteLine("1) Por dato");
                                Console.WriteLine("2) Por posición");
                                Console.WriteLine("3) Atrás");
                                Console.Write("\nOpción: ");
                                int tipoInsercion = int.Parse(Console.ReadLine()); //se ingresa la opcion
                                switch (tipoInsercion) //se evalua la opcion escogida
                                {
                                    case DATO: //si es insercion por dato
                                        Console.WriteLine("\nInserción por dato==============================");
                                        Console.Write("\nDato: ");
                                        lista.InsertarDato(int.Parse(Console.ReadLine())); //se pide el dato y se llama a la funcion
                                        break;
                                    case POSICION://si es insercion por posicion
                                        Console.WriteLine("\nInserción por posición==============================");
                                        Console.WriteLine((tipo == ESTATICA) ? "\nNota: La posición empieza desde 0." : //se imprime un mensaje sobre el manejo de las posiciones
                                            "\nNota: La posición empieza desde 1");
                                        Console.Write("\nPosición: ");
                                        int p = int.Parse(Console.ReadLine());//se van pidiendo los datos de la posicion y el dato a pedir
                                        Console.Write("Dato: ");
                                        int d = int.Parse(Console.ReadLine());
                                        lista.InsertarPosicion(p, d);//se llama a la funcion insertar posicion
                                        break;
                                    case ATRAS://si escoge esta opcion no pasa nada, y sale al menu principal
                                        break;
                                    default: //en caso de que haya seleccionado una opcion invalida lo hará saber
                                        throw new Exception("Opción no valida");
                                }
                            }
                            else //en caso de que sea nula la lista
                            {
                                Console.WriteLine("No hay lista creada.");
                            }

                            Console.WriteLine("\nPresione cualquier tecla");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3: //en caso de eliminar
                            Console.Clear();
                            int datoEliminado; //dato eliminado

                            if (lista != null) //en caso de que la lista no sea null
                            {
                                Console.WriteLine("=======================Eliminar=======================");
                                Console.Write("\nTipo: " + ListaTipo(tipo)); //se imprime lo mismo que en el menu principal
                                if (tipo != SIN_LISTA)
                                    Console.Write((tipo == ESTATICA) ? "\tTamaño: " + lista.getSize() + "\tElementos: " + lista.getElementos() :
                                        "\tElementos: " + lista.getElementos());
                                Console.WriteLine("\n\nTipo de eliminación");
                                Console.WriteLine("1) Por dato");
                                Console.WriteLine("2) Por posición");
                                Console.WriteLine("3) Atrás");
                                Console.Write("\nOpción: ");
                                int tipoEliminacion = int.Parse(Console.ReadLine()); //se escoge una opcion y se guarda
                                switch (tipoEliminacion) //se evalua el tipo de eliminacion
                                {
                                    case DATO: //por dato
                                        Console.WriteLine("\nEliminación por dato==============================");
                                        Console.Write("\nDato: ");
                                        datoEliminado = lista.RemoverDato(int.Parse(Console.ReadLine())); //se guarda el dato eliminado y se llama a la funcion RemoverDato
                                        break;
                                    case POSICION: //por posicion
                                        Console.WriteLine("\nEliminación por posición==============================");
                                        Console.WriteLine((tipo == ESTATICA) ? "\nNota: La posición empieza desde 0." : //se imprime como se manejan las posiciones en la lista
                                            "\nNota: La posición empieza desde 1");
                                        Console.Write("\nPosición: ");
                                        datoEliminado = lista.RemoverPosicion(int.Parse(Console.ReadLine())); //se guarda el dato eliminado y se llama a la funcion RemoverPosicion
                                        if(datoEliminado != int.MaxValue) //si el dato eliminado no es igual a "vacio" se imprime, no es necesario esto en la eliminacion por dato ya que se sabe que dato se esta eliminando
                                            Console.WriteLine("\nDato eliminado = " + datoEliminado + ".");
                                        break;
                                    case ATRAS: //en caso de atras, pues no hace nada y se regresa a la funcion principal
                                        break;
                                    default:
                                        throw new Exception("Opción no valida"); //en caso de que no sea valida la opcion se les hace saber
                                }
                            }
                            else //en caso de que lista sea nula, pues se imprime un mensaje
                            {
                                Console.WriteLine("No hay lista creada.");
                            }

                            Console.WriteLine("\nPresione cualquier tecla");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4://en caso de ordenar
                            Console.Clear();

                            if(lista != null) //si la lista no es nula
                            {
                                Console.WriteLine("====================Ordenar====================");
                                Console.Write("\nTipo: " + ListaTipo(tipo)); //se imprimen los datos de la lista
                                if (tipo != SIN_LISTA)
                                    Console.Write((tipo == ESTATICA) ? "\tTamaño: " + lista.getSize() + "\tElementos: " + lista.getElementos() :
                                        "\tElementos: " + lista.getElementos());
                                Console.WriteLine();
                                lista.Ordenar(); //se llama al metodo ordenar
                            } else
                            {
                                Console.WriteLine("No hay lista creada."); //en caso de que sea nulo se imprime un mensaje
                            }

                            Console.WriteLine("\nPresione cualquier tecla");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5://en caso de mostrar
                            Console.Clear();

                            if (lista != null) //en caso de que no sea nulo
                            {
                                Console.WriteLine("========================Mostrar========================");
                                Console.Write("\nTipo: " + ListaTipo(tipo)); //se imprimen los datos de la lista
                                if (tipo != SIN_LISTA)
                                    Console.Write((tipo == ESTATICA) ? "\tTamaño: " + lista.getSize() + "\tElementos: " + lista.getElementos() :
                                        "\tElementos: " + lista.getElementos());
                                Console.WriteLine();
                                Console.WriteLine();
                                lista.Mostrar(); //se llama al metodo mostrar
                            } else //en caso de que sea nula
                            {
                                Console.WriteLine("No hay lista creada.");
                            }

                            Console.WriteLine("\n\nPresione cualquier tecla");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6: //en caso de salir
                            Console.Clear(); //se borra lo que hay en la consola
                            Console.WriteLine("Aplicacion terminada"); //se imprime un mensaje
                            Console.ReadKey(); //se espera un dato ingresado por teclado
                            Environment.Exit(0); //y se sale del programa
                            break;
                        default: //en caso de una opcion no valida
                            throw new Exception("Opción no valida"); //se lanza excepcion
                    }

                } catch(Exception e) //control de excepciones, se limpia consola y se imprime un mensaje
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }

            }

        }

        static String ListaTipo(int tipo) //metodo que devuelve el nombre del tipo de lista
        {
            switch(tipo)
            {
                case SIN_LISTA:
                    return "No hay lista";
                case ESTATICA:
                    return "Lista estatica";
                case ENLAZADA_SIMPLE:
                    return "Lista enlazada simple";
                case DOBLEMENTE_ENLAZADA:
                    return "Lista doblemente enlazada";
                case CIRCULAR:
                    return "Lista circular";
                default:
                    return "";
            }
        }

        const int ESTATICA = 1; //constantes para tener control de los tipos de listas y opciones
        const int ENLAZADA_SIMPLE = 2;
        const int DOBLEMENTE_ENLAZADA = 3;
        const int CIRCULAR = 4;
        const int SIN_LISTA = 5;

        const int DATO = 1;
        const int POSICION = 2;
        const int ATRAS = 3;

    }
}
