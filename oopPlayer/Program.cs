namespace oopPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player p = new Player(name: "mol123", password: "aB12.,aC");
            Console.WriteLine(p.VerifyPassword("aB12.,aC"));
            Console.WriteLine(p.VerifyPassword(null));
            Console.WriteLine(p.VerifyPassword("ab12-!aC"));
        }
    }
}
