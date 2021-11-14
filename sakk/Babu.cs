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
        public string jeloles;

        protected Babu(int helyX, int helyY, string szin, string jeloles)
        {
            this.helyX = helyX;
            this.helyY = helyY;
            Szin = szin;
            Jeloles = jeloles;
        }

        public string Jeloles { get; set; }
        public string Szin { get; set; }
        public BabuTipus Tipus { get; protected set; }

        protected abstract IEnumerable<Tuple<int, int>> LehetsegesLepesek();
        public abstract List<Tuple<int, int>> JoLepesek(Babu[,] tablaAllas);
        public abstract Babu Copy(Babu hova);
    }
}
