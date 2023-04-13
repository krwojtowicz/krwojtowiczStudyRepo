namespace Logi2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Analyze("2021-06-10 5:20 mirek 180.40.41.120\r\n2021-06-10 10:20 adam 80.40.41.120\r\n2021-06-10 10:21 admin 192.168.4.10\r\n2021-06-11 8:09 maciek 149.40.53.12\r\n2021-06-11 8:10 adam 80.40.41.120\r\n2021-06-11 18:10 mirek 180.40.41.120");
        }

        public static void Analyze(string logs)
        {
            SortedDictionary<string, HashSet<string>> loggers = new SortedDictionary<string, HashSet<string>>();
            SortedSet<string> zakres = new SortedSet<string>();

            string[] input = logs.Split('\n');
            for(int i = 0; i < input.Length; i++)
            {
                string[] splited = input[i].Split(' ');
                string imie = splited[2];
                string data = splited[0];
                zakres.Add(data);
                bool added = loggers.TryAdd(imie, new HashSet<string>());
                if (!added)
                {
                    loggers[imie].Add(data);
                }
           
            }   
            foreach(var log in loggers)
            {
                Console.WriteLine(log.Key, log.Value);
            }

        }
    }
}