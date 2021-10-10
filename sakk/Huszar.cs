using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Huszar : Babu
    {
        //ToDo: metódusok megvalósítása
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

            return lepesek;
        }
        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();

            return lepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Huszar(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
