using System;
using static sakk.Program;

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
            foreach (var item in tablaAllas)
            {
                if (item?.Jeloles == "K")
                {
                    if (item.Szin == "fekete")
                        FeketeKiraly = new Kiraly(item.helyX, item.helyY, "fekete");
                    else
                        FeherKiraly = new Kiraly(item.helyX, item.helyY, "feher");
                }
            }
        }

        //Elkezdett játék betöltése
        public Tabla(string fajlnev)
        {
            Fajlkezeles.Betoltes(fajlnev, ref tablaAllas);
            kijon = "feher";
            foreach (var item in tablaAllas)
            {
                if (item?.Jeloles == "K")
                {
                    if (item.Szin == "fekete")
                        FeketeKiraly = new Kiraly(item.helyX, item.helyY, "fekete");
                    else
                        FeherKiraly = new Kiraly(item.helyX, item.helyY, "feher");
                }
            }
        }

        public Kiraly FeketeKiraly { get; }
        public Kiraly FeherKiraly { get; }
        public string Kijon { get => kijon; set => kijon = value; }

        public LepesEredmeny Lepes(int kezdoX, int kezdoY, int celX, int celY)
        {
            //lehetséges-e ez a lépés
            if (kezdoY <= 7 && kezdoY >= 0 && tablaAllas[kezdoX, kezdoY] != null && tablaAllas[kezdoX, kezdoY].Szin == Kijon
                && tablaAllas[kezdoX, kezdoY].JoLepesek(tablaAllas).Contains(new Tuple<int, int>(celX, celY)))
            {
                LepesSzimulalas(kezdoX, kezdoY, celX, celY, out Babu[,] kovetkezoAllas);
                //sakkban van-e a király               
                if (kovetkezoAllas[celX, celY].Jeloles == "K" ? !Kiraly.SakkbanVanE(new Kiraly(celX, celY, Kijon), kovetkezoAllas) :
                    (Kijon == "fekete" ? !Kiraly.SakkbanVanE(FeketeKiraly, kovetkezoAllas) : !Kiraly.SakkbanVanE(FeherKiraly, kovetkezoAllas)))
                {
                    if (tablaAllas[kezdoX, kezdoY].Jeloles == "K" && tablaAllas[kezdoX, kezdoY].Szin == "fekete")
                    {
                        FeketeKiraly.helyX = celX;
                        FeketeKiraly.helyY = celY;
                    }
                    else if (tablaAllas[kezdoX, kezdoY].Jeloles == "K" && tablaAllas[kezdoX, kezdoY].Szin == "feher")
                    {
                        FeherKiraly.helyX = celX;
                        FeherKiraly.helyY = celY;
                    }
                    Athelyez(kezdoX, kezdoY, celX, celY, ref tablaAllas);
                    return LepesEredmeny.Sikeres;
                }
                return LepesEredmeny.Sakk;
            }
            return LepesEredmeny.Szabalytalan;
        }

        private void LepesSzimulalas(int kezdoX, int kezdoY, int celX, int celY, out Babu[,] kovetkezoAllas)
        {
            kovetkezoAllas = new Babu[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    kovetkezoAllas[i, j] = tablaAllas[i, j]?.Copy(kovetkezoAllas[i, j]);
                }
            }
            Athelyez(kezdoX, kezdoY, celX, celY, ref kovetkezoAllas);
        }

        private void Athelyez(int kezdoX, int kezdoY, int celX, int celY, ref Babu[,] tablaAllas)
        {
            tablaAllas[kezdoX, kezdoY].helyX = celX;
            tablaAllas[kezdoX, kezdoY].helyY = celY;
            tablaAllas[celX, celY] = tablaAllas[kezdoX, kezdoY].Copy(tablaAllas[celX, celY]);
            tablaAllas[kezdoX, kezdoY] = null;
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
