/**
 * IntroduccionHabitos.cs - Habit Tracker, Introducción de hábitos dentro de Nuevo Tracker
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.02, 06/05/2019:
 *          Mostrar texto para introducir hábito
 *          Guardar hábito en lista
 *          Preguntar si el usuario quiere introducir más hábitos
 *          Guardar hábitos en fichero de texto
 * 0.03, 13/05/2019:
 *          Heredar e implementar interfaz IMostrarPantalla
 *          Mejorar clases de dibujar pantalla
 *          Cambiar la confirmación por botones
 *          Escribir habitos con ASCII Art
 * 0.04, 15/05/2019:
 *          Comprobar si se puede seguir introduciendo hábitos por si no van a
 *          caber en pantalla (máximo 30 hábitos)
 *          Arreglar la escritura, no se mostraban bien las letras al
 *          introducir hábitos
 * 0.05, 16/05/2019:
 *          Cambiar color de verde a azul para mejorar la visibilidad
 *          Al añadir hábitos a la lista, se cambia el string con el nombre del
 *          hábito por el ToString del objeto Habito
 *          Bloque try-catch en la escritura de fichero
 * 0.06, 17/05/2019:
 *          Optimización del método EscribirHabito
 * 0.07, 20/05/2019:
 *          Eliminar la variable letras para que no dé fallo.
 *          En el método EscribirHabito, añadir como condicion que la tecla
 *          pulsada no sea Enter para que no lo registre
 *          En el método GuardarHabitos, pasar por referencia el parámetro
 *          numeroDeHabitos para poder utilizarlo en otras clases
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class IntroduccionHabitos : IPantallaMostrable
{
    protected string[] textoIntroducirHabitos;
    protected List<Habito> habitos;
    protected int opcion;
    protected string[] confirmacion;
    protected int ranura;

    public IntroduccionHabitos(int ranura)
    {
        this.ranura = ranura;
        opcion = 0;
        
        textoIntroducirHabitos = File.ReadAllLines(
            @"data\introducirHabito.txt");

        confirmacion = File.ReadAllLines(
            @"data\confirmacion.txt");

        habitos = new List<Habito>();
    }

    public void SeguirIntroduciendo()
    {
        Console.Clear();

        for (int i = 4; i < 12; i++)
        {
            Console.SetCursorPosition(15, i + 6);
            Console.WriteLine(textoIntroducirHabitos[i]);
        }

        Console.BackgroundColor = ConsoleColor.Black;

        DibujarOpcion(0, 4, 0);
        DibujarOpcion(4, 8, 1);

        Console.BackgroundColor = ConsoleColor.Black;

        Thread.Sleep(300);
    }

    public void GuardarHabitos(ref int numeroDeHabitos)
    {
        try
        {
            StreamWriter fichero = File.CreateText(@"data\ranura" + ranura + ".txt");
            for (int i = 0; i < habitos.Count; i++)
            {
                fichero.WriteLine(habitos[i]);
                numeroDeHabitos++;
            }
            fichero.Close();
        }
        catch (IOException)
        {
            Console.WriteLine("Ha habido un error");
            Environment.Exit(1);
        }
        catch (Exception exc)
        {
            Console.WriteLine("Error inesperado: " + exc.Message);
            Environment.Exit(1);
        }
    }

    public void DibujarOpcion(int yInicial, int yFinal, int opcionActual)
    {
        Utiles.DibujarOpcion(yInicial, yFinal, opcionActual);
    }

    public void Dibujar(int ranuraElegida)
    {
        Console.Clear();

        for (int i = 0; i < 4; i++)
        {
            Console.SetCursorPosition(7, i + 8);
            Console.WriteLine(textoIntroducirHabitos[i]);
        }

        EscribirHabito();
    }

    public int CambiarOpcion()
    {
        return Utiles.CambiarOpcion();
    }

    public void EscribirHabito()
    {
        int posicionX = 4;
        int posicionY = 15;
        string habito = "";

        ConsoleKeyInfo tecla;
        do
        {
            tecla = Console.ReadKey(true);
            
            if (tecla.Key != ConsoleKey.Enter && posicionX < 94 &&
                tecla.Key != ConsoleKey.Spacebar && posicionY <= 33)
            {
                char caracter = tecla.KeyChar;
                habito += caracter;

                Console.SetCursorPosition(posicionX, posicionY);
                Console.WriteLine(@" ____ ");
                Console.SetCursorPosition(posicionX, 1 + posicionY);
                Console.WriteLine(@"||" + caracter + " ||");
                Console.SetCursorPosition(posicionX, 2 + posicionY);
                Console.WriteLine(@"||__||");
                Console.SetCursorPosition(posicionX, 3 + posicionY);
                Console.WriteLine(@"|/__\|");

                posicionX += 6;
            }
        } while (tecla.Key != ConsoleKey.Enter);

        Habito habitoNuevo;
        habitoNuevo.nombre = habito;
        habitoNuevo.ranura = ranura;

        habitos.Add(habitoNuevo);
    }
}
