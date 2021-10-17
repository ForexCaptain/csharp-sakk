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
            List<Tuple<int, int>> lepesek = new List<Tuple<int, int>>();

            //jobbra fel
            for (int i = 1; i < 8; i++)
            {
                if (i != helyX)
                {
                    lepesek.Add(new Tuple<int, int>(helyX + i, helyY - i));
                }
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
            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();

            foreach (var item in lepesek)
            {
                bool joE = true;
                //jobbrafelEll
                if (helyY != item.Item2 && helyX < item.Item1 && helyY > item.Item2)
                {
                    for (int i = Math.Min(helyY + 1, item.Item2); i < Math.Max(helyY - 1, item.Item2); i++)
                    {
                        if (tablaAllas[helyX ++, i] != null && joE)
                        {
                            if (tablaAllas[helyX ++, i].Szin == Szin)
                            {
                                joE = false;
                            }
                        }
                    }
                }

                //balraleEll
                if (helyY != item.Item2 && helyX > item.Item1 && helyY < item.Item2)
                {
                    for (int i = Math.Min(helyY + 1, item.Item2); i < Math.Max(helyX - 1, item.Item2); i++)
                    {
                        if (tablaAllas[helyX --, i ] != null && joE)
                        {
                            if (tablaAllas[helyX --, i].Szin == Szin)
                            {
                                joE = false;
                            }
                        }
                    }
                }
                //balrafelEllXX
                if (helyX != item.Item1 && helyX > item.Item1 && helyY > item.Item2)
                {
                    for (int i = Math.Min(helyX + 1, item.Item1); i < Math.Max(helyX - 1, item.Item1); i++)
                    {
                        if (tablaAllas[i--, helyY--] != null && joE)
                        {
                            if (tablaAllas[i--, helyY--].Szin == Szin)
                            {
                                joE = false;
                            }
                        }
                    }
                }
                //jobbraleEll
                if (helyX != item.Item1 && helyX > item.Item1 && helyY > item.Item2)
                {
                    for (int i = Math.Min(helyY + 1, item.Item2); i < Math.Max(helyY - 1, item.Item2); i++)
                    {
                        if (tablaAllas[i++, helyY++] != null && joE)
                        {
                            if (tablaAllas[i, helyY++].Szin == Szin)
                            {
                                joE = false;
                            }
                        }
                    }
                }
                if (joE)
                {
                    joLepesek.Add(item);
                }
            }

            return joLepesek;
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Futo(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
