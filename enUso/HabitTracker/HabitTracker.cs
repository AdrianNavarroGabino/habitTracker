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
 */

using System;
using System.IO;

class HabitTracker
{
    Carga cargarTracker;
    Tracker tracker;
    NuevoTracker nuevoTracker;
    IntroduccionHabitos introducirHabitos;
    TuAnyoEnPixeles tuAnyoEnPixeles;
    Resumen verResumen;
    ModificacionDeDatos modificarDatos;
    Salir salir;
    Menu menu;

    public HabitTracker()
    {
        Console.SetWindowSize(100, 40);

        cargarTracker = new Carga();
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
                menu.Dibujar();
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
            case 1: break;
            case 2: break;
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
            nuevoTracker.Dibujar();
            ranuraElegida = nuevoTracker.CambiarOpcion();
        } while (ranuraElegida == -1);

        if (ranuraElegida != NuevoTracker.VOLVER)
        {
            introducirHabitos = new IntroduccionHabitos(ranuraElegida);
            IntroducirHabitos();
            
            tracker = new Tracker(ranuraElegida);
            EjecutarTracker(ranuraElegida);
        }
    }

    public void IntroducirHabitos()
    {
        bool seguirIntroduciendo = true;
        int confirmar = -1;

        do
        {
            introducirHabitos.Dibujar();
            do
            {
                introducirHabitos.SeguirIntroduciendo();
                confirmar = introducirHabitos.CambiarOpcion();
                if (confirmar == 1)
                    seguirIntroduciendo = false;
            } while (confirmar == -1);
        } while (seguirIntroduciendo);

        introducirHabitos.GuardarHabitos();
    }

    public void EjecutarTracker(int ranuraElegida)
    {
        int opcionTracker = -1;

        while (opcionTracker != 4)
        {
            tracker.Dibujar();
            opcionTracker = tracker.CambiarOpcion();

            switch (opcionTracker)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    int borrar = -1;

                    while (borrar == -1)
                    {
                        tracker.BorrarTracker();
                        borrar = Utiles.CambiarOpcion();

                        if (borrar == 0)
                        {
                            File.Delete(@"data\ranura" + ranuraElegida + ".txt");
                            opcionTracker = 4;
                        }
                    }

                    break;
            }
        }
    }
}
