using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sakk
{
    class Tabla
    {
        public Babu[,] tablaAllas = new Babu[8, 8];

        //Új játék betöltése
        public Tabla()
        {
            Fajlkezeles.Betoltes("alap.txt", ref tablaAllas);
        }

        //Elkezdett játék betöltése
        public Tabla(string fajlnev)
        {
            Fajlkezeles.Betoltes(fajlnev, ref tablaAllas);
        }

        public bool Lepes(int kezdoHelyX, int kezdoHelyY, int celHelyX, int celHelyY)
        {
            //király sakkban van-e, túlindexelés megoldása még szükséges
            if (tablaAllas[kezdoHelyX, kezdoHelyY].JoLepesek(tablaAllas).Contains(new Tuple<int, int>(celHelyX, celHelyY)))
            {
                tablaAllas[kezdoHelyX, kezdoHelyY].HelyX = celHelyX;
                tablaAllas[kezdoHelyX, kezdoHelyY].HelyY = celHelyY;
                tablaAllas[celHelyX, celHelyY] = tablaAllas[kezdoHelyX, kezdoHelyY].Copy(tablaAllas[celHelyX, celHelyY]);
                tablaAllas[kezdoHelyX, kezdoHelyY] = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TablaKirajzolas()
        {
            //tennivaló: kód rendbeszedése
            Console.BackgroundColor = ConsoleColor.Red;
            char[] betuk = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            int kiirandoSorokSzama = 18;
            for (int j = 0; j < kiirandoSorokSzama; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (j == kiirandoSorokSzama - 1)
                        Console.Write($"  {betuk[i]} ");
                    else
                    {
                        if (j % 2 == 0)
                            Console.Write("+---");
                        else
                        {
                            if (tablaAllas[i, j / 2] != null)
                            {
                                if (tablaAllas[i, j / 2].Szin == "fekete")
                                {
                                    Console.Write("| ");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{tablaAllas[i, j / 2].Jeloles} ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.Write($"| {tablaAllas[i, j / 2].Jeloles} ");
                                }
                            }
                            else
                            {
                                Console.Write("|   ");
                            }
                        }
                    }
                }
                if (j == kiirandoSorokSzama - 1)
                    Console.Write("    \n");
                else
                {
                    if (j % 2 == 0)
                        Console.Write("+   \n");
                    else
                        Console.Write($"| {(kiirandoSorokSzama - j) / 2} \n");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
