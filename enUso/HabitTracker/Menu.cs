/**
 * Menu.cs - Habit Tracker, Menú de la aplicación
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.01, 17/04/2019:
 *      Leer menú del fichero
 *      Dibujar el menú en la pantalla de menú
 *      Colorear opción seleccionada
 *      Cambiar entre opciones con UP y DOWN
 *      Seleccionar opcion con SPACE
 * 0.03, 13/05/2019:
 *      Heredar de la interfaz IMostrarPantalla
 * 0.04, 15/05/2019:
 *      Actualizar clase principal con la clase Tracker
 * 0.05 16/05/2019:
 *          Cambiar color de verde a azul para mejorar la visibilidad
 *          Cambiar ReadAllLines por StreamReader en la lectura de las
 *          opciones del menú
 *          Bloque try-catch en la lectura de fichero
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

class Menu : IPantallaMostrable
{
    protected List<string> menu;
    public static int opcion;

    public Menu()
    {
        menu = new List<string>();
        try
        {
            StreamReader fichero = new StreamReader(@"data\menu.txt");

            string linea;

            do
            {
                linea = fichero.ReadLine();

                if (linea != null)
                {
                    menu.Add(linea);
                }
            } while (linea != null);

            opcion = 0;
        }
        catch(IOException)
        {
            Console.WriteLine("Ha habido un error");
            Environment.Exit(1);
        }
        catch (Exception exc)
        {
            Console.WriteLine("Error inesperado: " + exc.Message);
            Environment.Exit(1);
        }
    }

    public void DibujarOpcion(int yInicial, int yFinal, int opcionActual)
    {
        if (opcion == opcionActual)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        for (int i = yInicial; i < yFinal; i++)
        {
            Console.SetCursorPosition(17, i + 6);
            Console.WriteLine(menu[i]);
        }
    }

    public void Dibujar()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        for (int i = 0; i < 6; i++)
        {
            Console.SetCursorPosition(6, i + 2);
            Console.WriteLine(menu[i]);
        }

        DibujarOpcion(6, 10, 0);
        DibujarOpcion(10, 15, 1);
        DibujarOpcion(15, 20, 2);
        DibujarOpcion(20, 23, 3);
        DibujarOpcion(23, 27, 4);
        DibujarOpcion(27, 31, 5);

        Console.BackgroundColor = ConsoleColor.Black;

        Thread.Sleep(300);
    }

    public int CambiarOpcion()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.DownArrow)
        {
            opcion = (opcion + 1) % 6;
        }
        if (tecla.Key == ConsoleKey.UpArrow)
        {
            if (opcion == 0)
                opcion = 5;
            else
                opcion--;
        }
        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            return opcion;

        return -1;
    }
}
