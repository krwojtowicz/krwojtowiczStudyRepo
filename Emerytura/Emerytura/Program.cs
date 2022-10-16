namespace Emerytura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitedInput = input.Split(' ');
            string nazwisko = splitedInput[0];
            int wiekOsoby = Convert.ToInt32(splitedInput[1]);
            int wiekEmerytalny = Convert.ToInt32(splitedInput[2]);

            if(wiekOsoby < 0 || wiekEmerytalny < 0)
            {
                Console.WriteLine("Wiek nie może być ujemny!");
            }
            else if(wiekOsoby < wiekEmerytalny)
            {
                Console.Write($"Witaj {nazwisko}! ");
                int lataDoEmerytury = wiekEmerytalny - wiekOsoby;
                char[] liczbaJednosci = lataDoEmerytury.ToString().ToCharArray();
       
                    if(lataDoEmerytury == 1)
                        Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} rok!");
                    else if(lataDoEmerytury < 5)
                        Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lata!");
                    else if (lataDoEmerytury < 22)
                        Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lat!");
                    else if (liczbaJednosci[1]=='2' || liczbaJednosci[1] == '3' || liczbaJednosci[1] == '4')
                        Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lata!");
                    else
                        Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lat!");
            }
            else
            {
                Console.WriteLine($"Witaj emerycie {nazwisko}!");
            }
        }
        static void Emerytura2()
        {
            string nazwisko = Console.ReadLine();
            int wiekOsoby = Convert.ToInt32(Console.ReadLine());
            int wiekEmerytalny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Witaj, {nazwisko}!");
            if (wiekOsoby < 0 || wiekEmerytalny < 0)
            {
                Console.WriteLine("Wiek nie może być ujemny!");
            }
            else if (wiekOsoby < wiekEmerytalny)
            {
                int lataDoEmerytury = wiekEmerytalny - wiekOsoby;
                char[] liczbaJednosci = lataDoEmerytury.ToString().ToCharArray();

                if (lataDoEmerytury == 1)
                    Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} rok!");
                else if (lataDoEmerytury < 5)
                    Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lata!");
                else if (lataDoEmerytury < 22)
                    Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lat!");
                else if (liczbaJednosci[1] == '2' || liczbaJednosci[1] == '3' || liczbaJednosci[1] == '4')
                    Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lata!");
                else
                    Console.WriteLine($"Do emerytury brakuje Ci {lataDoEmerytury} lat!");
            }
            else
            {
                Console.WriteLine("Jesteś emerytem!");
            }
        }
    }
}
