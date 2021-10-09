using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sakk
{
    class Fajlkezeles
    {
        public static Babu[,] Betoltes(string fajlnev, ref Babu[,] tablaAllas)
        {
            StreamReader r = new StreamReader(fajlnev);
            while (!r.EndOfStream)
            {
                string[] seged = r.ReadLine().Split(' ');
                switch (seged[0])
                {
                    case "B":
                        tablaAllas[int.Parse(seged[1]), int.Parse(seged[2])] = new Bastya(int.Parse(seged[1]), int.Parse(seged[2]), seged[3]);
                        break;
                    case "H":
                        tablaAllas[int.Parse(seged[1]), int.Parse(seged[2])] = new Huszar(int.Parse(seged[1]), int.Parse(seged[2]), seged[3]);
                        break;
                    case "F":
                        tablaAllas[int.Parse(seged[1]), int.Parse(seged[2])] = new Futo(int.Parse(seged[1]), int.Parse(seged[2]), seged[3]);
                        break;
                    case "V":
                        tablaAllas[int.Parse(seged[1]), int.Parse(seged[2])] = new Vezer(int.Parse(seged[1]), int.Parse(seged[2]), seged[3]);
                        break;
                    case "K":
                        tablaAllas[int.Parse(seged[1]), int.Parse(seged[2])] = new Kiraly(int.Parse(seged[1]), int.Parse(seged[2]), seged[3]);
                        break;
                    case "G":
                        tablaAllas[int.Parse(seged[1]), int.Parse(seged[2])] = new Gyalog(int.Parse(seged[1]), int.Parse(seged[2]), seged[3]);
                        break;
                }
            }
            r.Close();
            return tablaAllas;
        }

        //Laci
        public static void Mentes(Babu[,] allas)
        {
            //ToDo: Játék állás fájlba mentése
        }
    }
}
