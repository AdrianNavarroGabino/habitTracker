/**
 * HabitTracker.cs - Habit Tracker, Clase principal
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.01, 17/04/2019:
 *          Configurar tamaño de ventana
 *          Dibujar menú
 *          Seleccionar opción del menú
 *          Mostrar créditos al salir
 * 0.02, 06/05/2019:
 *          Dibujar ranuras vacías y llenas de memoria
 *          Dibujar pantalla de introducir hábitos
 *          Añadir tecla Enter para seleccionar
 * 0.03, 13/05/2019:
 *          Actualizar el uso de la clase IntroducirHabitos
 * 0.05, 16/05/2019:
 *          Borrar trackers después de crearlos
 *          Refactorizar el código
 * 0.06, 17/05/2019:
 *          La opción "cargar tracker" empieza a estar operativa
 *          Clases EjecutarCargarTracker y EjecutarTrackerCargado
 * 0.07, 20/05/2019:
 *          Añadir la variable estática numeroDeHabitos
 *          En el método IntroducirHabitos, inicializar en 0 la variable
 *          numeroDeHabitos y pasarla por referencia en la llamada del
 *          método GuardarHabitos
 *          Añadir los métodos necesarios de la clase ListaDeComprobaciones
 * 0.08, 22/05/2019:
 *          Borrar el fichero con la lista de comprobaciones cuando se
 *          selecciona la opción "borrar"
 *          En el método EjecutarCargarTracker, cargar y actualizar la
 *          lista de comprobaciones.
 */

using System;
using System.IO;
using System.Threading;

class HabitTracker
{
    Carga cargarTracker;
    Tracker tracker;
    NuevoTracker nuevoTracker;
    TrackerCargado trackerCargado;
    IntroduccionHabitos introducirHabitos;
    TuAnyoEnPixeles tuAnyoEnPixeles;
    Resumen verResumen;
    ModificacionDeDatos modificarDatos;
    Salir salir;
    Menu menu;
    static ListaDeComprobaciones listaDeComprobaciones;

    static int numeroDeHabitos;
    static int ultimaClave;
    public const int ANCHO_PANTALLA = 100;
    public const int ALTO_PANTALLA = 40;

    public HabitTracker()
    {
        Console.SetWindowSize(ANCHO_PANTALLA, ALTO_PANTALLA);
        
        tuAnyoEnPixeles = new TuAnyoEnPixeles();
        verResumen = new Resumen();
        modificarDatos = new ModificacionDeDatos();
        salir = new Salir();
    }

    public void Ejecutar()
    {
        int opcion = -1;

        do
        {
            menu = new Menu();
            do
            {
                menu.Dibujar(-1);
                opcion = menu.CambiarOpcion();
            } while (opcion == -1);

            EjecutarOpcion(opcion);
        } while (opcion != 5);

        salir.MostrarCreditos();
    }

    public void EjecutarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 0:
                EjecutarNuevoTracker();
                break;
            case 1:
                EjecutarCargarTracker();
                break;
            case 2:
                int opcionAnyo;

