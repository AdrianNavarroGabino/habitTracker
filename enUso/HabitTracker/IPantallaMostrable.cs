/**
 * IPantallaMostrable.cs - Habit Tracker, Interfaz para dibujar y cambiar
 *                       opciones en pantalla
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.03, 13/05/2019:
 *      Métodos DibujarOpcion, Dibujar y CambiarOpcion
 */

interface IPantallaMostrable
{
    void DibujarOpcion(int yInicial, int yFinal, int opcionActual);
    void Dibujar();
    int CambiarOpcion();
}
