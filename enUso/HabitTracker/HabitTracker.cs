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

        Menu menu = new Menu();
        NuevoTracker nuevoTracker = new NuevoTracker();
        CargarTracker cargarTracker = new CargarTracker();
        TuAnyoEnPixeles tuAnyoEnPixeles = new TuAnyoEnPixeles();
        VerResumen verResumen = new VerResumen();
        ModificarDatos modificarDatos = new ModificarDatos();
        Salir salir = new Salir();

        int opcion = -1;

        do
        {
            do
            {
                menu.Dibujar();
                opcion = menu.CambiarOpcion();
            } while (opcion == -1);

            switch(opcion)
            {
                case 0: break;
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
            }
        } while (opcion != 5);

        salir.MostrarCreditos();
    }
}