                do
                {
                    tuAnyoEnPixeles.Dibujar();
                    do
                    {
                        for (int i = 0; i < tuAnyoEnPixeles.GetNumeroDeOpciones(); i++)
                            tuAnyoEnPixeles.DibujarOpcion(i);
                        opcionAnyo = tuAnyoEnPixeles.CambiarOpcion();
                    } while (opcionAnyo == -1);

                    if (opcionAnyo == TuAnyoEnPixeles.ACTUALIZAR)
                    {
                        tuAnyoEnPixeles.Actualizar();
                    }
                    else if (opcionAnyo == TuAnyoEnPixeles.ACTUALIZAR_HOY)
                    {
                        tuAnyoEnPixeles.ActualizarHoy();
                    }
                    else if (opcionAnyo == TuAnyoEnPixeles.BORRAR)
                    {
                        if (tuAnyoEnPixeles.BorrarTuAnyoEnPixeles() == 0)
                        {
                            File.Delete(@"data\anyo.txt");
                            tuAnyoEnPixeles = new TuAnyoEnPixeles();
                        }
                    }
                }
                while (opcionAnyo != TuAnyoEnPixeles.VOLVER);
                break;
            case 3: break;
            case 4: break;
        }
    }

    public void EjecutarNuevoTracker()
    {
        nuevoTracker = new NuevoTracker();

        int ranuraElegida = -1;

        do
        {
            nuevoTracker.Dibujar(ranuraElegida);
            ranuraElegida = nuevoTracker.CambiarOpcion();
        } while (ranuraElegida == -1);

        if (ranuraElegida != Utiles.VOLVER)
        {
            introducirHabitos = new IntroduccionHabitos(ranuraElegida);
            IntroducirHabitos();
            
            tracker = new Tracker(ranuraElegida);
            listaDeComprobaciones = new ListaDeComprobaciones(numeroDeHabitos, ranuraElegida);
            EjecutarTracker(ranuraElegida);
        }
    }

    public void IntroducirHabitos()
    {
        bool seguirIntroduciendo = true;
        int confirmar = -1;
        numeroDeHabitos = 0;

        do
        {
            introducirHabitos.Dibujar(-1);
            do
            {
                introducirHabitos.SeguirIntroduciendo();
                confirmar = introducirHabitos.CambiarOpcion();
                if (confirmar == 1)
                    seguirIntroduciendo = false;
            } while (confirmar == -1);
        } while (seguirIntroduciendo);

        introducirHabitos.GuardarHabitos(ref numeroDeHabitos);
    }

    public void EjecutarTracker(int ranuraElegida)
    {
        int opcionTracker = -1;

        while (opcionTracker != Tracker.VOLVER)
        {
            tracker.Dibujar(ranuraElegida);
            opcionTracker = tracker.CambiarOpcion();
            
            switch (opcionTracker)
            {
                case Tracker.ACTUALIZAR:
                    tracker.ActualizarTracker(ranuraElegida);
                    break;
                case Tracker.BORRAR_TRACKER:
                    int borrar = -1;

                    while (borrar == -1)
                    {
                        tracker.BorrarTracker();
                        borrar = Utiles.CambiarOpcion();

                        if (borrar == 0)
                        {
                            File.Delete(@"data\ranura" + ranuraElegida + ".txt");
                            File.Delete(@"data\meses" + ranuraElegida + ".txt");
                            opcionTracker = Tracker.VOLVER;
                        }
                    }

                    break;
            }
        }
    }

    public void EjecutarCargarTracker()
    {
        cargarTracker = new Carga();

        int ranuraElegida = -1;

        do
        {
            cargarTracker.Dibujar(ranuraElegida);
            ranuraElegida = cargarTracker.CambiarOpcion();
        } while (ranuraElegida == -1);
        if (ranuraElegida != Utiles.VOLVER)
        {

            listaDeComprobaciones = new ListaDeComprobaciones(numeroDeHabitos, ranuraElegida);
            trackerCargado = new TrackerCargado(ranuraElegida);
            ultimaClave = listaDeComprobaciones.GenerarClave(DateTime.Now.Year, DateTime.Now.Month);
            listaDeComprobaciones.ActualizarLista(ref ultimaClave);
            EjecutarTrackerCargado(ranuraElegida);
        }
    }

    public void EjecutarTrackerCargado(int ranuraElegida)
    {
        int opcionTracker = -1;

        while (opcionTracker != Tracker.VOLVER)
        {
            trackerCargado.Dibujar(ranuraElegida);
            opcionTracker = trackerCargado.CambiarOpcion();

            switch (opcionTracker)
            {
                case Tracker.ACTUALIZAR:
                    trackerCargado.ActualizarTracker(ranuraElegida);
                    break;
                case Tracker.BORRAR_TRACKER:
                    int borrar = -1;

                    while (borrar == -1)
                    {
                        trackerCargado.BorrarTracker();
                        borrar = Utiles.CambiarOpcion();

                        if (borrar == 0)
                        {
                            File.Delete(@"data\ranura" + ranuraElegida + ".txt");
                            File.Delete(@"data\meses" + ranuraElegida + ".txt");
                            opcionTracker = Tracker.VOLVER;
                        }
                    }

                    break;
            }
        }
    }
}
