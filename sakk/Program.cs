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
            //ToDo: Tesztprogram befejezése
            string kijon = "feher";
            Tabla s;
            Console.Write("Szeretne egy már elkezdett játékot folytatni? (i/n): ");
            if (Console.ReadLine() == "i")
            {
                //Elkezdett játék betöltése
                Console.Write("Adja meg a fájl nevét! (pl.: mentes.txt): ");
                s = new Tabla(Console.ReadLine());              
            }
            else
                //Új játék kezdése
                s = new Tabla();
            Console.WriteLine("Kilépéshez írjon '-' karaktert!");
            s.TablaKirajzolas();
            char[] betuk = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            bool stop = false;
            do
            {
                Console.WriteLine((kijon == "feher" ? "Fehér" : "Fekete") + " következik.");
                Console.Write("Melyik bábuval szeretne lépni? (pl.: a1): ");
                string honnan = Console.ReadLine();
                if (honnan != "-")
                {
                    if (Array.IndexOf(betuk, honnan[0]) >= 0 && honnan.Length > 1 && int.TryParse(honnan[1].ToString(), out int kezdoY))
                    {
                        if (s.tablaAllas[Array.IndexOf(betuk, honnan[0]), 8 - kezdoY] != null && s.tablaAllas[Array.IndexOf(betuk, honnan[0]), 8 - kezdoY].Szin == kijon) 
                        {
                            int kezdoX = Array.IndexOf(betuk, honnan[0]);
                            kezdoY = 8 - kezdoY;
                            Console.Write("Melyik mezőre szeretne lépni? (pl.: a1): ");
                            string hova = Console.ReadLine();
                            if (hova != "-")
                            {
                                if (Array.IndexOf(betuk, hova[0]) >= 0 && hova.Length > 1 && int.TryParse(hova[1].ToString(), out int celY))
                                {
                                    int celX = Array.IndexOf(betuk, hova[0]);
                                    celY = 8 - celY;
                                    if (s.Lepes(kezdoX, kezdoY, celX, celY))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Kilépéshez írjon '-' karaktert!");
                                        s.TablaKirajzolas();
                                        if (kijon == "feher")
                                            kijon = "fekete";
                                        else
                                            kijon = "feher";
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
                        Console.WriteLine("Hibás lépés! Adjon meg egy szabályos lépést!");
                }
                else
                    stop = true;
            } while (!stop);
            Console.Write("Szeretné elmenteni az állást? (i/n): ");
            if (Console.ReadLine() == "i")
            {
                bool mentve = false;
                while (!mentve)
                {
                    Console.Write("Adja meg mi legyen a fájl neve! (pl.: mentes.txt): ");
                    string fajlnev = Console.ReadLine();
                    if (!fajlnev.StartsWith(".") && fajlnev.EndsWith(".txt"))
                    {
                        Fajlkezeles.Mentes(fajlnev, s.tablaAllas);
                        mentve = true;
                        Console.WriteLine("Sikeres mentés!");
                    }
                    else
                        Console.WriteLine("Hibás fájlnév! Adjon meg egy új fájlnevet!");
                }
            }
            Console.ReadKey();
        }
    }
}
