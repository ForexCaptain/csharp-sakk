using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Futo : Babu
    {
        //ToDo: metódusok megvalósítása
        public Futo(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Futo;
            Jeloles = "F";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();

<<<<<<< HEAD
            //jobbra fel
            for (int i = 1; i < 8; i++)
            {

                if (i != helyX)
                {
                    lepesek.Add(new Tuple<int, int>(helyX + i, helyY - i));
                }
                //nem kell a helyY ++?;
                //8 ig megy a ciklus, nem indexel ki a pályáról? lónál?
            }
            //balra le
            for (int i = 1; i < 8; i++)
            {

                if (i != helyY)
                {
                    lepesek.Add(new Tuple<int, int>(helyX - i, helyY + i));
                }

            }

            //jobbra le
            for (int i = 1; i < 8; i++)
            {

                if (i != helyX)
                {
                    lepesek.Add(new Tuple<int, int>(helyX + i, helyY + i));
                }

            }
            //balra fel
            for (int i = 1; i < 8; i++)
            {

                if (i != helyY)
                {
                    lepesek.Add(new Tuple<int, int>(helyX - i, helyY - i));
                }

            }
=======
>>>>>>> 1ddc46d8d5f3287dcae90e6cf279592cae344e9a
            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
<<<<<<< HEAD
            
            return lepesek;
            
=======

            return lepesek;
>>>>>>> 1ddc46d8d5f3287dcae90e6cf279592cae344e9a
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Futo(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
