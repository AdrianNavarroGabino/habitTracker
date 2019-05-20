/**
 * ListaDeComprobaciones.cs - Habit Tracker,
 *    Clase para comprobar si cada hábito se ha realizado o no
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.07, 20/05/2019:
 *          Declaración de todas las variables necesarias relacionadas
 *          con la fecha
 *          Declaracion de la SortedList en la que almacenare la información
 *          mensual de cada comprobación
 *          Constructor:
 *              Inicialización de la SortedList
 *              Poner en el mes actual, que será el primer mes del tracker,
 *              todos los hábitos en blanco y guardar en la SortedList
 *              y en el fichero de texto el mes actual
 *          Método CrearMesVacio para crear una tabla de hábitos en blanco
 *          para el año y mes introducidos
 *          Métodos GenerarClave y DescifrarClave para, dados el mes y el año,
 *          generar la clave del diccionario o, dada la clave,
 *          extraer el mes y el año
 *          Método GuardarLista para guardar en un fichero todos los elementos de
 *          la SortedList
 *          Método ActualizarLista para generar meses vacíos desde el último mes 
 *          introducido hasta el actual
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class ListaDeComprobaciones
{
    // La clave será YYYYMM y el valor será el array con el que se indica
    // si se ha realizado el hábito cada día
    SortedList<int, char[][]> listaDeComprobaciones;

    char[][] casillas;

    DateTime ahora;
    string mesActual;
    int anyoActual;

    int claveDiccionario;
    int numeroDeHabitos;
    int ranuraElegida;
    int ultimoMesActualizado;

    public ListaDeComprobaciones(int numeroDeHabitos, int ranuraElegida)
    {
        this.numeroDeHabitos = numeroDeHabitos;
        this.ranuraElegida = ranuraElegida;
        listaDeComprobaciones = new SortedList<int, char[][]>();

        ahora = DateTime.Now;
        anyoActual = ahora.Year;

        claveDiccionario = GenerarClave(anyoActual, ahora.Month);

        casillas = CrearMesVacio(DateTime.DaysInMonth(anyoActual, ahora.Month));
        listaDeComprobaciones.Add(claveDiccionario, casillas);
        ultimoMesActualizado = claveDiccionario;

        StreamWriter habitosCumplidos = new StreamWriter(@"data\meses" + ranuraElegida + ".txt");
        habitosCumplidos.WriteLine(claveDiccionario);
        for (int i = 0; i < numeroDeHabitos; i++)
        {
            for (int j = 0; j < DateTime.DaysInMonth(anyoActual, ahora.Month); j++)
            {
                habitosCumplidos.Write(casillas[i][j]);
            }
            habitosCumplidos.WriteLine();
        }
        habitosCumplidos.Close();
    }

    public void ActualizarLista(ref int ultimaClave)
    {
        DateTime hoy = DateTime.Now;
        int ultimoMes, ultimoAnyo;
        DescrifrarClave(out ultimoAnyo, out ultimoMes, ultimaClave);

        int claveSiguiente = ultimoMes == 12 ?
            GenerarClave(ultimoAnyo + 1, 1) :
            GenerarClave(ultimoAnyo, ultimoMes + 1);

        for(int i = claveSiguiente; i <= GenerarClave(hoy.Year, hoy.Year); i++)
        {
            if(i == 13)
            {
                i = i - 12 + 100;
            }

            DescrifrarClave(out ultimoAnyo, out ultimoMes, i);

            casillas = CrearMesVacio(
                DateTime.DaysInMonth(ultimoAnyo, ultimoMes));

            listaDeComprobaciones.Add(i, casillas);
            ultimoMesActualizado = i;
        }

        GuardarLista();
    }

    public void GuardarLista()
    {
        StreamWriter habitosCumplidos = new StreamWriter(@"data\meses" + ranuraElegida + ".txt");
        foreach ( KeyValuePair<int,char[][]> mes in listaDeComprobaciones )
        {
            habitosCumplidos.WriteLine(mes.Key);
            for (int i = 0; i < mes.Value.Length; i++)
            {
                for (int j = 0; j < mes.Value[i].Length; j++)
                {
                    habitosCumplidos.Write(mes.Value[i][j]);
                }
                habitosCumplidos.WriteLine();
            }
        }
        habitosCumplidos.Close();
    }

    public int GenerarClave(int anyo, int mes)
    {
        return Convert.ToInt32(anyo +
            (mes < 10 ? "0" + mes : "" + mes));
    }

    public void DescrifrarClave(out int anyo, out int mes, int clave)
    {
        anyo = clave / 100;
        mes = clave % 100;
    }
    
    public char[][] CrearMesVacio(int numeroDeDias)
    {
        casillas = new char[numeroDeDias][];

        for (int i = 0; i < numeroDeHabitos; i++)
        {
            casillas[i] = new char[numeroDeDias];

            for (int j = 0; j < numeroDeDias; j++)
            {
                casillas[i][j] = ' ';
            }
        }

        return casillas;
    }
}
