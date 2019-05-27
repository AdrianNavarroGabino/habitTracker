/**
* TuAnyoEnPixeles.cs - Habit Tracker, Opción "tu año en píxeles"
* 
* @author Adrián Navarro Gabino
* 
* Cambios:
* 0.09, 23/05/2019:
*           Creación de la clase
*           Creación del constructor en el que, si no se ha creado antes,
*           se crea la lista de comprobaciones dentro del año y se guarda
*           en un fichero y, si el fichero ya existe, se cargan los datos
*           al array de comprobaciones
*           Crear getters para el año actual y la lista de comprobaciones
*           Método DibujarTabla que comprueba cada día de cada mes para
*           poner la celda de esa tabla en negro, verde o rojo dependiendo
*           de si no se han introducido datos, o si ese día fue bueno o malo
*           Método Dibujar que dibuja el año actual con ASCII ART como cabecera
*           Método DibujarOpciones, que escribe las opciones en el final de la
*           pantalla, aún no están operativos.
* 0.10, 24/05/2019:
*           Mejorar métodos DibujarOpcion y CambiarOpcion
*           Método DibujarPortadaMeses
*           Método DibujarMeses
*           Método CambiarOpcionMes
*           Método DibujarPortadaDias
*           Método DibujarDias
*           Método CambiarOpcionDias
*           Métodos DibujarPortadaBuenDiaParte1 y DibujarPortadaBuenDiaParte2
*           Método EsUnBuenDia
*           Método Actualizar, que utiliza los métodos anteriores para
*           preguntar qué año se quiere modificar, qué día y preguntar
*           si el día elegido ha sido bueno o no.
*           Método ActualizarHoy para mejorar la usabilidad y poder actualizar
*           directamente el día actual
* 0.11, 27/05/2019:
*          Corregir errores de dibujado
*          Confirmar la actualización de la tabla con los botones de SÍ y NO
*          Cambiar array con los resultados de la tabla para volver a pintarla
*          actualizada
*          Añadir opción de borrar
*          Hacer la opción de borrar operativa
*          No salir de la opción Tu año en píxeles hasta que no se seleccione
*          la opción de volver
*/

using System;
using System.IO;

class TuAnyoEnPixeles
{
    protected int anyoActual;
    protected string[] comprobaciones;
    protected string[] datosComprobaciones;
    protected int opcion;
    protected string[] opciones = { "ACTUALIZAR", "ACTUALIZAR HOY", "BORRAR", "VOLVER" };
    public const int ACTUALIZAR = 0;
    public const int ACTUALIZAR_HOY = 1;
    public const int BORRAR = 2;
    public const int VOLVER = 3;

    public TuAnyoEnPixeles()
    {
        anyoActual = DateTime.Now.Year;
        comprobaciones = new string[12];
        opcion = 0;

        if (!File.Exists(@"data\anyo.txt"))
        {
            for(int i = 1; i <= 12; i++)
            {
                comprobaciones[i - 1] = new string('-', DateTime.DaysInMonth(anyoActual, i));
            }

            File.WriteAllLines(@"data\anyo.txt", comprobaciones);
        }
        else
        {
            datosComprobaciones = File.ReadAllLines(@"data\anyo.txt");

            for(int i = 0; i < 12; i++)
            {
                comprobaciones[i] = datosComprobaciones[i];
            }
        }
    }

    public int GetAnyoActual() { return anyoActual; }
    public string[] GetComprobaciones() { return comprobaciones; }
    public int GetNumeroDeOpciones() { return opciones.Length; }

    public void Dibujar()
    {
        Console.Clear();
        
        Utiles.DibujarAnyo("" + anyoActual, HabitTracker.ANCHO_PANTALLA / 2 - 14);
        DibujarTabla();
    }

