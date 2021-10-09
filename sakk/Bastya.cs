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


            return lepesek;
        }
    }
}
