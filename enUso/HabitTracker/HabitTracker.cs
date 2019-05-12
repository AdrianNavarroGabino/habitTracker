/**
 * VerResumen.cs - Habit Tracker, Clase principal
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
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HabitTracker
{
    static void Main(string[] args)
    {
        Console.SetWindowSize(100, 40);
        
        CargarTracker cargarTracker = new CargarTracker();
        TuAnyoEnPixeles tuAnyoEnPixeles = new TuAnyoEnPixeles();
        VerResumen verResumen = new VerResumen();
        ModificarDatos modificarDatos = new ModificarDatos();
        Salir salir = new Salir();

        int opcion = -1;

        do
        {
            Menu menu = new Menu();
            do
            {
                menu.Dibujar();
                opcion = menu.CambiarOpcion();
            } while (opcion == -1);

            switch(opcion)
            {
                case 0:
                    NuevoTracker nuevoTracker = new NuevoTracker();

                    int ranuraElegida = -1;

                    do
                    {
                        nuevoTracker.Dibujar();
                        ranuraElegida = nuevoTracker.CambiarOpcion();
                    } while (ranuraElegida == -1);

                    if (ranuraElegida != NuevoTracker.VOLVER)
                    {
                        IntroducirHabitos introducirHabitos = new IntroducirHabitos(ranuraElegida);
                        bool seguirIntroduciendo = true;

                        do
                        {
                            introducirHabitos.IntroducirHabito();
                            seguirIntroduciendo = introducirHabitos.SeguirIntroduciendo();
                        } while (seguirIntroduciendo);

                        introducirHabitos.GuardarHabitos();
                    }
                    break;
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
            }
        } while (opcion != 5);

        salir.MostrarCreditos();
    }
}
