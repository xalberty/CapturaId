using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CapturaId
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = CapturaId(3,1);

            Console.Write("\nPress any key to skip");
            Console.ReadKey(true);
        }

        public static string CapturaId(int numeroLetras, int numeroNum)
        {
            string id = String.Empty;
            int cont = 0, cont2 = 0;
            bool check = true;
            do
            {
                cont = 0; 
                cont2 = 0;
                check = true;
                Console.Write("\nIntroduzca un id [Debe contener {0} letra/s y {1} número/s]: ", numeroLetras, numeroNum);
                id = Console.ReadLine().ToUpper();

                if (id.Length != (numeroLetras + numeroNum) && check)
                {
                    Error("La cadena  debe contener un número y tres letras");
                    check = false;
                }
                    

                for (int i = 0; i < id.Length; i++)
                {

                    if (id[i] >= '0' && id[i] <= '9')
                        cont++;
                    if ((id[i] >= 'A' && id[i] <= 'Z') || id[i] == 'Ñ')
                        cont2++;
                }
                        

                if (cont != numeroNum && check)
                {
                    Error("La cadena debe contener " + numeroNum + " número/s");
                    check = false;
                }
                    
                if (cont2 != numeroLetras && check)
                {
                    Error("La cadena debe contener" + numeroLetras + " letra/s");
                    check = false;
                }
                                      
                if(!check)
                {
                    Thread.Sleep(1200);
                    Console.Clear();
                }

            } while (!check);

            return id;
        }

        public static void Error(string texto)
        {
            int max = texto.Length;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop + 2);
            Console.Write("╔═══ERROR");
            for (int j = 0; j < max + 4 - 8; j++)
                Console.Write("═");
            Console.WriteLine("╗");
            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop);
            Console.Write("║  ");
            Console.Write(texto);
            Console.Write("  ║");
            Console.WriteLine("█");
            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop);
            Console.Write("╚");
            for (int j = 0; j < max + 4; j++)
                Console.Write("═");
            Console.Write("╝");
            Console.WriteLine("█");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(((Console.WindowWidth - max - 4) / 2) + 1, Console.CursorTop);
            for (int j = 0; j < max + 6; j++)
                Console.Write("▀");
            Console.Beep();
            Console.ResetColor();
        }

    }
}
