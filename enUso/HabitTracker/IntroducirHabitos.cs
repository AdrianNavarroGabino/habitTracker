/**
 * IntroducirHabitos.cs - Habit Tracker, Introducción de hábitos dentro de Nuevo Tracker
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
 *          Arreglar la escritura, no se mostraban bien las letras al introducir hábitos
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

class IntroducirHabitos : IMostrarPantalla
{
    protected string[] textoIntroducirHabitos;
    protected List<string> habitos;
    protected int opcion;
    protected string[] confirmacion;
    protected int ranura;
    protected string[] letras;

    public IntroducirHabitos(int ranura)
    {
        this.ranura = ranura;
        opcion = 0;
        
        textoIntroducirHabitos = File.ReadAllLines(
            @"data\introducirHabito.txt");

        confirmacion = File.ReadAllLines(
            @"data\confirmacion.txt");

        letras = File.ReadAllLines(
            @"data\letras.txt");

        habitos = new List<string>();
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

    public void GuardarHabitos()
    {
        StreamWriter fichero = File.CreateText(@"data\ranura" + ranura + ".txt");
        for(int i = 0; i < habitos.Count; i++)
        {
            fichero.WriteLine(habitos[i]);
        }
        fichero.Close();
    }

    public void DibujarOpcion(int yInicial, int yFinal, int opcionActual)
    {
        if (opcion == opcionActual)
        {
            Console.BackgroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        for (int i = yInicial; i < yFinal; i++)
        {
            Console.SetCursorPosition(20 + yInicial * 10, i - yInicial + 25);
            Console.WriteLine(confirmacion[i]);
        }
    }

    public void Dibujar()
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
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.RightArrow ||
            tecla.Key == ConsoleKey.LeftArrow)
        {
            opcion = (opcion + 1) % 2;
        }
        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
        {
            if (opcion == 0 && habitos.Count < 30)
                return 0;
            return 1;
        }

        return -1;
    }

    public void EscribirHabito()
    {
        int posicionX = 4;
        int posicionY = 15;
        string habito = "";
        int indiceDeLetra = -1;

        ConsoleKeyInfo tecla;
        do
        {
            tecla = Console.ReadKey(true);
            switch (tecla.Key)
            {
                case ConsoleKey.A:
                    indiceDeLetra = 0;
                    habito += "A";
                    break;
                case ConsoleKey.B:
                    indiceDeLetra = 4;
                    habito += "B";
                    break;
                case ConsoleKey.C:
                    indiceDeLetra = 8;
                    habito += "C";
                    break;
                case ConsoleKey.D:
                    indiceDeLetra = 12;
                    habito += "D";
                    break;
                case ConsoleKey.E:
                    indiceDeLetra = 16;
                    habito += "E";
                    break;
                case ConsoleKey.F:
                    indiceDeLetra = 20;
                    habito += "F";
                    break;
                case ConsoleKey.G:
                    indiceDeLetra = 24;
                    habito += "G";
                    break;
                case ConsoleKey.H:
                    indiceDeLetra = 28;
                    habito += "H";
                    break;
                case ConsoleKey.I:
                    indiceDeLetra = 32;
                    habito += "I";
                    break;
                case ConsoleKey.J:
                    indiceDeLetra = 36;
                    habito += "J";
                    break;
                case ConsoleKey.K:
                    indiceDeLetra = 40;
                    habito += "K";
                    break;
                case ConsoleKey.L:
                    indiceDeLetra = 44;
                    habito += "L";
                    break;
                case ConsoleKey.M:
                    indiceDeLetra = 48;
                    habito += "M";
                    break;
                case ConsoleKey.N:
                    indiceDeLetra = 52;
                    habito += "N";
                    break;
                case ConsoleKey.O:
                    indiceDeLetra = 56;
                    habito += "O";
                    break;
                case ConsoleKey.P:
                    indiceDeLetra = 60;
                    habito += "P";
                    break;
                case ConsoleKey.Q:
                    indiceDeLetra = 64;
                    habito += "Q";
                    break;
                case ConsoleKey.R:
                    indiceDeLetra = 68;
                    habito += "R";
                    break;
                case ConsoleKey.S:
                    indiceDeLetra = 72;
                    habito += "S";
                    break;
                case ConsoleKey.T:
                    indiceDeLetra = 76;
                    habito += "T";
                    break;
                case ConsoleKey.U:
                    indiceDeLetra = 80;
                    habito += "U";
                    break;
                case ConsoleKey.V:
                    indiceDeLetra = 84;
                    habito += "V";
                    break;
                case ConsoleKey.W:
                    indiceDeLetra = 88;
                    habito += "W";
                    break;
                case ConsoleKey.X:
                    indiceDeLetra = 92;
                    habito += "X";
                    break;
                case ConsoleKey.Y:
                    indiceDeLetra = 96;
                    habito += "Y";
                    break;
                case ConsoleKey.Z:
                    indiceDeLetra = 100;
                    habito += "Z";
                    break;
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Spacebar:
                    posicionX = 4;
                    posicionY += 6;
                    break;
                default:
                    indiceDeLetra = 104;
                    habito += "?";
                    break;
            }
            if (posicionX < 94 && tecla.Key != ConsoleKey.Spacebar && posicionY <= 33)
            {
                for (int i = indiceDeLetra; i < indiceDeLetra + 4; i++)
                {
                    Console.SetCursorPosition(posicionX, i - indiceDeLetra + posicionY);
                    Console.WriteLine(letras[i]);
                }
                posicionX += 6;
            }
        } while (tecla.Key != ConsoleKey.Enter);

        habitos.Add(habito);
    }
}
