using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Vezer : Babu
    {
        //ToDo: metódusok megvalósítása
        public Vezer(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Vezer;
            Jeloles = "V";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();

            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
  
            return lepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Vezer(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
