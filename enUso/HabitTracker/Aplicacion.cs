/**
 * VerResumen.cs - Habit Tracker, Clase desde la que ejecutar la aplicación
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.05, 16/05/2019:
 *          Llamar a la clase HabitTracker para ejecutar la aplicación
 */

class Aplicacion
{
    static void Main()
    {
        HabitTracker habitTracker = new HabitTracker();
        habitTracker.Ejecutar();
    }
}
