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

            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();

            return lepesek;
        }

        public bool SakkbanVanE()
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
