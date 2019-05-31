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
 * 0.13, 30/05/2019:
 *          Método DibujarAyudaTracker
 *          Método DibujarAyudaEligeUnHabito
 *          Método DibujarAyudaEligeUnDia
 *          Método DibujarAyudaLoHasHecho
 *          Método DibujarAyudaTrackerCargado
 *          Método Esperar
 *          Método MostrarAyuda
 * 0.14, 31/05/2019:
 *          Corregir método Esperar para que continue tras 10 segundos
 *          aunque no se pulse ninguna tecla
 */

using System;
using System.Threading;

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
        Console.SetCursorPosition(5, 3);
        Console.WriteLine("Puedes volver pulsando ESC");
        Console.ResetColor();

        Esperar();
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
        Console.ResetColor();

        Esperar();
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
        Console.ResetColor();

        Esperar();
    }

    public static void DibujarAyudaTracker()
    {
        Console.Clear();
        Console.Write(@"                      __  __   ___   _____                      ___     __     _     ___
                     |  \/  | /_\ \ / / _ \                    |_  )   /  \   / |   / _ \
                     | |\/| |/ _ \ V / (_) |                    / /   | () |  | |   \_, /
                     |_|  |_/_/ \_\_| \___/                    /___|   \__/   |_|    /_/
  
                      ______________________________________________________________
  correr              |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  nadar               |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  montar en bici      |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  comer sano          |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
           ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("ACTUALIZAR");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("               ACTUALIZAR HOY           BORRAR TRACKER           VOLVER");

        Console.SetCursorPosition(7, HabitTracker.ALTO_PANTALLA - 4);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Muévete entre las opciones con las teclas IZQUIERDA y DERECHA");
        Console.SetCursorPosition(30, HabitTracker.ALTO_PANTALLA - 6);
        Console.WriteLine("Selecciona una opción con ENTER o ESPACIO");
        Console.ResetColor();

        Esperar();
    }

    public static void DibujarAyudaEligeUnHabito()
    {
        Console.Clear();
        Console.Write(@"


               ___ _    ___ ___ ___   _   _ _  _   _  _   _   ___ ___ _____ ___
              | __| |  |_ _/ __| __| | | | | \| | | || | /_\ | _ )_ _|_   _/ _ \
              | _|| |__ | | (_ | _|  | |_| | .` | | __ |/ _ \| _ \| |  | || (_) |
              |___|____|___\___|___|  \___/|_|\_| |_||_/_/ \_\___/___| |_| \___/





                                               ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@"correr");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"

                                                nadar

                                            montarenbici

                                              comersano");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(10, 12);
        Console.WriteLine("Muévete entre las opciones con");
        Console.SetCursorPosition(10, 13);
        Console.WriteLine("las teclas IZQUIERDA y DERECHA");
        Console.SetCursorPosition(60, 15);
        Console.WriteLine("Selecciona el hábito que quieres");
        Console.SetCursorPosition(60, 16);
        Console.WriteLine("actualizar con ENTER o ESPACIO");
        Console.ResetColor();

        Esperar();
    }

    public static void DibujarAyudaEligeUnDia()
    {
        Console.Clear();
        Console.Write(@"


                         ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _
                        | __| |  |_ _/ __| __| | | | | \| | |   \_ _| /_\ (_)
                        | _|| |__ | | (_ | _|  | |_| | .` | | |) | | / _ \ _
                        |___|____|___\___|___|  \___/|_|\_| |___/___/_/ \_(_)



                ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("1");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                   11                  21                  31


                2                   12                  22


                3                   13                  23


                4                   14                  24


                5                   15                  25


                6                   16                  26


                7                   17                  27


                8                   18                  28


                9                   19                  29


                10                  20                  30");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(10, 7);
        Console.WriteLine("Muévete entre las opciones con las teclas");
        Console.SetCursorPosition(10, 8);
        Console.WriteLine("IZQUIERDA, DERECHA, ARRIBA y ABAJO");
        Console.SetCursorPosition(65, 15);
        Console.WriteLine("Selecciona el día que quieres");
        Console.SetCursorPosition(65, 16);
        Console.WriteLine("actualizar con ENTER o ESPACIO");
        Console.ResetColor();

        Esperar();
    }

    public static void DibujarAyudaLoHasHecho()
    {
        Console.Clear();
        Console.Write(@"


                      _  _    ___    _  _   _   ___   _  _ ___ ___ _  _  ___ ___
                     (_)| |  / _ \  | || | /_\ / __| | || | __/ __| || |/ _ \__ \
                    / /_| |_| (_) | | __ |/ _ \\__ \ | __ | _| (__| __ | (_) |/_/
                    \___|____\___/  |_||_/_/ \_\___/ |_||_|___\___|_||_|\___/(_)













                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@" ___ ___ ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                                         _  _  ___
                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@"/ __|_ _|");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                                        | \| |/ _ \
                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@"\__ \| | ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                                        | .` | (_) |
                     ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(@"|___/___|");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"                                        |_|\_|\___/");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(10, HabitTracker.ALTO_PANTALLA / 2 - 3);
        Console.WriteLine("Muévete entre las opciones con las teclas IZQUIERDA y DERECHA");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 2 -
            "Selecciona si has realizado o no".Length / 2,
            HabitTracker.ALTO_PANTALLA / 2 + 7);
        Console.WriteLine("Selecciona si has realizado o no");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 2 -
            "Selecciona si has realizado o no".Length / 2,
            HabitTracker.ALTO_PANTALLA / 2 + 8);
        Console.WriteLine("el hábito con ENTER o ESPACIO");
        Console.ResetColor();

        Esperar();
    }

    public static void DibujarAyudaTrackerCargado()
    {
        Console.Clear();
        Console.Write(@"                      __  __   ___   _____                      ___     __     _     ___
                     |  \/  | /_\ \ / / _ \                    |_  )   /  \   / |   / _ \
                     | |\/| |/ _ \ V / (_) |                    / /   | () |  | |   \_, /
                     |_|  |_/_/ \_\_| \___/                    /___|   \__/   |_|    /_/
  
                      ______________________________________________________________
  correr              |");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write(@"_");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(@"|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  nadar               |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  montar en bici      |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  comer sano          |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
           ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("ACTUALIZAR");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("               ACTUALIZAR HOY           BORRAR TRACKER           VOLVER");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(23, 7);
        Console.WriteLine("^");
        for(int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(23, 8 + i);
            Console.WriteLine("|");
        }
        Console.SetCursorPosition(23 -
            "Aquí aparece el día y el hábito seleccionados".Length / 2, 13);
        Console.WriteLine("Aquí aparece el día y el hábito seleccionados");
        Console.SetCursorPosition(23 -
            "con la casilla cambiada a verde".Length / 2, 14);
        Console.WriteLine("con la casilla cambiada a verde");
        Console.ResetColor();

        Esperar();
    }

    public static void Esperar()
    {
        int indice = 0;
        while (Console.KeyAvailable == false && indice < 10)
        {
            Thread.Sleep(1000);
            indice++;
        }
        if(indice < 9)
            Console.ReadKey();
    }

    public static void MostrarAyuda()
    {
        Ayuda.DibujarAyudaRanuras();
        Ayuda.DibujarAyudaIntroducir();
        Ayuda.DibujarAyudaSeguirIntroduciendo();
        Ayuda.DibujarAyudaTracker();
        Ayuda.DibujarAyudaEligeUnHabito();
        Ayuda.DibujarAyudaEligeUnDia();
        Ayuda.DibujarAyudaLoHasHecho();
        Ayuda.DibujarAyudaTrackerCargado();
    }
}
