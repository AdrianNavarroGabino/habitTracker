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
*/

class Habito
{
    protected string nombre;
    protected int ranura;

    public Habito(string nombre, int ranura)
    {
        this.nombre = nombre;
        this.ranura = ranura;
    }

    public string GetNombre() { return nombre; }
    public int GetRanura() { return ranura; }

    public void SetRanura(int ranura)
    {
        this.ranura = ranura;
    }

    public override string ToString()
    {
        return nombre;
    }
}
