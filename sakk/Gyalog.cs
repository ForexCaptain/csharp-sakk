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
                       
            if (Szin=="fekete")
	        {
                if (helyY == 1)
	            {
                    //fekete lepesek
               
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY+2));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY+1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY+1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY+1));
	            }

                else
	            {
                
                    //fekete lepesek
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY+1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY+1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY+1));         
               
	            }
	        }

            else
	        {
                if (helyY == 6)
	            {
                    //feher lepesek
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX, helyY-2));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY-1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY-1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY-1));
	            }

                else
	            {
                
                    //feher lepesek
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX,helyY-1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX+1,helyY-1));
                    lehetsegesLepesek.Add(new Tuple<int, int>(helyX-1,helyY-1));

	            }
	        }
            for (int i = 0; i < lehetsegesLepesek.Count; i++)
			{
                if (lehetsegesLepesek[i].Item1<0 || lehetsegesLepesek[i].Item2>8)
	            {
                    lehetsegesLepesek.Remove(lehetsegesLepesek[i]);
	            }
  			}
            
           
           
           return lehetsegesLepesek;
           
        }

        public override List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas)
        {
            List<Tuple<int, int>> lepesek = LehetsegesLepesek();
            List<Tuple<int, int>> joLepesek = new List<Tuple<int, int>>();



            foreach (var item in lepesek)
	        {
                if (tablaAllas[item.Item1,item.Item2] == null )
	            {
                    joLepesek.Add(item);
	            }

                //else if (tablaAllas[item.Item1,item.Item2] != null && tablaAllas[item.Item1,item.Item2].Szin != tablaAllas[item.Item1,item.Item2].Szin)
	            //{
                //    joLepesek.Add(item);
	            //}
                
	        }
            Console.WriteLine(joLepesek);
            //return joLepesek;
            

            for (int i = 0; i < lepesek.Count; i++)
			{
                Console.WriteLine(lepesek[i]);
			}
            Console.ReadKey();
            
            return lepesek;
            
        }

        public override Babu Copy(Babu hova)
        {
            hova = new Gyalog(HelyX, HelyY, Szin);
            return hova;
        }
    }
}
