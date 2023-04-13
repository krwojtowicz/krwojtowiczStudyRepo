namespace StrukturaStos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Stos<string>();
            s.Push("aaa");
            s.Push("bbb");
            s.Push("ccc");
            foreach (var x in s.ToArray())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"na szczycie jest: {s.Peek}");
            Console.WriteLine($"liczba elementów na stosie: {s.Count}");
            while (!s.IsEmpty)
            {
                Console.WriteLine($"zdejmuje: {s.Pop()}");
            }
            if (s.IsEmpty)
                Console.WriteLine("stos jest pusty");
        }
    }
}