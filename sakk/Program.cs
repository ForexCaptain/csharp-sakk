using System;

namespace sakk
{
    class Program
    {
        public enum LepesEredmeny
        {
            Sikeres, Szabalytalan, Sakk
        }
        static Tabla Inditas()
        {
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
            Console.Clear();
            Console.WriteLine("Kilépéshez írjon '-' karaktert!");
            s.TablaKirajzolas();
            return s;
        }

        static LepesEredmeny SikeresLepesE(string honnan, Tabla s)
        {
            char[] betuk = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            //jó karakter-e
            if (honnan.Length == 2 && Array.IndexOf(betuk, honnan[0]) >= 0 && int.TryParse(honnan[1].ToString(), out int kezdoY))
            {
                int kezdoX = Array.IndexOf(betuk, honnan[0]);
                kezdoY = 8 - kezdoY;

                Console.Write("Melyik mezőre szeretne lépni? (pl.: a1): ");
                string hova = Console.ReadLine();
                //jó célmező-e
                if (hova.Length == 2 && Array.IndexOf(betuk, hova[0]) >= 0 && int.TryParse(hova[1].ToString(), out int celY))
                {
                    int celX = Array.IndexOf(betuk, hova[0]);
                    celY = 8 - celY;
                    //megtörtént-e a lépés
                    LepesEredmeny eredmeny = s.Lepes(kezdoX, kezdoY, celX, celY);
                    if (eredmeny == LepesEredmeny.Sikeres)
                    {
                        Console.Clear();
                        Console.WriteLine("Kilépéshez írjon '-' karaktert!");
                        s.TablaKirajzolas();               
                        if (s.Kijon == "feher")
                        {
                            Console.WriteLine(Kiraly.SakkbanVanE(s.FeketeKiraly, s.tablaAllas) ? "A fekete király sakkban van!" : "");
                            s.Kijon = "fekete";
                        }
                        else
                        {
                            Console.WriteLine(Kiraly.SakkbanVanE(s.FeherKiraly, s.tablaAllas) ? "A fehér király sakkban van!" : "");
                            s.Kijon = "feher";
                        }
                        return LepesEredmeny.Sikeres;
                    }
                    else if (eredmeny == LepesEredmeny.Sakk)
                        return LepesEredmeny.Sakk;
                }
            }
            return LepesEredmeny.Szabalytalan;
        }

        static void Befejezes(Tabla s)
        {
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
            Console.WriteLine("Bezáráshoz nyomja meg bármelyik gombot!");
        }

        static void Main(string[] args)
        {    
            Tabla s = Inditas();
            
            bool stop = false;
            do
            {
                Console.WriteLine((s.Kijon == "feher" ? "Fehér" : "Fekete") + " következik.");
                Console.Write("Melyik bábuval szeretne lépni? (pl.: a1): ");
                string honnan = Console.ReadLine();
                if (honnan != "-")
                {
                    LepesEredmeny eredmeny = SikeresLepesE(honnan, s);
                    if (eredmeny != LepesEredmeny.Sikeres)
                    {
                        Console.Clear();
                        Console.WriteLine("Kilépéshez írjon '-' karaktert!");
                        s.TablaKirajzolas();
                        if (eredmeny == LepesEredmeny.Sakk)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Hibás lépés! A király sakkba kerül!");
                        }
                        if (eredmeny == LepesEredmeny.Szabalytalan)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Hibás lépés! Adjon meg egy szabályos lépést!");
                        }                      
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                    stop = true;
            } while (!stop);

            Befejezes(s);
            
            Console.ReadKey();
        }
    }
}
