using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Gyalog : Babu
    {
        //ToDo: metódusok megvalósítása
        public Gyalog(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Gyalog;
            Jeloles = "G";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int,int>> LehetsegesLepesek()
        {
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            throw new NotImplementedException();
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Gyalog(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
