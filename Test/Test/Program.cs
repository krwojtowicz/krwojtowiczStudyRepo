namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[,] tab = new int[,] { { 1, 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2, 2 }, { 3, 3, 3, 3, 3, 3 } };
            ////int[,] tab = new int[,] { { 1, 1 }, { 2, -1 } };
            //Console.WriteLine(Srednia(tab));
            Zad3();
        }

        public static double Srednia(int[,] tab)
        {
            if (tab == null || tab.Length == 0) return 0.00;
            int n = 0;
            int suma = 0;
            foreach (int elem in tab)
            {
                if (elem > 0)
                {
                    suma += elem;
                    n++;
                }
            }
            if (n == 0) return 0.00;

            double srednia = suma / (double)n;
            srednia = Math.Round(srednia,2);

            return srednia;
        }

        public static void Zad3()
        {

            int a;
            int b;
            int c;
            int wynik = 0;
            try
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                string input3 = Console.ReadLine();
                if (input1 == "" || input2 == "" || input3 == "") throw new ArgumentException();
                a = int.Parse(input1);
                b = int.Parse(input2);
                c = int.Parse(input3);

                checked
                {
                    wynik = a + b + c;
                }
                Console.WriteLine(wynik);
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
        public static double TriangleArea(int a, int b, int c, int precision = 2)
        {
            if (precision < 2) throw new ArgumentOutOfRangeException("wrong arguments");
            if (precision > 8) throw new ArgumentOutOfRangeException("wrong arguments");
            if (a < 0) throw new ArgumentOutOfRangeException("wrong arguments");
            if (b < 0) throw new ArgumentOutOfRangeException("wrong arguments");
            if (c < 0) throw new ArgumentOutOfRangeException("wrong arguments");

            if (a < c && b < c && (a + b < c)) throw new ArgumentException("object not exist");
            if (a < b && c < b && (a + c < b)) throw new ArgumentException("object not exist");
            if (c < a && b < a && (c + b < a)) throw new ArgumentException("object not exist");

            double p = ((double)a + b + c) / 2;
            double pole = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            pole = Math.Round(pole, precision);

            return pole;
        }
      
        public static void Wzorek(int n = 2)
        {
            if (n % 2 == 0)
            {
                n--;
            }
            int spacje = 0;
            for (int i = n; i > 0; i--)
            {
                if (i % 2 == 0) continue;
                for (int k = 0; k < spacje; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                spacje++;
                Console.WriteLine();

            }
        }
    }
}