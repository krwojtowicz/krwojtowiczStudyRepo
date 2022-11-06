namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -2, -1, 0, 1, 4 };
            int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
            Print(a, b);
            static void Print(int[] a, int[] b)
            {
                string output = "  ";
                int lastPrinted = int.MinValue;
                if (a[0] == lastPrinted)
                {
                    if (b[0] == lastPrinted)
                    {
                        lastPrinted = int.MaxValue;
                    }
                }
                for (int i = 0; i < a. Length; i++ )
                {
                    bool exist = false;
                    for(int j = 0; j < b.Length; j++)
                    {
                        if (a[i] == b[j])
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                    {
                        if (a[i] != lastPrinted)
                        {
                            output += $"{a[i]} ";
                            lastPrinted = a[i];
                        }
                    }
                }

                for (int i = 0; i < b.Length; i++)
                {
                    bool exist = false;
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (b[i] == a[j])
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                    {
                        if (b[i] != lastPrinted)
                        {
                            output += $"{b[i]} ";
                            lastPrinted = b[i];
                        }
                    }
                }
                output = output.Trim();
                if (output.Length == 0)
                    Console.Write("empty");
                else
                    Console.Write(output);

            }

        }
    }
}