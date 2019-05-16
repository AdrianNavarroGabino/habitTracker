/**
* NuevoTracker.cs - Habit Tracker, Opción "nuevo tracker"
* 
* @author Adrián Navarro Gabino
* 
* Cambios:
* 0.02, 06/05/2019:
*           Dibujar ranuras
*           Comprobar si existe un fichero de texto en cada ranura
*           Si existe, poner esa ranura como llena y no dejar elegir
*           Cambiar entre ranuras con las flechas y seleccionar con SPACE o ENTER
*           Volver al menú principal con ESC
* 0.03, 13/05/2019:
*           Heredar de la interfaz IMostrarPantalla
*           Cambiar nombre método DibujarRanura por DibujarOpcion
* 0.05 16/05/2019:
 *          Cambiar color de verde a azul para mejorar la visibilidad
*/

using System;
using System.IO;
using System.Threading;

class NuevoTracker : IPantallaMostrable
{
    public static int VOLVER = 999;

    protected string[] ranuras;
    protected bool[] ranuraVacia;
    protected int opcion;

    public NuevoTracker()
    {
        ranuras = File.ReadAllLines(@"data\ranuras.txt");
        ranuraVacia = new bool[3];

        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(@"data\ranura" + i + ".txt"))
                ranuraVacia[i] = false;
            else
                ranuraVacia[i] = true;
        }

        opcion = 0;
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
            if(yInicial % 8 == 0)
                Console.SetCursorPosition(27, i + 8);
            else
                Console.SetCursorPosition(27, i + 4);

            Console.WriteLine(ranuras[i]);
        }
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
        if ((tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter) && ranuraVacia[opcion])
            return opcion;
        if (tecla.Key == ConsoleKey.Escape)
            return VOLVER;

        return -1;
    }
}