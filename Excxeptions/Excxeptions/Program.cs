using System;
using System.Globalization;

namespace Excxeptions
{

    internal class Program
    {
        public static void TraingleException()
        {

            //string first = Console.ReadLine();
            //string second = Console.ReadLine();
            //string third = Console.ReadLine();
            try
            {
                int firstInt = int.Parse(Console.ReadLine());
                int secondInt = int.Parse(Console.ReadLine());
                int thirdInt = int.Parse(Console.ReadLine());
                //if (first == "" || second == "" || third == "")
                //    throw new ArgumentException();



                checked
                {
                    int result = firstInt * secondInt * thirdInt;
                    Console.WriteLine(result);
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("argument exception, exit");
            }
            catch (FormatException)
            {
                Console.WriteLine("format exception, exit");
            }
            catch (OverflowException)
            {
                Console.WriteLine("overflow exception, exit");
            }
            catch (Exception)
            {
                Console.WriteLine("non supported exception, exit");
            }
        }
        static void Main(string[] args)
        {
            QuadraticEquation(1000000, 6000, -300295);
        }

        public static void QuadraticEquation(int a, int b, int c)
        {
            //ax^2 + bx +c =0
            //delta = b^2 - 4ac
            //x1 = - b - sqrt(delta) / 2a      x2 = - b + sqrt(delta) / 2a
            
            double delta = ((double)b * (double)b) + ((-4) * (double)a * (double)c);
            Console.WriteLine(delta);

            if (a == b && b == c && c == 0)
            {
                Console.WriteLine("infinity");
                return;
            }
            else if ((a == 0 && b != 0 && c != 0) || (b != 0 && a == 0 && c == 0))
            {
                double x = -c / (double)b;
                Console.WriteLine($"x={x.ToString("0.00").Replace(',', '.')}");
                
            }
            else if (delta < 0 || (a == 0 && b ==0))
                Console.WriteLine("empty");
            else if (delta == 0)
            {

                double x = -b / (2 * a);
                Console.WriteLine($"x={x.ToString("0.00").Replace(',', '.')}");
            }
            else
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                ,
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"x1={x1.ToString("0.00").Replace(',', '.')}");
                Console.WriteLine($"x2={x2.ToString("0.00").Replace(',', '.')}");
            }

        }

        
        public static double TrianglePerimeter(int a, int b, int c, int precision = 2)
        {
            /// <summary>
            /// Oblicza obwód trójkąta dowolnego dla zadanych długości boków, zaokrąglając wynik do podanej liczby cyfr po przecinku
            /// </summary>
            /// <param name="a">długość pierwszego boku, liczba całkowita nieujemna</param>
            /// <param name="b">długość drugiego boku, liczba całkowita nieujemna</param>
            /// <param name="c">długość trzeciego boku, liczba całkowita nieujemna</param>
            /// <param name="precision">dokładność obliczeń (zaokrąglenie), liczba cyfr po przecinku (od 2 do 8)</param>
            /// <returns>obwód trójkąta obliczony z zadaną dokładnością</returns>
            /// <exception cref="ArgumentOutOfRangeException">z komunikatem "wrong arguments", 
            ///     gdy <c>precision</c> jest poza przedziałem od 2 do 8 lub którakolwiek z długości jest ujemna</exception>    
            /// <exception cref="ArgumentException">z komunikatem "object not exist", gdy trójkąta nie można utworzyć</exception>
            /// <remarks>dopuszczamy trójkąt o pokrywających się bokach lub o wszystkich bokach o długości 0</remarks>

            if (precision < 2 || precision > 8 || a < 0 || b < 0 || c < 0)
                throw new ArgumentOutOfRangeException("wrong arguments");
            if ((a + b < c) || (a + c < b) || b + c < a)
                throw new ArgumentException("object not exist");


            double p = Math.Round((double)a + b + c , 3);

            return p;
        }
    }
}