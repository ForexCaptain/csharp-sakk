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
            for (int i = 0; i < 8; i++)
            {

                if (i != helyX)
                {
                    lepesek.Add(new Tuple<int, int>(i + 1, helyY - 1));
                }
                //nem kell a helyY ++?;
                //8 ig megy a ciklus, nem indexel ki a pályáról? lónál?
            }
            //balra le
            for (int i = 0; i < 8; i++)
            {

                if (i != helyY)
                {
                    lepesek.Add(new Tuple<int, int>(i - 1, helyY + 1));
                }

            }

            //jobbra le
            for (int i = 0; i < 8; i++)
            {

                if (i != helyX)
                {
                    lepesek.Add(new Tuple<int, int>(helyX + 1, i + 1));
                }

            }
            //balra fel
            for (int i = 0; i < 8; i++)
            {

                if (i != helyY)
                {
                    lepesek.Add(new Tuple<int, int>(helyX - 1, i - 1));
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



                int minY = lepesek.Min(x => x.Item2);
                int maxY = lepesek.Max(x => x.Item2);

                int minX = lepesek.Min(x => x.Item1);
                int maxX = lepesek.Max(x => x.Item1);

                bool joE = true;

                //1.megoldas
                //if (tablaAllas[item.Item1,item.Item2] != null)
                //{
                //    joE = false;
                //}
                //else
                //{
                //    joLepesek.Add(item);
                //}



                //2.megoldas
                if (helyY != item.Item2)
                {

                    for (int i = minY; i < maxY; i++)
                    {
                        if (tablaAllas[helyX, i] != null && joE)
                        {
                            joE = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; minX < maxX; i++)
                    {
                        if (tablaAllas[helyX, i] != null && joE)
                        {
                            joE = false;
                        }
                    }
                }

                if (joE)
                {
                    joLepesek.Add(item);
                }
            }

            //3. megoldas
            //    bool joE = true;
            //    if (helyY != item.Item2)
            //    {
            //        for (int i = Math.Min(helyY + 1, item.Item2); i <= Math.Max(helyY - 1, item.Item2); i++)
            //        {
            //            if (tablaAllas[helyX, i] != null && joE)
            //                joE = false;
            //        }
            //    }
            //    else
            //    {
            //        for (int i = Math.Min(helyX + 1, item.Item1); i <= Math.Max(helyX - 1, item.Item1); i++)
            //        {
            //            if (tablaAllas[i, helyY] != null && joE)
            //                joE = false;
            //        }
            //    }

            //    if (joE)
            //    {
            //        joLepesek.Add(item);
            //    }
            //}
            return joLepesek;

        }

        public override Babu Copy(Babu hova)
        {
            hova = new Futo(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
