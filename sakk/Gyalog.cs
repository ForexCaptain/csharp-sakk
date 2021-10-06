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
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();
            //lépés hozzáadása a listához:
            //lepesek.Add(new Tuple<int, int>(i érték, j érték));
            lepesek.Add(new Tuple<int, int>(1, 2));
            return lepesek;
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int>> JoLepesek()
        {
            throw new NotImplementedException();
        }
    }
}
