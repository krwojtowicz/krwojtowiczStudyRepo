using System;

namespace LedNumbers
{
    class Program
    {
        static void Main()
        {
            // Twój kod
            string input = Console.ReadLine();
            string o1 = "";
            string o2 = "";
            string o3 = "";
            foreach (char number in input){
                switch (number)
                {
                    case '0':
                        o1 += " _ ";
                        o2 += "| |";
                        o3 += "|_|";
                        break;
                    case '1':
                        o1 += "   ";
                        o2 += "  |";
                        o3 += "  |";
                        break;
                    case '2':
                        o1 += " _ ";
                        o2 += " _|";
                        o3 += "|_ ";
                        break;
                    case '3':
                        o1 += " _ ";
                        o2 += " _|";
                        o3 += " _|";
                        break;
                    case '4':
                        o1 += "   ";
                        o2 += "|_|";
                        o3 += "  |";
                        break;
                    case '5':
                        o1 += " _ ";
                        o2 += "|_ ";
                        o3 += " _|";
                        break;
                    case '6':
                        o1 += " _ ";
                        o2 += "|_ ";
                        o3 += "|_|";
                        break;
                    case '7':
                        o1 += " _ ";
                        o2 += "  |";
                        o3 += "  |";
                        break;
                    case '8':
                        o1 += " _ ";
                        o2 += "|_|";
                        o3 += "|_|";
                        break;
                    case '9':
                        o1 += " _ ";
                        o2 += "|_|";
                        o3 += "  |";
                        break;
                }
            }
            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.WriteLine(o3);
        }
    }
}