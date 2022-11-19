namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -2, -2, -1, 0, 1, 3 ,4 ,6 };
            int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
           
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

                int[] result = new int[a.Length + b.Length - 2*repeatedValues];
                int aIncrement = 0;
                int bIncrement = 0;
                int k = 0;
                do
                {
                    //Console.WriteLine($"aI {aIncrement} a {a[aIncrement]}   bI {bIncrement} b {b[bIncrement]}");
                    if(aIncrement == a.Length)
                    {
                        aIncrement = a.Length - 1;
                        result[k] = b[bIncrement];
                        k++;
                    }
                    if(bIncrement == b.Length)
                    {
                        bIncrement = b.Length - 1;
                        result[k] = a[aIncrement];
                        k++;
                    }

                    if (a[aIncrement] < b[bIncrement])
                    {
                        result[k] = a[aIncrement];
                        aIncrement++;
                        k++;
                    }
                    else if (a[aIncrement] > b[bIncrement])
                    {
                        result[k] = b[bIncrement];
                        bIncrement++;
                        k++;
                    }
                    else
                    {
                        while (a[aIncrement] == b[bIncrement])
                        {
                            if (aIncrement == a.Length - 1)
                                break;
                            else
                                aIncrement++;     
                        }

                        while (b[bIncrement] == a[aIncrement - 1])
                        {
                            if (bIncrement == b.Length - 1)
                                break;
                            else
                                bIncrement++;
                            
                        }
                    }
                }
                while (k < result.Length);
                for(int i =0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }

        }
    }
}