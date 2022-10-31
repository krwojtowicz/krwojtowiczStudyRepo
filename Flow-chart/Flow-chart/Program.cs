namespace Flow_chart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] inputedNumbers = Array.ConvertAll<string, int>(input.Split(" "), int.Parse);
            int x = inputedNumbers[0];
            int y = inputedNumbers[1];
            int z = inputedNumbers[2];
            for (int i = x; x > 0; i += 0)
            {
                if (y > 0)
                {
                    x = x - 1;
                    y = y - 1;
                    Console.Write("C");
                    continue;
                }
                else
                {
                    Console.Write("D");
                    if (z > 0)
                    {
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        Console.Write("G");
                        Console.WriteLine();
                        return;
                    }
                }
            }
            Console.Write("EG");
            Console.WriteLine();
        }
    }
}
/*
 * Użycie While
           string input = Console.ReadLine();
            int[] inputedNumbers = Array.ConvertAll<string, int>(input.Split(" "), int.Parse);
            int x = inputedNumbers[0];
            int y = inputedNumbers[1];
            int z = inputedNumbers[2];
            
            while(x > 0)
            {
                if(y > 0)
                {
                    x = x - 1;
                    y = y - 1;
                    Console.Write("C");
                    continue;
                }
                else
                {
                    Console.Write("D");
                    if(z > 0)
                    {
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        Console.Write("G");
                        Console.WriteLine();
                        return;
                    }
                }
            }
            Console.Write("EG");
            Console.WriteLine();
 */
/*
  użycie GOTO
            string input = Console.ReadLine();
            int[] inputedNumbers = Array.ConvertAll<string, int>(input.Split(" "), int.Parse);
            int x = inputedNumbers[0];
            int y = inputedNumbers[1];
            int z = inputedNumbers[2];
            Start:
            if (x > 0)
                goto checkY;
            else
            {
                Console.Write("E");
                goto writeG;
            }   
            
            checkY:
            if (y > 0)
            {
                x = x - 1;
                y = y - 1;
                Console.Write("C");
                goto Start;
            }
            else
            {
                Console.Write("D");
                goto checkZ;
            }

            checkZ:
            if (z > 0)
                goto End;
            else
                goto writeG;
            writeG:
            Console.Write("G");

            End:
            Console.WriteLine();
 */