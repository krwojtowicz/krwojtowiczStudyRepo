namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] a = new int[] { -2, -1, 0, 1, 4 };
            //int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
            //int[] a = new int[] { 0, 1, 1, 2, 3, 3, 3 };
            //int[] b = new int[] { 0, 1, 2, 3, 3 };
            int[] a = new int[] { -2, -1, 0, 1, 4 };
            int[] b = new int[] { -2, -1, 0, 1, 4, 5, 6 };

            Print(a, b);
            static void Print(int[] a, int[] b)
            {
                int repeatedValues = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (a[i] == b[j])
                        {
                            repeatedValues++;
                            break;
                        }
                    }
                }
                int resultLength = a.Length + b.Length - 2 * repeatedValues;
                if(resultLength <= 0)
                {
                    Console.WriteLine("empty");
                    return;
                }
                int[] result = new int[resultLength];
                int k = 0;
                int aI = 0;
                int bI = 0;
                while(k < resultLength)
                {
                    if(aI == a.Length)
                    {
                        while(bI < b.Length)
                        {
                            result[k] = b[bI];
                            bI++;
                            k++;
                        }
                        continue;
                    }
                    if (bI == b.Length)
                    {
                        while (aI < a.Length)
                        {
                            result[k] = a[aI];
                            aI++;
                            k++;
                        }
                        continue;
                    }
                    Console.WriteLine($"{aI } {bI}");
                    if (a[aI] < b[bI])
                    {
                        result[k] = a[aI];
                        aI++;
                        k++;
                    }
                    else if (a[aI] > b[bI])
                    {
                        result[k] = b[bI];
                        bI++;
                        k++;
                    }
                    else
                    {
                        while (a[aI] == b[bI])
                        {
                            if (aI == a.Length - 1)
                                break;
                            else
                                aI++;
                        }
                        while(a[aI-1] == b[bI])
                        {
                            if (bI == b.Length - 1)
                                break;
                            else
                                bI++;
                        }
                    }
                }
                foreach(int x in result) 
                {
                    Console.Write($"{x} ");
                }
               
            }

        }
    }
}