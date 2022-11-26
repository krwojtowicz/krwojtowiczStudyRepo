using System;
using System.Net.Http.Headers;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] a = new int[] { -2, -1, 0, 1, 4, 4 };
            //int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
            //int[] a = new int[] { 0, 1, 1, 2, 3, 3, 3, 4 };
            //int[] b = new int[] { 0, 1, 2, 3, 3 };
            int[] a = new int[] { -2, -1, 0, 1, 4 ,7,8,9};
            int[] b = new int[] { -2, -1, 0, 1, 4, 5, 6 };
            //int[] a = new int[] { };
            //int[] b = new int[] { };

            Print(a, b);
            static void Print(int[] a, int[] b)
            {
                bool AinB = false;
                string AnotInBstring = "";
                foreach (int i in a)
                {
                    AinB = false;
                    foreach (int j in b)
                    {
                        if (i == j)
                        {
                            AinB = true;
                            break;
                        }
                    }
                    if (!AinB)
                    {
                        AnotInBstring += $"{i} ";
                        
                    }
                }

                bool BinA = false;
                foreach (int j in b)
                {
                    BinA = false;
                    foreach (int i in a)
                    {
                        if (j == i)
                        {
                            BinA = true;
                            break;
                        }
                    }
                    if (!BinA)
                    {
                        AnotInBstring += $"{j} ";

                    }
                }
                
                if(AnotInBstring == "")
                    Console.WriteLine("empty");
                else
                {
                    int[] tab = Array.ConvertAll<string,int>(AnotInBstring.Trim().Split(" "), int.Parse);
                   
                    for(int i = 1; i < tab.Length; i++)
                    {
                        for(int j = 0; j < i; j++)
                        {
                            if (tab[j] > tab[i])
                            {
                                int temp = tab[i];
                                tab[i] = tab[j];
                                tab[j] = temp;
                            }
                        }
                        
                    }
                    string wynik = $"{tab[0]} ";
                    for(int i = 1; i < tab.Length; i++)
                    {
                        if (tab[i] != tab[i - 1])
                            wynik += $"{tab[i]} ";
                    }
                    Console.WriteLine(wynik);
                }
                



            }

        }
    }
}