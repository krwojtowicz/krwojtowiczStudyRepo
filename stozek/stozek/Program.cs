namespace stozek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), int.Parse);
            long R = input[0];
            long L = input[1];
            if (R < 0 || L < 0)
            {
                Console.WriteLine("ujemny argument");
                return;
            }
            if (R > L)
            {
                Console.WriteLine("obiekt nie istnieje");
                return;
            }
            decimal H = (decimal)Math.Sqrt((L * L) - (R * R));
            decimal pP = (decimal)Math.PI * (decimal)R * R;
            decimal V = (pP * H) / 3;

            decimal a = Math.Floor(V);
            decimal b = Math.Ceiling(V);

            Console.WriteLine($"{a} {b}");
        }
    }
}
