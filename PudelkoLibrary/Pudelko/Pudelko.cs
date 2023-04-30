using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PudelkoLib
{


    public enum UnitOfMeasure { milimeter, centimeter, meter }
    public class Pudelko : IEquatable<Pudelko>, IEnumerator, IEnumerable
    {
       
        //values are stored in 'm'
        private double _a;
        private double _b;
        private double _c;
        private int position = -1;
        public double A
        {
            get
            {
                return _a;
            }
            init
            {
                if (value < 0 || value > 10)
                {
                    throw new System.ArgumentOutOfRangeException();
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

        public double Obj
        {
            get { return Math.Round(_a * _b * _c, 9); }
        }

        public double Pc
        {
            get { return Math.Round(2 * (_a * _b + _a * _c + _b * _c), 6); }
        }
        public Pudelko()
        {
            A = 0.1;
            B = 0.1;
            C = 0.1;
        }
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure? unit = UnitOfMeasure.meter)
        {
            int dzielnik = 1;
            double domyslnie = 0.1;

            switch (unit)
            {
                case UnitOfMeasure.milimeter:
                    dzielnik = 1000;
                    break;
                case UnitOfMeasure.centimeter:
                    dzielnik = 100;
                    break;
                case UnitOfMeasure.meter:
                    break;
                default:
                    break;
            }

           
            
            if (c != null) c = Math.Round((double)(c / dzielnik), 3);
            else c = domyslnie;
            if (b != null) b = Math.Round((double)(b / dzielnik), 3);
            else b = domyslnie;
            if (a != null) a = Math.Round((double)(a / dzielnik), 3);
            else a = domyslnie;

            if ((c > 0 && c <= 10) && (b > 0 && b <= 10) && (a > 0 && a <= 10))
            {
                C = (double)c;
                B = (double)b;
                A = (double)a;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"{A:0.000} m x {B:0.000} m x {C:0.000} m";
        }

        public string ToString(string format)
        {
            switch (format)
            {
                case "m":
                    return this.ToString();
                case "cm":
                    return $"{A * 100:0.0} cm x {B * 100:0.0} cm x {C * 100:0.0} cm";
                case "mm":
                    return $"{A * 1000} mm x {B * 1000} mm x {C * 1000} mm";
                default:
                    throw new FormatException();
            }
        }

        public bool Equals(Pudelko other)
        {
            if (other == null) return false;
            double[] arr1 = new double[] { _a, _b, _c };
            double[] arr2 = new double[] { other.A, other.B, other.C };
            Array.Sort(arr1);
            Array.Sort(arr2);
            if (arr1[0] == arr2[0] && arr1[1] == arr2[1] && arr1[2] == arr2[2])
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return _a.GetHashCode() + _b.GetHashCode() + _c.GetHashCode();
        }

        public static bool operator ==(Pudelko p1, Pudelko p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            return !p1.Equals(p2);
        }

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double[] arr1 = new double[] { p1.A, p1.B, p1.C };
            double[] arr2 = new double[] { p2.A, p2.B, p2.C };
            Array.Sort(arr1);
            Array.Sort(arr2);
            double b = 0;
            double c = 0;
            if (arr1[1] > arr2[1])
                b = arr1[1];
            else
                b = arr2[1];

            if (arr1[2] > arr2[2])
                c = arr1[2];
            else
                c = arr2[2];

            return new Pudelko(arr1[0] + arr2[0], b, c);
        }

        public static explicit operator double[](Pudelko obj)
        {
            return new double[] { obj.A, obj.B, obj.C };
        }

        public static implicit operator Pudelko(ValueTuple<int, int, int> obj)
        {
            return new Pudelko(obj.Item1, obj.Item2, obj.Item3, UnitOfMeasure.milimeter);
        }

        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return A;
                    case 1:
                        return B;
                    case 2:
                        return C;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < 3);
        }
        //IEnumerable
        public void Reset()
        {
            position = -1;
        }
        //IEnumerable
        public object Current
        {
            get { return this[position]; }
        }

        public static Pudelko Parse(string input)
        {
            string[] s = input.Split(' ');

            if (s[1] == "m")
            {
                return new Pudelko(double.Parse(s[0]), double.Parse(s[3]), double.Parse(s[6]));
            }
            else if (s[1] == "cm")
            {
                return new Pudelko(double.Parse(s[0]), double.Parse(s[3]), double.Parse(s[6]), UnitOfMeasure.centimeter);
            }
            else
            {
                return new Pudelko(double.Parse(s[0]), double.Parse(s[3]), double.Parse(s[6]), UnitOfMeasure.milimeter);
            }
        }




    }
}
