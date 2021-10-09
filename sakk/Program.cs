using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToDo: Tesztprogram elkészítése
            Tabla s;
            Console.Write("Szeretne egy már elkezdett játékot folytatni? (i/n): ");
            if (Console.ReadLine() == "i")
            {
                Console.WriteLine();
                //Elkezdett játék betöltése
                Console.Write("Adja meg a fájl nevét! (pl.: alap.txt): ");
                s = new Tabla(Console.ReadLine());              
            }
            else
                s = new Tabla();
            Console.WriteLine("Kilépéshez írjon '-' karaktert!");
            s.TablaKirajzolas();
            char[] betuk = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            bool stop = false;
            do
            {
                Console.Write("Melyik bábuval szeretne lépni? (pl.: a1): ");
                string honnan = Console.ReadLine();
                if (honnan != "-")
                {
                    if (Array.IndexOf(betuk, honnan[0]) >= 0 && int.TryParse(honnan[1].ToString(), out int kezdoY))
                    {
                        int kezdoX = Array.IndexOf(betuk, honnan[0]);
                        kezdoY = 8 - kezdoY;
                        Console.Write("Melyik mezőre szeretne lépni? (pl.: a1): ");
                        string hova = Console.ReadLine();
                        if (hova != "-")
                        {
                            if (Array.IndexOf(betuk, hova[0]) >= 0 && int.TryParse(hova[1].ToString(), out int celY))
                            {
                                int celX = Array.IndexOf(betuk, hova[0]);
                                celY = 8 - celY;
                                if (s.tablaAllas[kezdoX, kezdoY] != null)
                                {
                                    Console.Clear();
                                    s.Lepes(kezdoX, kezdoY, celX, celY);
                                    Console.WriteLine("Kilépéshez írjon '-' karaktert!");
                                    s.TablaKirajzolas();
                                }
                                else
                                    Console.WriteLine("Hibás lépés! Adjon meg egy szabályos lépést!");
                            }
                            else
                                Console.WriteLine("Hibás lépés! Adjon meg egy szabályos lépést!");
                        }
                        else
                            stop = true;
                    }
                    else
                        Console.WriteLine("Hibás lépés! Adjon meg egy szabályos lépést!");
                }
                else
                    stop = true;
            } while (!stop);
            Console.ReadKey();
        }
    }
}
