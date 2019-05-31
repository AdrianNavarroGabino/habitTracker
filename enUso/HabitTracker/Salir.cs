/**
 * Salir.cs - Habit Tracker, Opción "salir"
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.01, 17/04/2019: Mostrar pantalla de créditos
 */

using System;
using System.IO;
using System.Threading;

class Salir
{
    public void MostrarCreditos()
    {
        string[] creditos = File.ReadAllLines(@"data\creditos.txt");

        Console.Clear();

        for(int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(3, i + 1);
            Console.WriteLine(creditos[i]);
        }
        for(int i = 5; i < 11; i++)
        {
            Console.SetCursorPosition(10, i + 6);
            Console.WriteLine(creditos[i]);
        }
        for (int i = 11; i < 17; i++)
        {
            Console.SetCursorPosition(6, i + 6);
            Console.WriteLine(creditos[i]);
        }
        for (int i = 17; i < 23; i++)
        {
            Console.SetCursorPosition(12, i + 6);
            Console.WriteLine(creditos[i]);
        }

        Thread.Sleep(4000);

        Console.Clear();

        Environment.Exit(1);
    }
}