using System;

namespace sakk
{
    class Tabla
    {
        public Babu[,] tablaAllas = new Babu[8, 8];
        string kijon;

        //Új játék betöltése
        public Tabla()
        {
            Fajlkezeles.Betoltes("alap.txt", ref tablaAllas);
            kijon = "feher";
        }

        //Elkezdett játék betöltése
        public Tabla(string fajlnev)
        {
            Fajlkezeles.Betoltes(fajlnev, ref tablaAllas);
            kijon = "feher";
        }

        public string Kijon { get => kijon; set => kijon = value; }

        public bool Lepes(int kezdoX, int kezdoY, int celX, int celY)
        {
            //király sakkban van-e megoldása még szükséges

            //lehetséges-e ez a lépés
            if (kezdoY <= 7 && kezdoY >= 0 && tablaAllas[kezdoX, kezdoY] != null && tablaAllas[kezdoX, kezdoY].Szin == Kijon 
                && tablaAllas[kezdoX, kezdoY].JoLepesek(tablaAllas).Contains(new Tuple<int, int>(celX, celY)))
            {
                tablaAllas[kezdoX, kezdoY].HelyX = celX;
                tablaAllas[kezdoX, kezdoY].HelyY = celY;
                tablaAllas[celX, celY] = tablaAllas[kezdoX, kezdoY].Copy(tablaAllas[celX, celY]);
                tablaAllas[kezdoX, kezdoY] = null;
                return true;
            }
            else
                return false;
        }

        public void TablaKirajzolas()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            int kiirandoSorokSzama = 17;
            for (int j = 0; j < kiirandoSorokSzama; j++)
            {
                if (j % 2 == 0)
                    Console.Write("+---+---+---+---+---+---+---+---+   \n");
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                            Console.Write("| ");
                            if (tablaAllas[i, j / 2]?.Szin == "fekete")
                                Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{tablaAllas[i, j / 2]?.Jeloles??" "} ");
                            Console.ForegroundColor = ConsoleColor.White;
                    }              
                    Console.Write($"| {(kiirandoSorokSzama - j) / 2} \n"); //oldalsó számozás
                }
                if (j == kiirandoSorokSzama - 1)
                    Console.Write($"  a   b   c   d   e   f   g   h     \n");                        
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
