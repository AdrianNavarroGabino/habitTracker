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
* 0.05, 16/05/2019:
*           Cambiar color de verde a azul para mejorar la visibilidad
* 0.06, 17/05/2019:
*           Clase hereda de Tracker
*           Metodos override
*           Cambio del constructor a la clase padre
*/

using System;
using System.IO;
using System.Threading;

class NuevoTracker : Tracker, IPantallaMostrable
{
    public NuevoTracker(): base()
    {
    }

    public override void DibujarOpcion(int yInicial, int yFinal, int opcionActual)
    {
        if (GetOpcion() == opcionActual)
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

    public override void Dibujar(int ranuraElegida)
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

    public override int CambiarOpcion()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.DownArrow)
        {
            SetOpcion((GetOpcion() + 1) % 3);
        }
        if (tecla.Key == ConsoleKey.UpArrow)
        {
            if (GetOpcion() == 0)
                SetOpcion(2);
            else
                SetOpcion(GetOpcion() - 1);
        }
        if ((tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter) && ranuraVacia[GetOpcion()])
            return GetOpcion();
        if (tecla.Key == ConsoleKey.Escape)
            return Utiles.VOLVER;

        return -1;
    }
}