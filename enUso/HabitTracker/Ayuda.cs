/**
 * Ayuda.cs - Habit Tracker, Opción de ayuda
 * 
 * @author Adrián Navarro Gabino
 * 
 * Cambios:
 * 0.12, 29/05/2019:
 *          Método DibujarAyudaRanuras
 *          Método DibujarAyudaIntroducir
 *          Método DibujarAyudaSeguirIntroduciendo
 */

using System;

class Ayuda
{
    public static void DibujarAyudaRanuras()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"







                            ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine(@" _         _    _    ___ _  _  ___  ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("                            ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"/ |  ___  | |  | |  | __| \| |/ _ \ ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("                            ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"| | |___| | |__| |__| _|| .` | (_) |");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("                            ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"|_|       |____|____|___|_|\_|\___/ ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"



                             ___         _    _    ___ _  _  ___
                            |_  )  ___  | |  | |  | __| \| |/ _ \
                             / /  |___| | |__| |__| _|| .` | (_) |
                            /___|       |____|____|___|_|\_|\___/




                             ____       __   ___   ___ ___ ___
                            |__ /  ___  \ \ / /_\ / __|_ _/ _ \
                             |_ \ |___|  \ V / _ \ (__ | | (_) |
                            |___/         \_/_/ \_\___|___\___/");

        Console.SetCursorPosition(12, 6);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Muévete entre las opciones con las teclas ARRIBA y ABAJO");
        Console.SetCursorPosition(70, 19);
        Console.WriteLine("Selecciona una opción");
        Console.SetCursorPosition(70, 20);
        Console.WriteLine("con ENTER o ESPACIO");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void DibujarAyudaIntroducir()
    {
        Console.Clear();
        Console.WriteLine(@"







         ___     _               _                           _      __ _    _ _       _
        |_ _|_ _| |_ _ _ ___  __| |_  _ __ ___   _  _ _ _   | |_  _/_/| |__(_) |_ ___(_)
         | || ' \  _| '_/ _ \/ _` | || / _/ -_) | || | ' \  | ' \/ _` | '_ \ |  _/ _ \_
        |___|_||_\__|_| \___/\__,_|\_,_\__\___|  \_,_|_||_| |_||_\__,_|_.__/_|\__\___(_)");

        Console.SetCursorPosition(29, 17);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Escribe el hábito que quieres registrar");
        Console.SetCursorPosition(35, 20);
        Console.WriteLine("Guárdalo con ENTER");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void DibujarAyudaSeguirIntroduciendo()
    {
        Console.Clear();
        Console.Write(@"









                  _  ___                     _     _               _         _
                 (_)|   \ ___ ___ ___ __ _  (_)_ _| |_ _ _ ___  __| |_  _ __(_)_ _
                / /_| |) / -_|_-</ -_) _` | | | ' \  _| '_/ _ \/ _` | || / _| | '_|
                \___|___/\___/__/\___\__,_| |_|_||_\__|_| \___/\__,_|\_,_\__|_|_|
                             _             _      __ _    _ _      ___
                         ___| |_ _ _ ___  | |_  _/_/| |__(_) |_ __|__ \
                        / _ \  _| '_/ _ \ | ' \/ _` | '_ \ |  _/ _ \/_/
                        \___/\__|_| \___/ |_||_\__,_|_.__/_|\__\___(_)







                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(" ___ ___  ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("                               _  _  ___");
        Console.Write("                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@"/ __|_ _| ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                              | \| |/ _ \
                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@"\__ \| |  ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                              | .` | (_) |
                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@"|___/___| ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                              |_|\_|\___/");

        Console.SetCursorPosition(21, 23);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Muévete entre SÍ y NO con las teclas IZQUIERDA y DERECHA");
        Console.SetCursorPosition(30, 30);
        Console.WriteLine("Selecciona una opción con ENTER o ESPACIO");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
