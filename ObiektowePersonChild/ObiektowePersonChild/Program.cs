using System;

namespace ObiektowePersonChild
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test2();
           
        }

        public static void Test1()
        {
            /* Test: poprawne tworzenie obiektu Person, dane poprawne */
            try
            {
                Person p = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 18);
                Console.WriteLine(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Test2()
        {
            /* Test: poprawne tworzenie obiektu Person, 
            błędne imię lub nazwisko, pierwsza duża pozostałe małe */
            try
            {
                Person p = new Person(familyName: "MOlenda", firstName: "krzysztof", age: 18);
                Console.WriteLine(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}