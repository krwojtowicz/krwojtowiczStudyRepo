using System.Runtime.Serialization.Formatters;

namespace sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                int[] input = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);
                for(int j = 0; j < 9; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            bool resolved = true;
            //sprawdzanie poziomo i pionowo
            for(int i = 0; i < 9; i++)
            {
                for(int k = 0; k < 9; k++)
                {
                    for(int l = k+1; l <9; l++)
                    {
                        if (matrix[i,k] == matrix[i, l])
                        {
                            resolved = false;
                            break;
                        }

                        if (matrix[k, i] == matrix[l, i])
                        {
                            resolved = false;
                            break;
                        }
                    }
                }

            }


            //sprawdzanie w częściach
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            for (int m = l + 1; m < 3; m++)
                            {
                                if (matrix[k, l] == matrix[k, m])
                                {
                                    resolved = false;
                                    break;
                                }
                                if (matrix[l, k] == matrix[m, k])
                                {
                                    resolved = false;
                                    break;
                                }
                            }
                        }

                    }
                }
            }

            if (resolved)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

        }
    }
}