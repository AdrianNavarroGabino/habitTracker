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
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class IntroducirHabitos
{
    protected string[] textoIntroducirHabitos;
    protected List<string> habitos;
    protected int opcion;
    protected string confirmacion;

    public IntroducirHabitos(int opcion)
    {
        this.opcion = opcion;
        
        textoIntroducirHabitos = File.ReadAllLines(
            @"data\introducirHabito.txt");

        habitos = new List<string>();
    }

    public void IntroducirHabito()
    {
        Console.Clear();

        for(int i = 0; i < 4; i++)
        {
            Console.SetCursorPosition(7, i + 8);
            Console.WriteLine(textoIntroducirHabitos[i]);
        }

        Console.SetCursorPosition(25, 20);
        habitos.Add(Console.ReadLine());
    }

    public bool SeguirIntroduciendo()
    {
        Console.Clear();

        for (int i = 4; i < 12; i++)
        {
            Console.SetCursorPosition(15, i + 6);
            Console.WriteLine(textoIntroducirHabitos[i]);
        }

        Console.SetCursorPosition(47, 25);
        confirmacion = Console.ReadLine();

        Regex r = new Regex(@"\A[sSyY]([a-zA-Z])?\z");

        if (r.IsMatch(confirmacion))
            return true;
        else
            return false;
    }

    public void GuardarHabitos()
    {
        StreamWriter fichero = File.CreateText(@"data\ranura" + opcion + ".txt");
        for(int i = 0; i < habitos.Count; i++)
        {
            fichero.WriteLine(habitos[i]);
        }
        fichero.WriteLine(new string('/', 10));
        fichero.Close();
    }
}
