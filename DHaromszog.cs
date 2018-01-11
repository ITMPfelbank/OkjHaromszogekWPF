using System;

namespace Haromszogek
{
    class DHaromszog
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;

        public double a
        {
            get { return aOldal; }
            set
            {
                if (value > 0) aOldal = value;
                else throw new Exception("Az 'a' oldal nem lehet nulla vagy negatív!");
            }
        }

        public double b
        {
            get { return bOldal; }
            set
            {
                if (value > 0) bOldal = value;
                else throw new Exception("A 'b' oldal nem lehet nulla vagy negatív!");
            }
        }

        public double c
        {
            get { return cOldal; }
            set
            {
                if (value > 0) cOldal = value;
                else throw new Exception("A 'c' oldal nem lehet nulla vagy negatív!");
            }
        }

        public int SorSzama { get; private set; }


        public DHaromszog(string sor, int sorSzáma)
        {
            string[] m = sor.Split();
            SorSzama = sorSzáma;
            a = double.Parse(m[0]);
            b = double.Parse(m[1]);
            c = double.Parse(m[2]);
            if (!EllNovekvoSorrend) throw new Exception("Az adatok nicsenek növekvő rendben!");
            if (!EllMegszerkesztheto) throw new Exception("A háromszöget nem lehet megszerkeszteni!");
            if (!EllDerekszogu) throw new Exception("A háromszög nem derékszögű!");
        }

        private bool EllNovekvoSorrend
        {
            get
            {
                return a <= b && b <= c;
            }
        }

        private bool EllMegszerkesztheto
        {
            get
            {
                return a + b > c;
            }
        }

        private bool EllDerekszogu
        {
            get
            {
                return Math.Pow(c, 2) == Math.Pow(a, 2) + Math.Pow(b, 2);
            }
        }

        public double Terulet
        {
            get
            {
                return a * b / 2;
            }
        }

        public double Kerulet
        {
            get
            {
                return a + b + c;
            }
        }

        public override string ToString()
        {
            return String.Format($"{SorSzama}. sor: a={a} b={b} c={c}");
        }

    }
}
