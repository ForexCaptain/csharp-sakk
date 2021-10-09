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
            for (int i = -8; i < 8; i++)
            {
                for (int j = -8; j < 8; i++)
                {
                    if (i != 0 || j != 0)
                    {
                        lepesek.Add(new Tuple<int, int>(helyX + i, helyY + j));
                    }            
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
