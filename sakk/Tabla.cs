using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Tabla
    {
        public Babu[,] tablaAllas = new Babu[8, 8];

        //Új játék tábla
        //ToDo: fájlból beolvasni ezt is, vagy valahogy szebbé tenni
        public Tabla()
        {
            tablaAllas[0, 0] = new Bastya(0, 0, "fekete");
            tablaAllas[0, 1] = new Huszar(0, 1, "fekete");
            tablaAllas[0, 2] = new Futo(0, 2, "fekete");
            tablaAllas[0, 3] = new Vezer(0, 3, "fekete");
            tablaAllas[0, 4] = new Kiraly(0, 4, "fekete");
            tablaAllas[0, 5] = new Futo(0, 5, "fekete");
            tablaAllas[0, 6] = new Huszar(0, 6, "fekete");
            tablaAllas[0, 7] = new Bastya(0, 7, "fekete");
            for (int j = 0; j < 8; j++)
            {
                tablaAllas[1, j] = new Gyalog(1, j, "fekete");
            }

            tablaAllas[7, 0] = new Bastya(7, 0, "feher");
            tablaAllas[7, 1] = new Huszar(7, 1, "feher");
            tablaAllas[7, 2] = new Futo(7, 2, "feher");
            tablaAllas[7, 3] = new Vezer(7, 3, "feher");
            tablaAllas[7, 4] = new Kiraly(7, 4, "feher");
            tablaAllas[7, 5] = new Futo(7, 5, "feher");
            tablaAllas[7, 6] = new Huszar(7, 6, "feher");
            tablaAllas[7, 7] = new Bastya(7, 7, "feher");
            for (int j = 0; j < 8; j++)
            {
                tablaAllas[6, j] = new Gyalog(6, j, "feher");
            }
        }

        //Elkezdett játék betöltése
        public Tabla(Babu[,] tablaAllas)
        {
            this.tablaAllas = tablaAllas;
        }

        //ToDo: metódus megvalósítása
        public void Lepes(int kezdoHelyX, int kezdoHelyY, int celHelyX, int celHelyY)
        {
            tablaAllas[6, 1].LehetsegesLepesek();
            throw new NotImplementedException();
        }

        public void TablaKirajzolas()
        {
            char[] betuk = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 17)
                        Console.Write($"  {betuk[j]} ");
                    else
                    {
                        if (i % 2 == 0)
                            Console.Write("+---");
                        else
                        {
                            if (tablaAllas[i / 2, j] != null)
                            {
                                if (tablaAllas[i / 2, j].Szin == "fekete")
                                {
                                    Console.Write("| ");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{tablaAllas[i / 2, j].Jeloles} ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.Write($"| {tablaAllas[i / 2, j].Jeloles} ");
                                }
                            }
                            else
                            {  
                                Console.Write("|   ");
                            }
                        }
                    }
                }
                if (i == 17)
                    Console.Write("    \n");
                else
                {
                    if (i % 2 == 0)
                        Console.Write("+   \n");
                    else
                        Console.Write($"| {(18 - i) / 2} \n");
                }
            }
        }
    }
}
