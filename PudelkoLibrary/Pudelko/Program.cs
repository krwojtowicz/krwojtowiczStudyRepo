namespace PudelkoLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko pudelko = new Pudelko(0);

            Console.WriteLine(pudelko.ToString());
            Console.WriteLine(pudelko.ToString("cm"));
            Console.WriteLine(pudelko.ToString("mm"));

        }
    }
}