using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Gyalog : Babu
    {
        public Gyalog(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Gyalog;
            Jeloles = "G";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lehetsegesLepesek = new List<Tuple<int, int>>();

            //fekete lépések
            if (Szin == "fekete")
            {
                if (helyY == 1)
                {
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX, helyY + 2));
                }
                lehetsegesLepesek.Add(new Tuple<int, int>(helyX, helyY + 1));
                lehetsegesLepesek.Add(new Tuple<int, int>(helyX - 1, helyY + 1));
                lehetsegesLepesek.Add(new Tuple<int, int>(helyX + 1, helyY + 1));
            }
            //fehér lépések
            else
            {
                if (helyY == 6)
                {                  
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX, helyY - 2));
                }
                lehetsegesLepesek.Add(new Tuple<int, int>(helyX, helyY - 1));
                lehetsegesLepesek.Add(new Tuple<int, int>(helyX + 1, helyY - 1));
                lehetsegesLepesek.Add(new Tuple<int, int>(helyX - 1, helyY - 1));
            }
            //táblán kívüli lépsek törlése
            for (int i = 0; i < lehetsegesLepesek.Count; i++)
            {
                if (lehetsegesLepesek[i].Item1 < 0 || lehetsegesLepesek[i].Item1 > 7 || lehetsegesLepesek[i].Item2 < 0 || lehetsegesLepesek[i].Item2 > 7)
                {
                    lehetsegesLepesek.Remove(lehetsegesLepesek[i]);
                    i--;
                }
            }

            return lehetsegesLepesek;

        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();

            foreach (var item in lepesek)
            {
                if (tablaAllas[item.Item1, item.Item2] != null && item.Item1 != helyX && tablaAllas[item.Item1, item.Item2].Szin != Szin)
                {
                    joLepesek.Add(item);
                }
                else if (tablaAllas[item.Item1, item.Item2] == null && item.Item1 == helyX)
                {
                    joLepesek.Add(item);
                }
            }

            return joLepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Gyalog(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
