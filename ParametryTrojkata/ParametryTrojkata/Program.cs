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
            double shortestSide = double.MaxValue;
            double longestSide = double.MinValue;
            double midSide = 0;
            for(int i = 0; i < 3; i++)
            {
                inputNumbers[i] = double.Parse(userInput[i]);
                if (shortestSide >= inputNumbers[i])
                {
                    midSide = shortestSide;
                    shortestSide = inputNumbers[i];
                }
                if(longestSide <= inputNumbers[i])
                {
                    midSide = longestSide;
                    longestSide = inputNumbers[i];
                }

                if (inputNumbers[i] <= 0)
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
            else
            {
                double circuit = a + b + c;
                double p = circuit / 2;
                double field = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine($"obwód = {Math.Round(circuit, 2).ToString("F2")}");
                Console.WriteLine($"pole = {Math.Round(field, 2).ToString("F2")}");
     
                if ((shortestSide * shortestSide) + (midSide * midSide) == (longestSide * longestSide))
                    Console.WriteLine("trójkąt jest prostokątny");
                if ((shortestSide * shortestSide) + (midSide * midSide) > (longestSide * longestSide))
                    Console.WriteLine("trójkąt jest ostrokątny");
                if ((shortestSide * shortestSide) + (midSide * midSide) < (longestSide * longestSide))
                    Console.WriteLine("trójkąt jest rozwartokątny");
                if (a == b && b == c)
                    Console.WriteLine("trójkąt równoboczny");
                else if (a == b || a == c || b == c)
                    Console.WriteLine("trójkąt równoramienny");
            }
        }
    }
}