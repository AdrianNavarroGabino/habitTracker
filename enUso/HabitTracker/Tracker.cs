/**
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
 *          Eliminar algunas variables que ahora están en la clase
 *          ListaDeComprobaciones
 * 0.08, 22/05/2019:
 *          Método ElegirHabito y ElegirFecha para que la opción "Actualizar"
 *          empiece a ser operativa
 * 0.11, 27/05/2019:
 *          Limitar opciones al mes actual (mejorable en próximas versiones)
 *          Corregir fallos de selección de opciones
 *          Mejoras en actualizar hábito
 * 0.12, 29/05/2019:
 *          Elegir dia en la opción actualizar antes de preguntar si se ha
 *          realidado el hábito elegido.
 *          Método ActualizarHoy: Elige hábito a actualizar y pantalla para ver
 *          si se ha realizado o no el hábito.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Tracker : IPantallaMostrable
{
    protected string[] opciones = { "ACTUALIZAR", "ACTUALIZAR HOY", "BORRAR TRACKER", "VOLVER" };
    public const int ACTUALIZAR = 0;
    public const int ACTUALIZAR_HOY = 1;
    public const int BORRAR_TRACKER = 2;
    public const int VOLVER = 3;
    protected string[] habitos;
    protected string[] mesesDibujados;
    
    protected int numeroDeHabitos;
    protected int opcion;
    protected int opcionDias;

    protected DateTime ahora;
    protected int anyoActual;
    protected int numeroDeDias;

    protected string[] ranuras;
    public static bool[] ranuraVacia;

    protected ListaDeComprobaciones listaDeComprobaciones;

    public Tracker(int ranuraElegida)
    {
        habitos = File.ReadAllLines(@"data\ranura" + ranuraElegida + ".txt");
        mesesDibujados = File.ReadAllLines(@"data\meses.txt");
        numeroDeHabitos = habitos.Length;
        opcion = 0;

        ahora = DateTime.Now;
        anyoActual = ahora.Year;
        numeroDeDias = DateTime.DaysInMonth(anyoActual, ahora.Month);

        opcionDias = 0;

        listaDeComprobaciones = new ListaDeComprobaciones(numeroDeHabitos, ranuraElegida);
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
        Utiles.DibujarAnyo("" + anyoActual);
        Console.WriteLine();

        for(int i = 0; i < 20; i++)
            Console.Write(" ");
        for(int i = 0; i < numeroDeDias; i++)
        {
            Console.Write("__");
        }
        Console.WriteLine();

        DibujarTabla(ranuraElegida);

        for (int i = 0; i < opciones.Length; i++)
        {
            DibujarOpcion(i * HabitTracker.ANCHO_PANTALLA / opciones.Length + 7, HabitTracker.ALTO_PANTALLA - 2, i);
        }

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
            opcion = (opcion + 1) % opciones.Length;
        }
        if(tecla.Key == ConsoleKey.LeftArrow)
        {
            if (opcion == 0)
                opcion = opciones.Length - 1;
            else
                opcion--;
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

    public void ActualizarTracker(
        int ranuraElegida, ListaDeComprobaciones listaDeComprobaciones)
    {
        ListaDeComprobaciones comprobaciones =
            new ListaDeComprobaciones(habitos.Length, ranuraElegida);

        int habito = ElegirHabito(ranuraElegida);

        opcionDias = 1;
        int dia;

        DibujarPortadaDias();

        int mes = DateTime.Now.Month;

        do
        {
            for (int i = 1; i <= DateTime.DaysInMonth(2019, mes); i++)
            {
                DibujarDias(i, i / 10);
            }
            dia = CambiarOpcionDia(DateTime.DaysInMonth(2019, mes));
        } while (dia == -1);

        listaDeComprobaciones.AnyadirComprobacion(
            DateTime.Now.Day, mes, ConfirmarHabito() == 0);
    }

    public void DibujarHabito(int opcionActual)
    {
        if (opcionActual == opcion)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 2 - habitos[opcionActual].Length / 2, opcionActual * 2 + 12);
        Console.WriteLine(habitos[opcionActual]);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public int CambiarOpcionHabito()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.DownArrow)
        {
            opcion = (opcion + 1) % habitos.Length;
        }
        if (tecla.Key == ConsoleKey.UpArrow)
        {
            if (opcion == 0)
            {
                opcion = habitos.Length - 1;
            }
            else
            {
                opcion--;
            }
        }

        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            return opcion;

        return -1;
    }

    public int ElegirHabito(int ranuraElegida)
    {
        int habitoElegido;

        Console.Clear();
        Console.SetCursorPosition(13, 3);
        Console.WriteLine(@"  ___ _    ___ ___ ___   _   _ _  _   _  _   _   ___ ___ _____ ___  ");
        Console.SetCursorPosition(13, 4);
        Console.WriteLine(@" | __| |  |_ _/ __| __| | | | | \| | | || | /_\ | _ )_ _|_   _/ _ \ ");
        Console.SetCursorPosition(13, 5);
        Console.WriteLine(@" | _|| |__ | | (_ | _|  | |_| | .` | | __ |/ _ \| _ \| |  | || (_) |");
        Console.SetCursorPosition(13, 6);
        Console.WriteLine(@" |___|____|___\___|___|  \___/|_|\_| |_||_/_/ \_\___/___| |_| \___/ ");

        do
        {
            for (int i = 0; i < habitos.Length; i++)
            {
                DibujarHabito(i);
            }
            habitoElegido = CambiarOpcionHabito();
        } while (habitoElegido == -1);

        return habitoElegido;
    }

    public int ConfirmarHabito()
    {
        int opcionActual = 0;
        int confirmar = -1;

        Console.Clear();

        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _    ___    _  _   _   ___   _  _ ___ ___ _  _  ___ ___ ".Length /
            2), 3);
        Console.WriteLine(@"   _  _    ___    _  _   _   ___   _  _ ___ ___ _  _  ___ ___ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _    ___    _  _   _   ___   _  _ ___ ___ _  _  ___ ___ ".Length /
            2), 4);
        Console.WriteLine(@"  (_)| |  / _ \  | || | /_\ / __| | || | __/ __| || |/ _ \__ \");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _    ___    _  _   _   ___   _  _ ___ ___ _  _  ___ ___ ".Length /
            2), 5);
        Console.WriteLine(@" / /_| |_| (_) | | __ |/ _ \\__ \ | __ | _| (__| __ | (_) |/_/");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _    ___    _  _   _   ___   _  _ ___ ___ _  _  ___ ___ ".Length /
            2), 6);
        Console.WriteLine(@" \___|____\___/  |_||_/_/ \_\___/ |_||_|___\___|_||_|\___/(_) ");

        while (confirmar == -1)
        {
            TuAnyoEnPixeles.DibujarSiYNo(opcionActual);
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.RightArrow ||
                tecla.Key == ConsoleKey.LeftArrow)
            {
                opcionActual = (opcionActual + 1) % 2;
            }
            if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            {
                return opcionActual;
            }
        }
        return -1;
    }

    public void ActualizarHoy(
        int ranuraElegida, ListaDeComprobaciones listaDeComprobaciones)
    {
        int habito = ElegirHabito(ranuraElegida);

        listaDeComprobaciones.AnyadirComprobacion(
            DateTime.Now.Day, DateTime.Now.Month, ConfirmarHabito() == 0);
    }

    public static void DibujarPortadaDias()
    {
        Console.Clear();

        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 3);
        Console.WriteLine(@"  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 4);
        Console.WriteLine(@" | __| |  |_ _/ __| __| | | | | \| | |   \_ _| /_\ (_)");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 5);
        Console.WriteLine(@" | _|| |__ | | (_ | _|  | |_| | .` | | |) | | / _ \ _ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 6);
        Console.WriteLine(@" |___|____|___\___|___|  \___/|_|\_| |___/___/_/ \_(_)");
    }

    public void DibujarDias(int opcionActual, int decenas)
    {
        if (opcionActual == opcion)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        if (opcionActual % 10 == 0)
            Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 5 *
                (decenas - 1) + HabitTracker.ANCHO_PANTALLA / 6,
                (opcionActual - 1) % 10 * 3 + 10);
        else
            Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 5 *
                decenas + HabitTracker.ANCHO_PANTALLA / 6,
                (opcionActual - 1) % 10 * 3 + 10);
        Console.WriteLine(opcionActual);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public int CambiarOpcionDia(int numeroDeDias)
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        switch (tecla.Key)
        {
            case ConsoleKey.DownArrow:
                if (opcion == numeroDeDias)
                    opcion = 1;
                else
                    opcion++;
                break;
            case ConsoleKey.UpArrow:
                if (opcion == 1)
                    opcion = numeroDeDias;
                else
                    opcion--;
                break;
            case ConsoleKey.RightArrow:
                if (((opcion - 1) / 10) == (numeroDeDias / 10))
                    opcion %= 10;
                else
                {
                    if (opcion + 10 <= numeroDeDias)
                        opcion += 10;
                    else
                        opcion = numeroDeDias;
                }
                break;
            case ConsoleKey.LeftArrow:
                if ((opcion - 1) / 10 == 0)
                {
                    if (opcion + numeroDeDias / 10 * 10 >= numeroDeDias)
                        opcion = numeroDeDias;
                    else
                        opcion = opcion + numeroDeDias / 10 * 10;
                }
                else
                    opcion -= 10;
                break;
            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                return opcion;
        }

        return -1;
    }
}
