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
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int>> JoLepesek()
        {
            throw new NotImplementedException();
        }

        public bool SakkbanVanE()
        {
            throw new NotImplementedException();
        }
    }
}
