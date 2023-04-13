namespace System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -2, -1, 0, 1, 4 };
            int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
            Console.WriteLine(a.Length);
            Print(a, b);
        }

        public static void Print(int[] a, int[] b)
        {
            int[] wynik = new int[a.Length + b.Length];
            int tabIndex = 0;
            for(int i = 0; i < a.Length; i++)
            {
                bool aExist = false;
                for(int j = 0; j < b.Length; j++)
                {
                    if(a[i] == b[j]) aExist = true;
                }
                if (!aExist)
                {
                    wynik[tabIndex] = a[i];
                    tabIndex++;
                }
            }

            foreach(var elem in wynik)
            {
                Console.WriteLine(elem);
            }
        }
        //public static double TriangleIsoscelesPerimeter(int basis, int height, int precision = 2)
        //{
        //    if (precision < 2) throw new ArgumentOutOfRangeException("wrong arguments");
        //    if (precision > 8) throw new ArgumentOutOfRangeException("wrong arguments");
        //    if (basis < 0) throw new ArgumentOutOfRangeException("wrong arguments");
        //    if (height < 0) throw new ArgumentOutOfRangeException("wrong arguments");

        //}
        public static void Wzorek(int n)
        {
            for(int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            Console.Write("*");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            Console.Write("*");
        }


    }
}