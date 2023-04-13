using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudelkoLib
{
    public enum UnitOfMeasure { milimeter, centimeter, meter }
    public class Pudelko
    {
        //values are stored in 'm'
        private double _a;
        private double _b;
        private double _c;
        public double A 
        {
            get
            {
                return _a;
            }
            init
            {
                if(value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Invalid input", nameof(value));
                }
                _a = value;
                
            } 
        }
        public double B
        {
            get { return _b; }
            init
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _b = value;
            }
        }
        public double C
        {
            get { return _c; }
            init
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _c = value;
            }
        }
        public Pudelko()
        {
            A = 0.1;
            B = 0.1;
            C = 0.1;
        }
        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if(unit == UnitOfMeasure.meter)
            {
                A = a;
                B = b;
                C = c;
            }
            else if(unit == UnitOfMeasure.centimeter)
            {
                A = a / 100;
                B = b / 100;
                C = c / 100;
            }
            else if(unit == UnitOfMeasure.milimeter)
            {
                A = a / 1000;
                B = b / 1000;
                C = c / 1000;
            }
        }

        public override string ToString()
        {
            return $"{A:0.000} m x {B:0.000} m x {C:0.000} m";
        }

        public string ToString( string format)
        {
            switch (format)
            {
                case "m":
                    return this.ToString();
                case "cm":
                    return $"{A*100:0.0} cm x {B * 100:0.0} cm x {C * 100:0.0} cm";
                case "mm":
                    return $"{A*1000} mm x {B * 1000} mm x {C * 1000} mm";
                default:
                    throw new FormatException();
            }
        }
    }
}
