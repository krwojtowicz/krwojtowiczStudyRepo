namespace Lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //wczytywanie i parsowanie danych wejściowych
            string wejscie = Console.ReadLine();
            int[] dane = Array.ConvertAll<string, int>(wejscie.Split(" "), int.Parse);
            // Twój kod
            int a = 0;
            int b = 0;
            //odrazu zamieniam kolejnością żeby a było zawsze mniejsze od b
            if (dane[0] < dane[1])
            {
                a = dane[0];
                b = dane[1];
            }
            else
            {
                a = dane[1];
                b = dane[0];
            }
            int c = dane[2];
            int[] numsBetween = new int[b - a - 1];
            int divideCount = 0;
            for (int i = 0; i < numsBetween.Length; i++)
            {
                numsBetween[i] = a + i + 1;
                Console.WriteLine(numsBetween[i]);
                if( ((a + i + 1 ) % c) == 0)
                    divideCount++;
            }
            Console.WriteLine(a + " " + b + " " + numsBetween.Length);
            
        }
        /*
          lab3.2
         //wczytywanie i parsowanie danych wejściowych
            string wejscie = Console.ReadLine();
            int[] dane = Array.ConvertAll<string, int>(wejscie.Split(" "), int.Parse);
            // Twój kod
            int a = dane[0];
            int b = dane[1];

            if((a - b) == 0 || (a - b) == 1 || (a - b) == -1)
            {
                Console.WriteLine("empty");
            }
            else if( (a - b) < -11 || (a - b) > 11)
            {
                if (a < b)
                {
                    for (int i = (a + 1); i < b; i++)
                    {
                        if (i == a + 4)
                            Console.Write("..., ");
                        else if (i > a + 4 && i < b - 2)
                            Console.Write("");
                        else if (i == b - 1)
                            Console.Write($"{i}");
                        else
                            Console.Write($"{i}, ");
                    }
                }
                else
                {
                    for (int i = (b + 1); i < a; i++)
                    {
                        if (i == b + 4)
                            Console.Write("..., ");
                        else if (i > b + 4 && i < a - 2)
                            Console.Write("");
                        else if (i == a - 1)
                            Console.Write($"{i}");
                        else
                            Console.Write($"{i}, ");
                    }
                }
            }
            else if(a < b)
            {
                for(int i = (a + 1); i < b; i++)
                {
                    if (i == b - 1)
                        Console.Write($"{i}");
                    else
                        Console.Write($"{i}, ");
                }
            }
            else
            {
                for (int i = (b + 1); i < a; i++)
                {
                    if (i == a - 1)
                        Console.Write($"{i}");
                    else
                        Console.Write($"{i}, ");
                }
            }
         */
    }
}