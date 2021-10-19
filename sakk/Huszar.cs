using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Huszar : Babu
    {
        public Huszar(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Huszar;
            Jeloles = "H";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();

            lepesek.Add(new Tuple<int, int>(helyX + 2, helyY + 1));
            lepesek.Add(new Tuple<int, int>(helyX + 2, helyY - 1));
            lepesek.Add(new Tuple<int, int>(helyX - 2, helyY - 1));
            lepesek.Add(new Tuple<int, int>(helyX - 2, helyY + 1));
            lepesek.Add(new Tuple<int, int>(helyX + 1, helyY - 2));
            lepesek.Add(new Tuple<int, int>(helyX + 1, helyY + 2));
            lepesek.Add(new Tuple<int, int>(helyX - 1, helyY - 2));
            lepesek.Add(new Tuple<int, int>(helyX - 1, helyY + 2));

            //táblán kívüli lépsek törlése
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
        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();

            foreach (var item in lepesek)
            {
                if (tablaAllas[item.Item1, item.Item2] == null || tablaAllas[item.Item1, item.Item2].Szin != Szin)
                {
                    joLepesek.Add(item);
                }
            }

            return joLepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Huszar(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
