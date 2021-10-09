using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Bastya : Babu
    {   
        //ToDo: metódusok megvalósítása
        public Bastya(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Bastya;
            Jeloles = "B";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();
            for (int i = 0; i < 8; i++)
            {
                if (i != helyX)
                {
                    lepesek.Add(new Tuple<int, int>(i, helyY));
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (i != helyY)
                {
                    lepesek.Add(new Tuple<int, int>(helyX, i));
                }
            }
            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();
            foreach (var item in lepesek)
            {
                bool joE = true;
                if (helyY != item.Item2)
                {
                    for (int i = Math.Min(helyY + 1, item.Item2); i <= Math.Max(helyY - 1, item.Item2); i++)
                    {
                        if (tablaAllas[helyX, i] != null && joE)
                            joE = false;
                    }
                }
                else
                {
                    for (int i = Math.Min(helyX + 1, item.Item1); i <= Math.Max(helyX - 1, item.Item1); i++)
                    {
                        if (tablaAllas[i, helyY] != null && joE)
                            joE = false;
                    }
                }

                if (joE)
                {
                    joLepesek.Add(item);
                }
            }
            return joLepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Bastya(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
