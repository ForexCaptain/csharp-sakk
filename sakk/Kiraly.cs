using System;
using System.Collections.Generic;

namespace sakk
{
    class Kiraly : Babu
    {
        public Kiraly(int helyX, int helyY, string szin, string jeloles="K") : base(helyX, helyY, szin, jeloles)
        {
            Tipus = BabuTipus.Kiraly;
        }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();

            for (int i = -1; i <= 1; i++)
            {
                if (helyX + 1 <= 7 && helyY + i >= 0 && helyY + i <= 7)
                    lepesek.Add(new Tuple<int, int>(helyX + 1, helyY + i));
                if (helyX - 1 >= 0 && helyY + i >= 0 && helyY + i <= 7)
                    lepesek.Add(new Tuple<int, int>(helyX - 1, helyY + i));
                if (i != 0 && helyY + i >= 0 && helyY + i <= 7)
                    lepesek.Add(new Tuple<int, int>(helyX, helyY + i));
            }

            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();

            foreach (var item in lepesek)
            {
                if (tablaAllas[item.Item1, item.Item2] == null || tablaAllas[item.Item1, item.Item2].Szin != Szin)
                    joLepesek.Add(item);
            }

            return joLepesek;
        }

        public static bool SakkbanVanE(Kiraly kiraly, Babu[,] tablaAllas)
        {
            bool sakk = false;
            foreach (var item in tablaAllas)
            {
                if (item != null && item?.Szin != kiraly.Szin)
                {
                    if (item.JoLepesek(tablaAllas).Contains(new Tuple<int, int>(kiraly.helyX, kiraly.helyY)))
                        sakk = true;
                }
            }
            return sakk;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Kiraly(helyX, helyY, Szin, Jeloles);
            return hova;
        }
    }
}
