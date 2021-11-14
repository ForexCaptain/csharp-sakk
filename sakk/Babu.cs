using System;
using System.Collections.Generic;

namespace sakk
{
    abstract class Babu
    {
        public int helyX;
        public int helyY;
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

        public abstract string Jeloles { get; protected set; }
        public string Szin { get; set; }
        public BabuTipus Tipus { get; protected set; }

        public abstract List<Tuple<int, int>> LehetsegesLepesek();
        public abstract List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas);
        public abstract Babu Copy(Babu hova);
    }
}
