using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    class Program
    {
        static void Main(string[] args)
        {
            //Teszt kód a tábla kirajzoláshoz, később törölni
            //Új játék kezdése
            Tabla s = new Tabla();
            Console.BackgroundColor = ConsoleColor.Red;
            s.TablaKirajzolas();

            Console.WriteLine();
            //Elkezdett játék betöltése
            Tabla teszt = new Tabla(Fajlkezeles.Betoltes());
            teszt.TablaKirajzolas();

            //ToDo: Tesztprogram elkészítése

            Console.ReadKey();
        }
    }
}
