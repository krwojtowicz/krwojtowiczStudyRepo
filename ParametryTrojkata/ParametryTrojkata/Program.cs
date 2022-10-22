using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Zadanie_ParametryTrojkata
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            string[] userInput = Console.ReadLine().Trim().Split("; ");
            double[] inputNumbers = new double[3];
            for(int i = 0; i < 3; i++)
            {
                inputNumbers[i] = double.Parse(userInput[i]);
                if (inputNumbers[i] < 0)
                {
                    Console.WriteLine("Błędne dane. Długości boków muszą być dodatnie!");
                    return;
                }
            }
            double a = inputNumbers[0];
            double b = inputNumbers[1];
            double c = inputNumbers[2];

            if ((a + b < c) || (a + c < b) || (c + b < a))
            {
                Console.WriteLine("Błędne dane. Trójkąta nie można zbudować!");
                return;
            }
            // wczytaj dane
            // i wykonaj obliczenia
        }
    }
}