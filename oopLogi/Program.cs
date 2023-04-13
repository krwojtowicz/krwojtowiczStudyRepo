using System.Collections.Generic;
namespace oopLogi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Analyze("021-06-10 5:20 mirek 180.40.41.120\r\n2021-06-10 5:21 mirek 180.40.41.121");
        }

        public static void Analyze(string logs)
        {
            string[] rows = logs.Split('\n');

            SortedDictionary<string, HashSet<string>> dict = new SortedDictionary<string, HashSet<string>>();
            foreach(string row in rows)
            {
                string[] splitted = row.Split(' ');
                string imie = splitted[2];
                string ip = splitted[3];
                
                bool isAdded = dict.TryAdd(imie, new HashSet<string>());
                if (isAdded)
                {
                    dict[imie].Add(ip);
                }
                else
                {
                    dict[imie].Add(ip);
                }
                

            }
            List<string> list = new List<string>();
            foreach(var elem in dict)
            {
                int counter = 0;
                foreach(var row in elem.Value)
                {
                    counter += 1;
                }
                if(counter == 1)
                {
                    list.Add(elem.Key);
                }
            }
            if (list.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                list.Sort();
                list.Reverse();
                string toString = "";
                foreach (var elem in list)
                {
                    toString += $"{elem}, ";
                }
                string output = toString.Substring(0, toString.Length - 2);
                Console.WriteLine(output);
            }
            
        }
    }
}