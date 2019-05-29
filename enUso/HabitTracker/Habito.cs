/**
* Habito.cs - Habit Tracker, Información de cada hábito
* 
* @author Adrián Navarro Gabino
* 
* Cambios:
* 0.05, 16/05/2019:
*          Creación de la clase
*          Constructor
*          Getters y setters
*          ToString
* 0.12, 29/05/2019:
*          Cambio a struct
*/

public struct Habito
{
    public string nombre;
    public int ranura;

    public override string ToString()
    {
        return nombre;
    }
}
