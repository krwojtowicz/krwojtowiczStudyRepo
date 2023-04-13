namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wzorek(10);
        }
        public static void Wzorek(int n)
        {
            int wysokosc = n;
            if (wysokosc % 2 == 0) wysokosc--;
            int odstep = (wysokosc - 2) /2;

            for (int i = 0; i < wysokosc; i++)
            {
                if(i == 0 || i == wysokosc-1 || i == 1 + odstep)
                {
                    for(int j = 0; j < n-1; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(j == n - 1) 
                            Console.Write("*");
                        else 
                            Console.Write(" ");
                    }
                }
                
                Console.WriteLine();
            }

        }
        public static double TriangleIsoscelesPerimeter(int basis, int height, int precision = 2)
        {
            if (precision < 2) throw new ArgumentOutOfRangeException("wrong arguments");
            if (precision > 8) throw new ArgumentOutOfRangeException("wrong arguments");
            if (basis < 0) throw new ArgumentOutOfRangeException("wrong arguments");
            if (height < 0) throw new ArgumentOutOfRangeException("wrong arguments");
            double halfBasis = (double)basis / 2;
            double frame = (double)Math.Sqrt((double)halfBasis * halfBasis + (double)height*height);
            if (basis > 2 * frame) throw new ArgumentException("object not exist");

            double circuit = 2 * frame + basis;

            circuit = Math.Round(circuit, precision);

            return circuit;

        }
        static void Zad3()
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);
                int c = int.Parse(input[2]);

                int max = a;
                int min = a;
                if (b > max) max = b;
                if (b < min) min = b;
                if (c > max) max = c;
                if (c < min) min = c;

                checked
                {
                    int rozstep = max - min;
                    Console.WriteLine(rozstep);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("format exception, exit");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("argument exception, exit");
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

        public static void Print(int[] a, int[] b)
        {
            int[] wynik = new int[a.Length + b.Length];
            int tabIndex = 0;
            for (int i = 0; i < a.Length; i++)
            {
                bool aExist = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j]) aExist = true;
                }
                if (!aExist)
                {
                    wynik[tabIndex] = a[i];
                    tabIndex++;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                bool aExist = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (b[i] == a[j]) aExist = true;
                }
                if (!aExist)
                {
                    wynik[tabIndex] = b[i];
                    tabIndex++;
                }
            }
            if (tabIndex == 0) Console.WriteLine("empty");
            else
            {
                int[] wynik2 = new int[tabIndex];
                for (int i = 0; i < wynik2.Length; i++)
                {
                    wynik2[i] = wynik[i];
                }
                Array.Sort(wynik2);

                for (int i = 0; i < wynik2.Length; i++)
                {
                    if (i == 0) Console.Write(wynik2[i]);
                    else
                    {
                        if (wynik2[i] != wynik2[i - 1])
                        {
                            Console.Write($" {wynik2[i]}");
                        }
                    }
                }
            }

        }

    }
}