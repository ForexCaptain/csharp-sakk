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
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            throw new NotImplementedException();
        }
    }
}