    public void DibujarTabla()
    {
        for (int i = 0; i < 12; i++)
        {
            Console.SetCursorPosition(17, 8 + i * 2);
            Console.WriteLine(new string('_', DateTime.DaysInMonth(anyoActual, i + 1) * 2 + 1));

            Console.SetCursorPosition(2, i * 2 + 9);
            Console.Write(Utiles.mes[i].Substring(0, 1).ToUpper() + Utiles.mes[i].Substring(1));
            for (int j = 0; j < DateTime.DaysInMonth(anyoActual, i + 1); j++)
            {
                Console.SetCursorPosition(17 + j * 2, i * 2 + 9);
                Console.Write("|");
                if (comprobaciones[i][j] == 'O')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (comprobaciones[i][j] == 'X')
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.SetCursorPosition(18 + j * 2, i * 2 + 9);
                Console.Write("_");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(19 + j * 2, i * 2 + 9);
            }
            Console.Write("|");
        }
    }

    public void DibujarOpcion(int opcionActual)
    {
        int numeroDeOpciones = opciones.Length;

        int separacion = HabitTracker.ANCHO_PANTALLA / (numeroDeOpciones + 1);

        
        Console.SetCursorPosition(separacion * (opcionActual + 1) - (opciones[opcionActual].Length / 2),
            HabitTracker.ALTO_PANTALLA - 3);
        if(opcion == opcionActual)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        Console.WriteLine(opciones[opcionActual]);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public int CambiarOpcion()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.RightArrow)
        {
            opcion = (opcion + 1) % opciones.Length;
        }
        if(tecla.Key == ConsoleKey.LeftArrow)
        {
            if (opcion != 0)
                opcion--;
            else
                opcion = opciones.Length - 1;
        }

        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            return opcion;

