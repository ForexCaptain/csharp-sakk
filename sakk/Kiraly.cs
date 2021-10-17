using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Kiraly : Babu
    {
        //ToDo: metódusok megvalósítása
        public Kiraly(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Kiraly;
            Jeloles = "K";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();

            lepesek.Add(new Tuple<int, int>(helyX + 1, helyY + 1));
            lepesek.Add(new Tuple<int, int>(helyX + 1, helyY));
            lepesek.Add(new Tuple<int, int>(helyX + 1, helyY - 1));
            lepesek.Add(new Tuple<int, int>(helyX, helyY + 1));
            lepesek.Add(new Tuple<int, int>(helyX, helyY - 1));
            lepesek.Add(new Tuple<int, int>(helyX - 1, helyY + 1));
            lepesek.Add(new Tuple<int, int>(helyX - 1, helyY));
            lepesek.Add(new Tuple<int, int>(helyX - 1, helyY - 1));

            for (int i = 0; i < lepesek.Count; i++)
            {
                if (lepesek[i].Item1 < 0 || lepesek[i].Item1 > 7 || lepesek[i].Item2 < 0 || lepesek[i].Item2 > 7)
                {
                    lepesek.Remove(lepesek[i]);
                    i--;
                }
            }

            return lepesek;
        }
        //talan kész
        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();
            foreach (var item in lepesek)
            {
                bool joE = true;
                //index a tömb határain kívülre mutat
                if (tablaAllas[item.Item1,item.Item2] != null)
                {
                    if (tablaAllas[item.Item1, item.Item2].Szin == Szin)
                    {
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

        public bool SakkbanVanE(Babu[,] tablaAllas)
        {
            throw new NotImplementedException();
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Kiraly(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
