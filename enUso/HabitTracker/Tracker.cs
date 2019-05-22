﻿/**
 * Tracker.cs - Habit Tracker, Pantalla del tracker
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.04, 15/05/2019:
 *          Creación de la clase
 *          Dibujar el mes y el año que correspondan
 *          Dibujar tabla con los días que tenga cada mes y con una fila por
 *          cada hábito
 *          Limitar el tamaño del hábito para que quepa en pantalla
 *          Mostrar opciones en la parte de abajo de la pantalla
 *          Opcion "VOLVER" funcional
 * 0.05, 16/05/2019:
 *          Cambiar color de verde a azul para mejorar la visibilidad
 *          Método BorrarTracker
 * 0.07, 20/05/2019:
 *          Eliminar algunas variables que ahora están en la clase ListaDeComprobaciones
 * 0.08, 22/05/2019:
 *          Método ElegirHabito y ElegirFecha para que la opción "Actualizar" empiece a
 *          ser operativa
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Tracker : IPantallaMostrable
{
    static string[] mes = {"enero", "febrero", "marzo",
                "abril", "mayo", "junio",
                "julio", "agosto", "septiembre",
                "octubre", "noviembre", "diciembre"};
    string[] opciones = { "ACTUALIZAR", "MES ANTERIOR", "MES SIGUIENTE", "BORRAR TRACKER", "VOLVER" };
    string[] habitos;
    string[] mesesDibujados;
    string[] numerosDibujados;
    int numeroDeHabitos;
    int opcion;

    DateTime ahora;
    int anyoActual;
    int numeroDeDias;

    protected string[] ranuras;
    public static bool[] ranuraVacia;

    public Tracker(int ranuraElegida)
    {
        habitos = File.ReadAllLines(@"data\ranura" + ranuraElegida + ".txt");
        mesesDibujados = File.ReadAllLines(@"data\meses.txt");
        numerosDibujados = File.ReadAllLines(@"data\numeros.txt");
        numeroDeHabitos = habitos.Length;
        opcion = 0;

        ahora = DateTime.Now;
        anyoActual = ahora.Year;
        numeroDeDias = DateTime.DaysInMonth(anyoActual, ahora.Month);
    }

    public Tracker()
    {
        ranuras = File.ReadAllLines(@"data\ranuras.txt");
        ranuraVacia = new bool[3];

        for (int i = 0; i < 3; i++)
        {
            ranuraVacia[i] = File.Exists(@"data\ranura" + i + ".txt") ?
                false : true;
        }

        opcion = 0;
    }

    public int GetOpcion() { return opcion; }
    public void SetOpcion(int opcion) { this.opcion = opcion; }

    public virtual void Dibujar(int ranuraElegida)
    {
        Console.Clear();

        DibujarMes(ahora.Month);
        DibujarAño("" + anyoActual);
        Console.WriteLine();

        for(int i = 0; i < 20; i++)
            Console.Write(" ");
        for(int i = 0; i < numeroDeDias; i++)
        {
            Console.Write("__");
        }
        Console.WriteLine();

        DibujarTabla(ranuraElegida);

        DibujarOpcion(5, 38, 0);
        DibujarOpcion(24, 38, 1);
        DibujarOpcion(43, 38, 2);
        DibujarOpcion(62, 38, 3);
        DibujarOpcion(81, 38, 4);

        Thread.Sleep(300);
    }

    public virtual void DibujarOpcion(int xInicial, int yInicial, int opcionActual)
    {
        if (opcion == opcionActual)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        
        Console.SetCursorPosition(xInicial, yInicial);

        Console.WriteLine(opciones[opcionActual]);

        Console.BackgroundColor = ConsoleColor.Black;
    }

    public virtual int CambiarOpcion()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.RightArrow)
        {
            opcion = (opcion + 1) % 5;
        }
        if(tecla.Key == ConsoleKey.LeftArrow)
        {
            if (opcion == 0)
                opcion = 4;
            else
                opcion = (opcion - 1) % 5;
        }
        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
        {
            return opcion;
        }

        return -1;
    }

    public void DibujarMes(int mes, int yInicialDibujo = 0)
    {
        int yInicial = -1;
        int xInicial = -1;
        switch(mes)
        {
            case 1:
                yInicial = 0;
                xInicial = 17;
                break;
            case 2:
                yInicial = 4;
                xInicial = 10;
                break;
            case 3:
                yInicial = 8;
                xInicial = 13;
                break;
            case 4:
                yInicial = 12;
                xInicial = 17;
                break;
            case 5:
                yInicial = 16;
                xInicial = 18;
                break;
            case 6:
                yInicial = 20;
                xInicial = 15;
                break;
            case 7:
                yInicial = 24;
                xInicial = 15;
                break;
            case 8:
                yInicial = 28;
                xInicial = 9;
                break;
            case 9:
                yInicial = 32;
                xInicial = 5;
                break;
            case 10:
                yInicial = 36;
                xInicial = 15;
                break;
            case 11:
                yInicial = 40;
                xInicial = 12;
                break;
            case 12:
                yInicial = 44;
                xInicial = 16;
                break;
        }

        for (int i = yInicial; i < yInicial + 4; i++)
        {
            Console.SetCursorPosition(xInicial, i - yInicial + yInicialDibujo);
            Console.WriteLine(mesesDibujados[i]);
        }

    }

    public void DibujarAño(string anyo, int xInicialDibujo = 60, int yInicialDibujo = 0)
    {
        int xInicial = 60;
        int yInicial = -1;

        foreach (char numero in anyo)
        {
            switch(numero)
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

            for(int j = yInicial; j < yInicial + 4; j++)
            {
                Console.SetCursorPosition(xInicialDibujo,
                                    j - yInicial + yInicialDibujo);
                Console.WriteLine(numerosDibujados[j]);
            }
            xInicial += 7;
        }
    }

    public void DibujarTabla(int ranuraElegida)
    {
        string[] datos = File.ReadAllLines(@"data\meses" + ranuraElegida + ".txt");
        int numeroDeLetrasDelHabito;

        for (int i = 0; i < numeroDeHabitos; i++)
        {
            if (habitos[i].Length <= 20)
            {
                Console.Write(habitos[i]);
                numeroDeLetrasDelHabito = habitos[i].Length;
            }
            else
            {
                Console.Write(habitos[i].Substring(0, 17) + "...");
                numeroDeLetrasDelHabito = 20;
            }

            for (int j = 0; j < 20 - numeroDeLetrasDelHabito; j++)
            {
                Console.Write(" ");
            }

            Console.Write("|");
            for (int j = 0; j < numeroDeDias; j++)
            {
                if (datos[i + 1][j] == 'O')
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else if (datos[i + 1][j] == 'X')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                Console.Write("_");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("|");
            }
            Console.WriteLine();
        }
    }

    public void BorrarTracker()
    {
        Console.Clear();
        
        Console.SetCursorPosition(15, 10);
        Console.WriteLine(@"   _  ___ ___ _____ _   ___   ___ ___ ___ _   _ ___  ___ ___ ");
        Console.SetCursorPosition(15, 11);
        Console.WriteLine(@"  (_)| __/ __|_   _/_\ / __| / __| __/ __| | | | _ \/ _ \__ \");
        Console.SetCursorPosition(15, 12);
        Console.WriteLine(@" / /_| _|\__ \ | |/ _ \\__ \ \__ \ _| (_ | |_| |   / (_) |/_/");
        Console.SetCursorPosition(15, 13);
        Console.WriteLine(@" \___|___|___/ |_/_/ \_\___/ |___/___\___|\___/|_|_\\___/(_) ");

        Console.BackgroundColor = ConsoleColor.Black;

        Utiles.DibujarOpcion(0, 4, 0);
        Utiles.DibujarOpcion(4, 8, 1);

        Console.BackgroundColor = ConsoleColor.Black;

        Thread.Sleep(300);
    }

    public void ActualizarTracker(int ranuraElegida)
    {
        ListaDeComprobaciones comprobaciones =
            new ListaDeComprobaciones(habitos.Length, ranuraElegida);

        string habito = ElegirHabito(ranuraElegida, comprobaciones);
        int fecha = ElegirFecha(ranuraElegida);
        /*ElegirMes(ranuraElegida);
        ElegirDia(ranuraElegidar);
        MarcarHabito(ranuraElegida);*/
    }

    public string ElegirHabito(int ranuraElegida)
    {
        Console.Clear();
        Console.SetCursorPosition(13, 3);
        Console.WriteLine(@"  ___ _    ___ ___ ___   _   _ _  _   _  _   _   ___ ___ _____ ___  ");
        Console.SetCursorPosition(13, 4);
        Console.WriteLine(@" | __| |  |_ _/ __| __| | | | | \| | | || | /_\ | _ )_ _|_   _/ _ \ ");
        Console.SetCursorPosition(13, 5);
        Console.WriteLine(@" | _|| |__ | | (_ | _|  | |_| | .` | | __ |/ _ \| _ \| |  | || (_) |");
        Console.SetCursorPosition(13, 6);
        Console.WriteLine(@" |___|____|___\___|___|  \___/|_|\_| |_||_/_/ \_\___/___| |_| \___/ ");

        for(int i = 0; i < habitos.Length; i++)
        {
            Console.SetCursorPosition(40, 15 + i);
            Console.WriteLine((i + 1) + " - " + habitos[i]);
        }

        Console.SetCursorPosition(10, 37);
        Console.Write("Elige un hábito: ");
        int opcion = -1;
        while(opcion == -1)
        {
            Console.SetCursorPosition(10 + "Elige un hábito: ".Length, 37);
            Console.WriteLine(new String(' ', 100 - 10 - "Elige un hábito: ".Length));
            Console.SetCursorPosition(10 + "Elige un hábito: ".Length, 37);
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion < 1 || opcion > habitos.Length)
                    opcion = -1;
            }
            catch(Exception)
            {
                opcion = -1;
            }
        }
        return habitos[opcion - 1];
    }

    public int ElegirFecha(int ranuraElegida, ListaDeComprobaciones comprobaciones)
    {
        SortedList<int, char[][]> listaComprobaciones = comprobaciones.GetListaDeComprobaciones();

        int yInicial = 2;
        int xInicial = 10;

        Console.Clear();
        foreach (KeyValuePair<int, char[][]> comprobacion in listaComprobaciones)
        {
            int anyo, mes;
            comprobaciones.DescrifrarClave(out anyo, out mes, comprobacion.Key);
            DibujarMes(mes, yInicial);
            DibujarAño("" + anyo, xInicial, yInicial);

            yInicial += 5;
        }

        int opcion = -1;
        Console.SetCursorPosition(10, 37);
        Console.Write("Introduce una fecha \"YYYYMM\": ");
        while (opcion == -1)
        {
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());

                foreach (KeyValuePair<int, char[][]> comprobacion in listaComprobaciones)
                {
                    if(comprobacion.Key == opcion)
                    {
                        return opcion;
                    }
                }
                opcion = -1;
            }
            catch (Exception)
            {
                opcion = -1;
            }
        }
        return opcion;
    }
}
