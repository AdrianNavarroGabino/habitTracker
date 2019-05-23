/**
 * Utiles.cs - Habit Tracker, Clase para métodos variados
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.05, 16/05/2019:
 *          Métodos para dibujar y cambiar entre las opciones "sí" y "no"
 * 0.09, 23/05/2019:
 *          Variable mes y método DibujarAnyo trasladado de la clase Tracker
 */

using System;
using System.IO;

class Utiles
{
    public const int VOLVER = 999;
    static int opcion = 0;
    static string[] confirmacion = File.ReadAllLines(@"data\confirmacion.txt");
    public static string[] mes = {"enero", "febrero", "marzo",
                                "abril", "mayo", "junio",
                                "julio", "agosto", "septiembre",
                                "octubre", "noviembre", "diciembre"};

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

    public static void DibujarAnyo(string anyo, int xInicialDibujo = 60, int yInicialDibujo = 0)
    {
        string[] numerosDibujados = File.ReadAllLines(@"data\numeros.txt");
        int yInicial = -1;

        foreach (char numero in anyo)
        {
            switch (numero)
            {
                case '0':
                    yInicial = 0;
                    break;
                case '1':
                    yInicial = 4;
                    break;
                case '2':
                    yInicial = 8;
                    break;
                case '3':
                    yInicial = 12;
                    break;
                case '4':
                    yInicial = 16;
                    break;
                case '5':
                    yInicial = 20;
                    break;
                case '6':
                    yInicial = 24;
                    break;
                case '7':
                    yInicial = 28;
                    break;
                case '8':
                    yInicial = 32;
                    break;
                case '9':
                    yInicial = 36;
                    break;
            }

            for (int j = yInicial; j < yInicial + 4; j++)
            {
                Console.SetCursorPosition(xInicialDibujo,
                                    j - yInicial + yInicialDibujo);
                Console.WriteLine(numerosDibujados[j]);
            }
            xInicialDibujo += 7;
        }
    }
}
