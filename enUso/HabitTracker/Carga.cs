/**
* Carga.cs - Habit Tracker, Opción "cargar tracker"
* 
* @author Adrián Navarro Gabino
* 
* Cambios:
* 0.06, 17/05/2019:
*           Constructor
*           Métodos Dibujar, DibujarOpcion y CambiarOpcion
*/

using System;
using System.IO;
using System.Threading;

class Carga : IPantallaMostrable
{
    protected int opcion;
    protected string[] ranuras;
    protected bool[] ranuraVacia;

    public Carga()
    {
        opcion = 0;
        ranuras = File.ReadAllLines(@"data\ranuras.txt");
        ranuraVacia = new bool[3];

        for (int i = 0; i < 3; i++)
        {
            ranuraVacia[i] = File.Exists(@"data\ranura" + i + ".txt") ?
                false : true;
        }

        opcion = 0;
    }

    public int CambiarOpcion()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.DownArrow)
        {
            opcion = (opcion + 1) % 3;
        }
        if (tecla.Key == ConsoleKey.UpArrow)
        {
            if (opcion == 0)
                opcion = 2;
            else
                opcion--;
        }
        if ((tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter) && !ranuraVacia[opcion])
            return opcion;
        if (tecla.Key == ConsoleKey.Escape)
            return Utiles.VOLVER;

        return -1;
    }

    public void Dibujar()
    {
        Console.Clear();

        for (int i = 0; i < 3; i++)
        {
            if (ranuraVacia[i])
                DibujarOpcion(i * 8, i * 8 + 4, i);
            else
                DibujarOpcion(i * 8 + 4, i * 8 + 8, i);
        }

        Console.BackgroundColor = ConsoleColor.Black;

        Thread.Sleep(300);
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
            if (yInicial % 8 == 0)
                Console.SetCursorPosition(27, i + 8);
            else
                Console.SetCursorPosition(27, i + 4);

            Console.WriteLine(ranuras[i]);
        }
    }
}