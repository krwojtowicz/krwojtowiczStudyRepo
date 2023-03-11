using System;
using System.Globalization;

class Program
{
    public static void Main()
    {
        int[] a = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), int.Parse);

        int i = 0;
        label1:
        int j = 1;
        label2:
        if(a.Length == 1)
        {
            Console.WriteLine(a[0]);
            return;

        }
        if (a[j] < a[j - 1])
        {
            int temp = a[j];

            a[j] = a[j - 1];
            a[j - 1] = temp;
        }
        j++;
        if(j< a.Length - i)
        {
            goto label2;
        }
        i++;

        if(i < a.Length)
        {
            goto label1;
        }

        string output = "";
        foreach(int x in a)
        {
            output += $"{x}, ";
        }
        output = output.Substring(0, output.Length - 2);
        Console.WriteLine(output);

    }
}