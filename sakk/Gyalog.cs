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

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
           List<Tuple<int,int>> lehetsegesLepesek = new List<Tuple<int, int>>();
                       
           if (helyY == 1 || helyY == 6)
	       {
               //fekete lepesek
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX, helyY+2));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY+1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY+1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY+1));

               //feher lepesek
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX, helyY-2));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY-1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY-1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY-1));
	       }
           
           else
	       {
               //fekete lepesek
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY+1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY+1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY+1));

               //feher lepesek
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY-1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY-1));
               lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY-1));
	       }
           
           return lehetsegesLepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();

            return lepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Gyalog(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
