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
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            throw new NotImplementedException();
        }
    }
}
