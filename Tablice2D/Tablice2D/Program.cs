using System.Collections.Generic;
namespace Tablice2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zad3();
        }
        static void Zad3()
        {
            List<int[]> list = new List<int[]>();
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                int[] inputLine = Array.ConvertAll<string, int>(input.Trim().Split(), int.Parse);
                list.Add(inputLine);
            }
            //cała logika polega na tym że do pierwszego wierwsza 2D arraya (pierwszego arraya w liście), dodaje pozostałe.
            for(int i = 1; i < list.Count; i++)
            {
                for(int j = 0; j < list[i].Length; j++)
                {
                    list[0][j] += list[i][j]; 
                }
            }
            //szukam maksymalnej sumy i jej indeksu
            int maxIndex = 0;
            int maxSuma = list[0][0];
            for(int i=1; i < list[0].Length; i++)
            {
                if(list[0][i] > maxSuma)
                {
                    maxIndex = i;
                    maxSuma = list[0][i];
                }
            }
            Console.WriteLine(maxIndex);

        }
        static void Zad2()
        {
            int[] input = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
            int[] input2 = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
            int[] input3 = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
            int[] input4 = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
            int n1 = input[0];
            int m1 = input[1];
            int[,] A = new int[n1, m1];
            int counter = 0;
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    A[i, j] = input2[counter];
                    counter++;
                    //Console.WriteLine(A[i, j]);
                }
            }
            int n2 = input3[0];
            int m2 = input3[1];
            int[,] B = new int[n2, m2];
            counter = 0;
            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    B[i, j] = input4[counter];
                    counter++;
                }
            }

            if (m1 != n2)
            {
                Console.WriteLine("impossible");
            }
            else
            {
                int[,] iloczynAB = new int[n1, m2];
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        int wynik = 0;
                        for (int k = 0; k < n2; k++)
                        {
                            wynik += (A[i, k] * B[k, j]);
                            
                        }
                        iloczynAB[i, j] = wynik;
                        Console.Write($"{iloczynAB[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }



        }
        static void Zad1()
        {
            int[] input = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
            int n = input[0];
            int m = input[1];

            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int[] row = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[j, i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

