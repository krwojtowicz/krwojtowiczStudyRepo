
namespace SPOJ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            while (true)
            {
                string output = "";
                string input1 = Console.ReadLine();
                if (string.IsNullOrEmpty(input1)) break;
                string input2 = Console.ReadLine();
                string input3 = Console.ReadLine();
                int length = (input1.Length / 3);
                string[,] array = new string[length, 3];
                
                for (int i = 0; i < length; i++)
                {

                    array[i, 0] = $"{input1[3 * i + 0]}{input1[3 * i + 1]}{input1[3 * i + 2]}";
                    array[i, 1] = $"{input2[3 * i + 0]}{input2[3 * i + 1]}{input2[3 * i + 2]}";
                    array[i, 2] = $"{input3[3 * i + 0]}{input3[3 * i + 1]}{input3[3 * i + 2]}";
                    if (array[i, 0] == "   " && array[i, 1] == "  |" && array[i, 2] == "  |")
                    {
                        output += 1;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == " _|" && array[i, 2] == "|_ ")
                    {
                        output += 2;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == " _|" && array[i, 2] == " _|")
                    {
                        output += 3;
                    }
                    if (array[i, 0] == "   " && array[i, 1] == "|_|" && array[i, 2] == "  |")
                    {
                        output += 4;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == "|_ " && array[i, 2] == " _|")
                    {
                        output += 5;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == "|_ " && array[i, 2] == "|_|")
                    {
                        output += 6;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == "  |" && array[i, 2] == "  |")
                    {
                        output += 7;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == "|_|" && array[i, 2] == "|_|")
                    {
                        output += 8;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == "|_|" && array[i, 2] == "  |")
                    {
                        output += 9;
                    }
                    if (array[i, 0] == " _ " && array[i, 1] == "| |" && array[i, 2] == "|_|")
                    {
                        output += 0;
                    }

                }
                Console.WriteLine(output);
            }
           
        }

        
    }
}