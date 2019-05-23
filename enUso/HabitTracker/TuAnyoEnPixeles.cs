/**
* TuAnyoEnPixeles.cs - Habit Tracker, Opción "tu año en píxeles"
* 
* @author Adrián Navarro Gabino
* 
* Cambios:
* 0.09, 23/05/2019:
*           Creación de la clase
*           Creación del constructor en el que, si no se ha creado antes,
*           se crea la lista de comprobaciones dentro del año y se guarda
*           en un fichero y, si el fichero ya existe, se cargan los datos
*           al array de comprobaciones
*           Crear getters para el año actual y la lista de comprobaciones
*           Método DibujarTabla que comprueba cada día de cada mes para
*           poner la celda de esa tabla en negro, verde o rojo dependiendo
*           de si no se han introducido datos, o si ese día fue bueno o malo
*           Método Dibujar que dibuja el año actual con ASCII ART como cabecera
*           Método DibujarOpciones, que escribe las opciones en el final de la
*           pantalla, aún no están operativos.
*/

using System;
using System.IO;

class TuAnyoEnPixeles
{
    protected int anyoActual;
    protected string[] comprobaciones;
    protected string[] datosComprobaciones;
    protected static int opcion;
    protected string[] opciones = { "ACTUALIZAR", "VOLVER" };

    public TuAnyoEnPixeles()
    {
        anyoActual = DateTime.Now.Year;
        comprobaciones = new string[12];

        if (!File.Exists(@"data\anyo.txt"))
        {
            for(int i = 1; i <= 12; i++)
            {
                comprobaciones[i - 1] = new string('-', DateTime.DaysInMonth(anyoActual, i));
            }

            File.WriteAllLines(@"data\anyo.txt", comprobaciones);
        }
        else
        {
            datosComprobaciones = File.ReadAllLines(@"data\anyo.txt");

            for(int i = 0; i < 12; i++)
            {
                comprobaciones[i] = datosComprobaciones[i];
            }
        }
    }

    public int GetAnyoActual() { return anyoActual; }
    public string[] GetComprobaciones() { return comprobaciones; }

    public void Dibujar()
    {
        Console.Clear();
        
        Utiles.DibujarAnyo("" + anyoActual, HabitTracker.ANCHO_PANTALLA / 2 - 14);
        DibujarTabla();
        DibujarOpciones();
    }

    public void DibujarTabla()
    {
        for (int i = 0; i < 12; i++)
        {
            Console.SetCursorPosition(17, 8 + i * 2);
            Console.WriteLine(new string('_', DateTime.DaysInMonth(anyoActual, i + 1) * 2 + 1));

            Console.SetCursorPosition(2, i * 2 + 9);
            Console.Write(Utiles.mes[i].Substring(0, 1).ToUpper() + Utiles.mes[i].Substring(1));
            for (int j = 0; j < DateTime.DaysInMonth(anyoActual, i + 1); j++)
            {
                Console.SetCursorPosition(17 + j * 2, i * 2 + 9);
                Console.Write("|");
                if (comprobaciones[i][j] == 'O')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (comprobaciones[i][j] == 'X')
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.SetCursorPosition(18 + j * 2, i * 2 + 9);
                Console.Write("_");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(19 + j * 2, i * 2 + 9);
            }
            Console.Write("|");
        }
    }

    public void DibujarOpciones(int opcionActual = 0)
    {
        int numeroDeOpciones = opciones.Length;

        int separacion = HabitTracker.ANCHO_PANTALLA / (numeroDeOpciones + 1);

        for(int i = 0; i < numeroDeOpciones; i++)
        {
            Console.SetCursorPosition(separacion * (i + 1) - (opciones[i].Length / 2),
                HabitTracker.ALTO_PANTALLA - 3);
            if(opcionActual == i)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine(opciones[i]);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.LeftArrow || tecla.Key == ConsoleKey.RightArrow)
        {
            opcionActual = (opcionActual + 1) % 2;
        }
    }

    /*public int CambiarOpcion()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.LeftArrow || tecla.Key == ConsoleKey.RightArrow)
        {
            opcion = (opcion + 1) % 2;
        }

        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            return opcion;

        return -1;
    }*/
}