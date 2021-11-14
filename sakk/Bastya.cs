using System;
using System.Collections.Generic;

namespace sakk
{
    class Bastya : Babu
    {
        public Bastya(int helyX, int helyY, string szin) : base(helyX, helyY, szin)
        {
            Tipus = BabuTipus.Bastya;
            Jeloles = "B";
        }

        public override string Jeloles { get; protected set; }

        public override List<Tuple<int, int>> LehetsegesLepesek()
        {
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();

            for (int i = 1; i < 8; i++)
            {
                //jobbra
                if (helyX + i <= 7)
                    lepesek.Add(new Tuple<int, int>(helyX + i, helyY));
                //balra
                if (helyX - i >= 0)
                    lepesek.Add(new Tuple<int, int>(helyX - i, helyY));
                //le
                if (helyY + i <= 7)
                    lepesek.Add(new Tuple<int, int>(helyX, helyY + i));
                //fel
                if (helyY - i >= 0)
                    lepesek.Add(new Tuple<int, int>(helyX, helyY - i));
            }

            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();
            
            bool[] rossziranyok = { false, false, false, false};
            foreach (var item in lepesek)
            {
                //fel
                if (helyX == item.Item1 && helyY > item.Item2&& !rossziranyok[0])
                    rossziranyok[0] = RosszEAzIrany(tablaAllas, item, ref joLepesek);
                //le
                else if(helyX == item.Item1 && helyY < item.Item2 && !rossziranyok[1])
                    rossziranyok[1] = RosszEAzIrany(tablaAllas, item, ref joLepesek);
                //balra
                else if (helyY == item.Item2 && helyX > item.Item1 && !rossziranyok[2])
                    rossziranyok[2] = RosszEAzIrany(tablaAllas, item, ref joLepesek);
                //jobbra
                else if (helyY == item.Item2 && helyX < item.Item1 && !rossziranyok[3])
                    rossziranyok[3] = RosszEAzIrany(tablaAllas, item, ref joLepesek);
            }

            return joLepesek;
        }

        //átadjuk az irányokat, ha abban az irányban már nem tud tovább lépni, true-t ad vissza, egyébként false-ot
        private bool RosszEAzIrany(Babu[,] tablaAllas, Tuple<int, int> item, ref List<Tuple<int, int>> joLepesek)
        {
            if (tablaAllas[item.Item1, item.Item2] == null)
            {
                joLepesek.Add(item);
                return false;
            }
            else
            {
                if (tablaAllas[item.Item1, item.Item2].Szin != Szin)
                    joLepesek.Add(item);
                return true;
            }
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Bastya(helyX, helyY, Szin);
            return hova;
        }
    }
}
