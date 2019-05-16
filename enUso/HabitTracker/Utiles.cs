/**
 * Utiles.cs - Habit Tracker, Clase para métodos variados
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.05, 16/05/2019:
 *          Métodos para dibujar y cambiar entre las opciones "sí" y "no"
 */

using System;
using System.IO;

class Utiles
{
    static int opcion = 0;
    static string[] confirmacion = File.ReadAllLines(@"data\confirmacion.txt");

    public static void DibujarOpcion(int yInicial, int yFinal, int opcionActual)
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
            Console.SetCursorPosition(20 + yInicial * 10, i - yInicial + 25);
            Console.WriteLine(confirmacion[i]);
        }
    }

    public static int CambiarOpcion()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.RightArrow ||
            tecla.Key == ConsoleKey.LeftArrow)
        {
            opcion = (opcion + 1) % 2;
        }
        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
        {
            if (opcion == 0)
                return 0;
            return 1;
        }

        return -1;
    }
}
