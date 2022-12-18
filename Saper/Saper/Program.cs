namespace Saper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
            char[][] matrix = new char[ nums[0] ][];
            for(int i = 0; i < nums[0]; i++)
            {
                char[] inputLines = Console.ReadLine().Trim().ToCharArray();
                matrix[i] = inputLines;
            }
            //cała logika, szukamy bomby i jak ją znajdziemy to na około niej dodajemy po 1 (w taki sposób żeby nie wyjść poza indeksowanie tablic), jak trafimy na bombe to pomijamy)

            for(int i = 0; i < nums[0]; i++)
            {
                for(int j = 0; j < nums[1]; j++)
                {
                    if(matrix[i][j] == '*')
                    {
                        int startX = i - 1;
                        int startY = j - 1;
                        int endX = i + 1;
                        int endY = j + 1;
                        
                        for(int k = 0; k < 3; k++)
                        {

                            if (k == 0 && startX < 0)
                                continue;
                            else if (k == 2 && endX > (nums[0] - 1))
                                continue;
                            else
                            {
                                for (int l = 0; l < 3; l++)
                                {
                                    if (l == 0 && startY < 0)
                                        continue;
                                    else if (l == 2 && endY > (nums[1] - 1))
                                        continue;
                                    else
                                    {
                                        if (matrix[startX + k][startY + l] == '*') continue;
                                        else if (matrix[startX + k][startY + l] == '.') matrix[startX + k][startY + l] = '1';
                                        else
                                        {
                                            int temp = matrix[startX + k][startY + l];
                                            temp += 1;
                                            matrix[startX + k][startY + l] = (char)temp;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }

            //wyprintowanie
            for (int i = 0; i < nums[0]; i++)
            {
                Console.WriteLine(matrix[i]);
            }


        }
    }
}