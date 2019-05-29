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
 * 0.08, 22/05/2019:
 *          Mejorar constructor para que cree una lista nueva si no hay otra
 *          creada anteriormente
 *          Método CargarLista para leer la lista de comprobaciones existente
 *          de su fichero
 *          Método getter para la lista de comprobaciones
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
    int anyoActual;

    int claveDiccionario;
    int numeroDeHabitos;
    int ranuraElegida;
    int ultimoMesActualizado;

    public ListaDeComprobaciones(int numeroDeHabitos, int ranuraElegida)
    {
        this.numeroDeHabitos = numeroDeHabitos;
        this.ranuraElegida = ranuraElegida;

        if (!File.Exists(@"data\meses" + ranuraElegida + ".txt"))
        {
            listaDeComprobaciones = new SortedList<int, char[][]>();

            ahora = DateTime.Now;
            anyoActual = ahora.Year;

            claveDiccionario = GenerarClave(anyoActual, ahora.Month);

            casillas = CrearMesVacio(DateTime.DaysInMonth(anyoActual, ahora.Month));
            listaDeComprobaciones.Add(claveDiccionario, casillas);
            ultimoMesActualizado = claveDiccionario;
            
            try
            {
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
            catch (PathTooLongException)
            {
                Console.WriteLine("Ruta demasiado larga");
            }
            catch (IOException)
            {
                Console.WriteLine("IO error");
            }
            catch (Exception)
            {
                Console.WriteLine("Excepción");
            }
        }
        else
        {
            listaDeComprobaciones = CargarLista();
        }
    }

    public SortedList<int, char[][]> GetListaDeComprobaciones()
    {
        return listaDeComprobaciones;
    }

    public void ActualizarLista(ref int ultimaClave)
    {
        
        DateTime hoy = DateTime.Now;
        int ultimoMes, ultimoAnyo;
        DescrifrarClave(out ultimoAnyo, out ultimoMes, ultimaClave);

        int claveSiguiente = ultimoMes == 12 ?
            GenerarClave(ultimoAnyo + 1, 1) :
            GenerarClave(ultimoAnyo, ultimoMes + 1);

        for(int i = claveSiguiente; i <= GenerarClave(hoy.Year, hoy.Month); i++)
        {
            if(i % 100 == 13)
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

    public SortedList<int, char[][]> CargarLista()
    {
        int numeroDeHabitos =
            File.ReadAllLines(@"data\ranura" + ranuraElegida + ".txt").Length;
        string[] datos = File.ReadAllLines(@"data\meses" + ranuraElegida + ".txt");
        SortedList<int, char[][]> listaDeComprobaciones = new SortedList<int, char[][]>();

        for (int i = 0; i < datos.Length / (numeroDeHabitos + 1); i++)
        {
            char[][] casillasAux = new char[numeroDeHabitos][];

            for(int j = 0; j < numeroDeHabitos; j++)
            {
                casillasAux[j] = new char[datos[i + j + 1].Length];

                for(int k = 0; k < datos[i + j + 1].Length; k++)
                {
                    casillasAux[j][k] = datos[i + j + 1][k];
                }
            }

            listaDeComprobaciones.Add(Convert.ToInt32(datos[i]), casillasAux);
        }

        return listaDeComprobaciones;
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
                casillas[i][j] = '-';
            }
        }

        return casillas;
    }

    public void AnyadirComprobacion(int dia, int mes, bool hecho)
    {
        casillas[mes - 1][dia - 1] = hecho ? 'X' : 'O';
    }
}
