using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakk
{
    abstract class Babu
    {
        protected int helyX;
        protected int helyY;
        public enum BabuTipus
        {
            Bastya, Huszar, Futo, Kiraly, Vezer, Gyalog
        }

        public Babu(int helyX, int helyY, string szin)
        {
            this.helyX = helyX;
            this.helyY = helyY;
            Szin = szin;
            Jeloles = " ";
        }

        public int HelyX { get { return helyX; } set { helyX = value; } }
        public int HelyY { get { return helyY; } set { helyY = value; } }

        public abstract string Jeloles { get; protected set; }
        public string Szin { get; set; }
        public BabuTipus Tipus { get; protected set; }

        public abstract List<Tuple<int, int>> LehetsegesLepesek();
        public abstract List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas);
        public abstract Babu Copy(Babu hova);
    }
}
