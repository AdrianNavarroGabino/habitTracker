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
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Menu
{
    protected string[] menu;
    public static int opcion;

    public Menu()
    {
        menu = File.ReadAllLines(@"data\menu.txt");
        opcion = 0;
    }

    public void DibujarOpcion(int yInicial, int yFinal, int opcionActual)
    {
        if (opcion == opcionActual)
        {
            Console.BackgroundColor = ConsoleColor.Green;
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
        if (Console.KeyAvailable)
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
            if (tecla.Key == ConsoleKey.Spacebar)
                return opcion;
        }
        return -1;
    }
}
