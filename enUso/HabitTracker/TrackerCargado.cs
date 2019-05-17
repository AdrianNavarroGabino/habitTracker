

using System.IO;
/**
* TrackerCargado.cs - Habit Tracker, Tracker de la opción "cargar tracker"
* 
* @author Adrián Navarro Gabino
* 
* Cambios:
* 0.06, 17/05/2019:
*           Clase hereda de Tracker
*           Constructor con base
*/
class TrackerCargado : Tracker
{
    public TrackerCargado(int ranuraElegida) : base(ranuraElegida)
    {
        ranuras = File.ReadAllLines(@"data\ranuras.txt");
        ranuraVacia = new bool[3];

        for (int i = 0; i < 3; i++)
        {
            ranuraVacia[i] = File.Exists(@"data\ranura" + i + ".txt") ?
                false : true;
        }
    }
}
