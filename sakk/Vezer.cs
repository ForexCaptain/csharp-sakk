using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Vezer : Babu
    {
        public Vezer(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Vezer;
            Jeloles = "V";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();

            //egyenes
            for (int i = 0; i < 8; i++)
            {
                //vízszintes
                if (i != helyX)
                {
                    lepesek.Add(new Tuple<int, int>(i, helyY));
                }
            }
            for (int i = 0; i < 8; i++)
            {
                //függőleges
                if (i != helyY)
                {
                    lepesek.Add(new Tuple<int, int>(helyX, i));
                }
            }

            //átló
            for (int i = 1; i < 8; i++)
            {
                //jobbra fel
                if (helyX + i <= 7 && helyY - i >= 0)
                    lepesek.Add(new Tuple<int, int>(helyX + i, helyY - i));

                //balra le
                if (helyX - i >= 0 && helyY + i <= 7)
                    lepesek.Add(new Tuple<int, int>(helyX - i, helyY + i));

                //jobbra le
                if (helyX + i <= 7 && helyY + i <= 7)
                    lepesek.Add(new Tuple<int, int>(helyX + i, helyY + i));

                //balra fel
                if (helyX - i >= 0 && helyY - i >= 0)
                    lepesek.Add(new Tuple<int, int>(helyX - i, helyY - i));
            }

            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();

            //megvalósítás ide

            return lepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Vezer(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
