using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Logi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> dicNameIP = new SortedDictionary<string, SortedSet<string>>();
            SortedDictionary<string, int> dicNameTime = new SortedDictionary<string, int>();
            int numberOfLogs = Int32.Parse(Console.ReadLine());
            for(int i = 0; i < numberOfLogs; i++)
            {
                string[] line = Console.ReadLine().Split();
                string imie = line[1];
                string ip = line[0];
                int time = Int32.Parse(line[2]);
                if (!dicNameIP.ContainsKey(imie))
                {
                    dicNameIP.Add(imie, new SortedSet<string>());
                    dicNameIP[imie].Add(ip);
                    dicNameTime.Add(imie, time);
                }
                else
                {
                    dicNameIP[imie].Add(ip);
                    dicNameTime[imie] += time;
                }
            }
            foreach(var elem in dicNameTime)
            {
                string imie = elem.Key;
                SortedSet<string> listaIp = dicNameIP[imie];
                string outputIP = "[";
                foreach(var ip in listaIp)
                {
                    outputIP += $"{ip}, ";
                }
                outputIP = outputIP.Trim().Remove(outputIP.Length-2) + "]";
                Console.WriteLine($"{imie}: {elem.Value} {outputIP}");
            }
        }
    }
}