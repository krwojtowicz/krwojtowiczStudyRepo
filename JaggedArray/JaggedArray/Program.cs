namespace JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] jagged = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(jagged);
            jagged = TransposeJaggedArray(jagged);
            Console.WriteLine();
            PrintJaggedArrayToStdOutput(jagged);
        }

        static char[][] ReadJaggedArrayFromStdInput()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            char[][] tab = new char[numberOfLines][];
            for(int i=0; i< numberOfLines; i++)
            {
                char[] input = Array.ConvertAll<string, char>(Console.ReadLine().Trim().Split(), char.Parse);
                tab[i] = input;
            }

            return tab;
        }

        static char[][] TransposeJaggedArray(char[][] tab)
        {
            int newNumberOfLines = 0;
            int oldNumberOfLines = tab.Length;
            for(int i = 0; i < tab.Length; i++)
            {
                if (tab[i].Length > newNumberOfLines) newNumberOfLines = tab[i].Length;
            }
            char[][] transposed = new char[newNumberOfLines][];
            for(int i = 0; i < newNumberOfLines; i++)
            {
                char[] tempArray = new char[oldNumberOfLines];
                for(int j = 0; j < tab.Length; j++)
                {
                    if (i < tab[j].Length)
                        tempArray[j] = tab[j][i];
                    else
                        tempArray[j] = '*';
                }
                transposed[i] = tempArray;
            }
            return transposed;
        }

        static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
            for(int i = 0; i < tab.Length; i++)
            {
                for(int j = 0; j < tab[i].Length; j++)
                {
                    if(tab[i][j] == '*')
                        Console.Write("  ");
                    else
                        Console.Write($"{tab[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}