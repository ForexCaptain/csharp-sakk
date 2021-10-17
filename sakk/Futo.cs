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

            for (int i = 1; i < 8; i++)
            {
                //jobbra fel
                lepesek.Add(new Tuple<int, int>(helyX + i, helyY - i));

                //balra le
                lepesek.Add(new Tuple<int, int>(helyX - i, helyY + i));

                //jobbra le
                lepesek.Add(new Tuple<int, int>(helyX + i, helyY + i));

                //balra fel
                lepesek.Add(new Tuple<int, int>(helyX - i, helyY - i));
            }

            for (int i = 0; i < lepesek.Count; i++)
            {
                if (lepesek[i].Item1 < 0 || lepesek[i].Item1 > 7 || lepesek[i].Item2 < 0 || lepesek[i].Item2 > 7)
                {
                    lepesek.Remove(lepesek[i]);
                    i--;
                }
            }

            return lepesek;
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();
            bool[] rossziranyok = { false, false, false, false };
            foreach (var item in lepesek)
            {
                //jobb le
                if (helyX < item.Item1 && helyY < item.Item2 && rossziranyok[0] == false)
                {
                    if (tablaAllas[item.Item1, item.Item2] == null)
                    {
                        joLepesek.Add(item);
                    }
                    else
                    {
                        if (tablaAllas[item.Item1, item.Item2].Szin != Szin)
                        {
                            joLepesek.Add(item);
                        }
                        rossziranyok[0] = true;
                    }
                }
                //bal le
                else if (helyX < item.Item1 && helyY > item.Item2 && rossziranyok[1] == false)
                {
                    if (tablaAllas[item.Item1, item.Item2] == null)
                    {
                        joLepesek.Add(item);
                    }
                    else
                    {
                        if (tablaAllas[item.Item1, item.Item2].Szin != Szin)
                        {
                            joLepesek.Add(item);
                        }
                        rossziranyok[1] = true;
                    }
                }
                //jobb fel
                else if (helyX > item.Item1 && helyY < item.Item2 && rossziranyok[2] == false)
                {
                    if (tablaAllas[item.Item1, item.Item2] == null)
                    {
                        joLepesek.Add(item);
                    }
                    else
                    {
                        if (tablaAllas[item.Item1, item.Item2].Szin != Szin)
                        {
                            joLepesek.Add(item);
                        }
                        rossziranyok[2] = true;
                    }
                }
                //bal fel
                else if (helyX > item.Item1 && helyY > item.Item2 && rossziranyok[3] == false)
                {
                    if (tablaAllas[item.Item1, item.Item2] == null)
                    {
                        joLepesek.Add(item);
                    }
                    else
                    {
                        if (tablaAllas[item.Item1, item.Item2].Szin != Szin)
                        {
                            joLepesek.Add(item);
                        }
                        rossziranyok[3] = true;
                    }
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
