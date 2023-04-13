using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudelkoLib
{
    public class Pudelko
    {
        public double A { get; init; }
        public double B { get; init; }
        public double C { get; init; }

        public Pudelko()
        {
            A = 100;
            B = 100;
            C = 100;
        }
        public Pudelko(double l, double w, double h)
        {
            A = l;
            B = w;
            C = h;
        }
    }
}