        return -1;
    }

    public void Actualizar()
    {
        int mes, dia;
        opcion = 0;

        DibujarPortadaMeses();

        do
        {
            for (int i = 0; i < 12; i++)
            {
                DibujarMeses(i);
            }
            mes = CambiarOpcionMes();
        } while (mes == -1);

        opcion = 1;

        DibujarPortadaDias();

        do
        {
            for(int i = 1; i <= DateTime.DaysInMonth(2019,mes + 1); i++)
            {
                DibujarDias(i, i / 10);
            }
            dia = CambiarOpcionDia(DateTime.DaysInMonth(2019, mes + 1));
        } while (dia == -1);

        int actualizar = EsUnBuenDia();
        
        comprobaciones[mes] =
            comprobaciones[mes].Substring(0, dia - 1) +
            (actualizar == 0 ? "X" : "O") +
            comprobaciones[mes].Substring(dia);
        File.WriteAllLines(@"data\anyo.txt", comprobaciones);
    }

    public void DibujarPortadaMeses()
    {
        Console.Clear();

        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   __  __ ___ ___ _ ".Length /
            2), 3);
        Console.WriteLine(@"  ___ _    ___ ___ ___   _   _ _  _   __  __ ___ ___ _ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   __  __ ___ ___ _ ".Length /
            2), 4);
        Console.WriteLine(@" | __| |  |_ _/ __| __| | | | | \| | |  \/  | __/ __(_)");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   __  __ ___ ___ _ ".Length /
            2), 5);
        Console.WriteLine(@" | _|| |__ | | (_ | _|  | |_| | .` | | |\/| | _|\__ \_ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   __  __ ___ ___ _ ".Length /
            2), 6);
        Console.WriteLine(@" |___|____|___\___|___|  \___/|_|\_| |_|  |_|___|___(_)");
    }

    public void DibujarMeses(int opcionActual)
    {
        if(opcionActual == opcion)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 2 - Utiles.mes[opcionActual].Length / 2, opcionActual * 2 + 12);
        Console.WriteLine(Utiles.mes[opcionActual].Substring(0, 1).ToUpper() + Utiles.mes[opcionActual].Substring(1));
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public int CambiarOpcionMes()
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        if (tecla.Key == ConsoleKey.DownArrow)
        {
            opcion = (opcion + 1) % 12;
        }
        if (tecla.Key == ConsoleKey.UpArrow)
        {
            if (opcion == 0)
            {
                opcion = 11;
            }
            else
            {
                opcion--;
            }
        }

        if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            return opcion;

        return -1;
    }

    public void DibujarPortadaDias()
    {
        Console.Clear();

        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 3);
        Console.WriteLine(@"  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 4);
        Console.WriteLine(@" | __| |  |_ _/ __| __| | | | | \| | |   \_ _| /_\ (_)");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 5);
        Console.WriteLine(@" | _|| |__ | | (_ | _|  | |_| | .` | | |) | | / _ \ _ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _    ___ ___ ___   _   _ _  _   ___ ___   _   _ ".Length /
            2), 6);
        Console.WriteLine(@" |___|____|___\___|___|  \___/|_|\_| |___/___/_/ \_(_)");
    }

    public void DibujarDias(int opcionActual, int decenas)
    {
        if (opcionActual == opcion)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        if(opcionActual % 10 == 0)
            Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 5 *
                (decenas - 1) + HabitTracker.ANCHO_PANTALLA / 6,
                (opcionActual - 1) % 10 * 3 + 10);
        else
            Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 5 *
                decenas + HabitTracker.ANCHO_PANTALLA / 6,
                (opcionActual - 1) % 10 * 3 + 10);
        Console.WriteLine(opcionActual);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public int CambiarOpcionDia(int numeroDeDias)
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        switch (tecla.Key)
        {
            case ConsoleKey.DownArrow:
                if (opcion == numeroDeDias)
                    opcion = 1;
                else
                    opcion++;
                break;
            case ConsoleKey.UpArrow:
                if (opcion == 1)
                    opcion = numeroDeDias;
                else
                    opcion--;
                break;
            case ConsoleKey.RightArrow:
                if (((opcion - 1) / 10) == (numeroDeDias / 10))
                    opcion %= 10;
                else
                {
                    if (opcion + 10 <= numeroDeDias)
                        opcion += 10;
                    else
                        opcion = numeroDeDias;
                }
                break;
            case ConsoleKey.LeftArrow:
                if ((opcion - 1) / 10 == 0)
                {
                    if (opcion + numeroDeDias / 10 * 10 >= numeroDeDias)
                        opcion = numeroDeDias;
                    else
                        opcion = opcion + numeroDeDias / 10 * 10;
                }
                else
                    opcion -= 10;
                break;
            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                return opcion;
        }

        return -1;
    }

    public void DibujarPortadaBuenDiaParte1()
    {
        Console.Clear();

        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _  _   _     ___ ___ ___   ___    _   _ _  _ ".Length /
            2), 3);
        Console.WriteLine(@"   _  _  _   _     ___ ___ ___   ___    _   _ _  _ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _  _   _     ___ ___ ___   ___    _   _ _  _ ".Length /
            2), 4);
        Console.WriteLine(@"  (_)| || | /_\   / __|_ _|   \ / _ \  | | | | \| |");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _  _   _     ___ ___ ___   ___    _   _ _  _ ".Length /
            2), 5);
        Console.WriteLine(@" / /_| __ |/ _ \  \__ \| || |) | (_) | | |_| | .` |");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("   _  _  _   _     ___ ___ ___   ___    _   _ _  _ ".Length /
            2), 6);
        Console.WriteLine(@" \___|_||_/_/ \_\ |___/___|___/ \___/   \___/|_|\_|");
    }

    public void DibujarPortadaBuenDiaParte2()
    {
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _   _ ___ _  _   ___ ___   _  ___ ".Length /
            2), 8);
        Console.WriteLine(@"  ___ _   _ ___ _  _   ___ ___   _  ___ ");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _   _ ___ _  _   ___ ___   _  ___ ".Length /
            2), 9);
        Console.WriteLine(@" | _ ) | | | __| \| | |   \_ _| /_\|__ \");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _   _ ___ _  _   ___ ___   _  ___ ".Length /
            2), 10);
        Console.WriteLine(@" | _ \ |_| | _|| .` | | |) | | / _ \ /_/");
        Console.SetCursorPosition(
            HabitTracker.ANCHO_PANTALLA / 2 -
            ("  ___ _   _ ___ _  _   ___ ___   _  ___ ".Length /
            2), 11);
        Console.WriteLine(@" |___/\___/|___|_|\_| |___/___/_/ \_(_) ");
    }

    public static void DibujarSiYNo(int opcionActual)
    {
        if(opcionActual == 0)
            Console.BackgroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 -
            ("  ___ ___ ".Length / 2), HabitTracker.ALTO_PANTALLA / 2);
        Console.WriteLine(@"  ___ ___ ");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 -
            ("  ___ ___ ".Length / 2), HabitTracker.ALTO_PANTALLA / 2 + 1);
        Console.WriteLine(@" / __|_ _|");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 -
            ("  ___ ___ ".Length / 2), HabitTracker.ALTO_PANTALLA / 2 + 2);
        Console.WriteLine(@" \__ \| | ");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 -
            ("  ___ ___ ".Length / 2), HabitTracker.ALTO_PANTALLA / 2 + 3);
        Console.WriteLine(@" |___/___|");
        Console.BackgroundColor = ConsoleColor.Black;

        if (opcionActual == 1)
            Console.BackgroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 * 3 -
            ("  _  _  ___  ".Length / 2), HabitTracker.ALTO_PANTALLA / 2);
        Console.WriteLine(@"  _  _  ___  ");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 * 3 -
            ("  _  _  ___  ".Length / 2), HabitTracker.ALTO_PANTALLA / 2 + 1);
        Console.WriteLine(@" | \| |/ _ \ ");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 * 3 -
            ("  _  _  ___  ".Length / 2), HabitTracker.ALTO_PANTALLA / 2 + 2);
        Console.WriteLine(@" | .` | (_) |");
        Console.SetCursorPosition(HabitTracker.ANCHO_PANTALLA / 4 * 3 -
            ("  _  _  ___  ".Length / 2), HabitTracker.ALTO_PANTALLA / 2 + 3);
        Console.WriteLine(@" |_|\_|\___/ ");
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public int EsUnBuenDia()
    {
        int opcionActual = 0;
        int actualizar = -1;

        DibujarPortadaBuenDiaParte1();
        DibujarPortadaBuenDiaParte2();

        while (actualizar == -1)
        {
            DibujarSiYNo(opcionActual);
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.RightArrow ||
                tecla.Key == ConsoleKey.LeftArrow)
            {
                opcionActual = (opcionActual + 1) % 2;
            }
            if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            {
                actualizar = opcionActual;
            }
        }

        return actualizar;
    }

    public int BorrarTuAnyoEnPixeles()
    {
        int opcionActual = 0;
        int borrar = -1;

        Console.Clear();

        Console.SetCursorPosition(15, 10);
        Console.WriteLine(@"   _  ___ ___ _____ _   ___   ___ ___ ___ _   _ ___  ___ ___ ");
        Console.SetCursorPosition(15, 11);
        Console.WriteLine(@"  (_)| __/ __|_   _/_\ / __| / __| __/ __| | | | _ \/ _ \__ \");
        Console.SetCursorPosition(15, 12);
        Console.WriteLine(@" / /_| _|\__ \ | |/ _ \\__ \ \__ \ _| (_ | |_| |   / (_) |/_/");
        Console.SetCursorPosition(15, 13);
        Console.WriteLine(@" \___|___|___/ |_/_/ \_\___/ |___/___\___|\___/|_|_\\___/(_) ");

        while (borrar == -1)
        {
            DibujarSiYNo(opcionActual);
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.RightArrow ||
                tecla.Key == ConsoleKey.LeftArrow)
            {
                opcionActual = (opcionActual + 1) % 2;
            }
            if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.Enter)
            {
                return opcionActual;
            }
        }
        return -1;
    }

    public void ActualizarHoy()
    {
        int actualizar = EsUnBuenDia();

        comprobaciones[DateTime.Now.Month - 1] =
                comprobaciones[DateTime.Now.Month - 1].Substring(0, DateTime.Now.Day - 1) +
                (actualizar == 0 ? "X" : "O") +
                comprobaciones[DateTime.Now.Month - 1].Substring(DateTime.Now.Day);
        File.WriteAllLines(@"data\anyo.txt", comprobaciones);
    }
}