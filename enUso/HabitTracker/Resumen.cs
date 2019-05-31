

using System;
/**
* Resumen.cs - Habit Tracker, Opción "ver resumen"
* 
* @author Adrián Navarro Gabino
* 
* Cambios:
* 0.14, 31/05/2019:
*           Constructor
*           Método VerResumen
*           Método MostrarResumen
*           Método MostrarTracker
*           Método MostrarAnyoEnPixeles
*           Método DibujarTracker
*           Método DibujarOpcion
*           Método CambiarOpcion
*/
class Resumen
{
    protected Carga tracker;
    protected TuAnyoEnPixeles tuAnyoEnPixeles;
    protected ListaDeComprobaciones listaDeComprobaciones;
    protected TrackerCargado trackerCargado;
    protected int ranuraElegida;
    protected int opcion;

    protected string[] opcionesTracker = { "SIGUIENTE", "VOLVER" };
    protected string[] opcionesAnyoEnPixeles = { "ANTERIOR", "VOLVER" };
    public const int SIGUIENTE = 0;
    public const int VOLVER = 1;
    public const int ANTERIOR = 0;

    public Resumen()
    {
        opcion = 0;

        tracker = new Carga();

        ranuraElegida = -1;

        do
        {
            tracker.Dibujar(ranuraElegida);
            ranuraElegida = tracker.CambiarOpcion();
        } while (ranuraElegida == -1);
        tuAnyoEnPixeles = new TuAnyoEnPixeles();
    }

    public void VerResumen(int numeroDeHabitos)
    {
        if (ranuraElegida != Utiles.VOLVER)
        {

            listaDeComprobaciones = new ListaDeComprobaciones(
                numeroDeHabitos, ranuraElegida);
            trackerCargado = new TrackerCargado(ranuraElegida);
            int clave = listaDeComprobaciones.GenerarClave(
                DateTime.Now.Year, DateTime.Now.Month);
            listaDeComprobaciones.ActualizarLista(ref clave);
            MostrarTracker();
        }
    }

    public void MostrarTracker()
    {
        int opcionTracker = -1;

        while (opcionTracker != VOLVER)
        {
            opcionTracker = DibujarTracker();

            if (opcionTracker == SIGUIENTE)
            {
                MostrarAnyoEnPixeles();
            }
            else if (opcionTracker == VOLVER)
            {
                HabitTracker habitTracker = new HabitTracker();
                habitTracker.Ejecutar();
            }
        }
    }

    public void MostrarAnyoEnPixeles()
    {
        int opcionAnyo;

        do
        {
            tuAnyoEnPixeles.Dibujar();
            do
            {
                DibujarOpcion(ANTERIOR, opcionesAnyoEnPixeles);
                DibujarOpcion(VOLVER, opcionesAnyoEnPixeles);
                opcionAnyo = CambiarOpcion(opcionesAnyoEnPixeles);
            } while (opcionAnyo == -1);

            if (opcionAnyo == ANTERIOR)
            {
                MostrarTracker();
            }
            else if (opcionAnyo == VOLVER)
            {
                HabitTracker habitTracker = new HabitTracker();
                habitTracker.Ejecutar();
            }
        } while (opcionAnyo != VOLVER);
    }

    public int DibujarTracker()
    {
        Console.Clear();

        trackerCargado.DibujarMes(DateTime.Now.Month);
        Utiles.DibujarAnyo("" + DateTime.Now.Year);
        Console.WriteLine();

        for (int i = 0; i < 20; i++)
            Console.Write(" ");
        for (int i = 0;
            i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            i++)
        {
            Console.Write("__");
        }
        Console.WriteLine();

        trackerCargado.DibujarTabla(ranuraElegida);

        int opcionResumen;
        do
        {
            DibujarOpcion(SIGUIENTE, opcionesTracker);
            DibujarOpcion(VOLVER, opcionesTracker);
            opcionResumen = CambiarOpcion(opcionesTracker);
        } while (opcionResumen == -1);

        return opcionResumen;
    }

    public void DibujarOpcion(int opcionActual, string[] opciones)
    {
        int numeroDeOpciones = opciones.Length;

        int separacion = HabitTracker.ANCHO_PANTALLA / (numeroDeOpciones + 1);


        Console.SetCursorPosition(separacion * (opcionActual + 1) - (opciones[opcionActual].Length / 2),
            HabitTracker.ALTO_PANTALLA - 3);
        if (opcion == opcionActual)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        Console.WriteLine(opciones[opcionActual]);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public int CambiarOpcion(string[] opciones)
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.RightArrow)
        {
            opcion = (opcion + 1) % opciones.Length;
        }
        if (tecla.Key == ConsoleKey.LeftArrow)
        {
            if (opcion != 0)
                opcion--;
            else
                opcion = opciones.Length - 1;
        }

        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            return opcion;

        return -1;
    }
}