using System;
using System.Security.Cryptography.X509Certificates;

namespace PudelkoLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko pudelko = new Pudelko(1, 2, 3, UnitOfMeasure.meter);

            //metoda rozszerzająca Kompresuj
            Console.WriteLine("Kompresuj");
            Pudelko Kompresuj(Pudelko p)
            {
                double V = p.Obj;
                double pow = (double)1 / 3;
                return new Pudelko(Math.Pow(V, pow), Math.Pow(V, pow), Math.Pow(V, pow));
            }
            

            Console.WriteLine(pudelko.ToString());
            Console.WriteLine(Kompresuj(pudelko).ToString());
            Console.WriteLine();


            Console.WriteLine("Sortowanie pudełek");
            Pudelko p1 = new Pudelko();
            Pudelko p2 = new Pudelko(2, 3,null, UnitOfMeasure.meter);
            Pudelko p3 = new Pudelko(100,300,500,UnitOfMeasure.milimeter);

            List<Pudelko> lista = new List<Pudelko>();
            lista.Add(p1);
            lista.Add(p2);
            lista.Add(p3);

            foreach(var elem in lista)
            {
                Console.WriteLine(elem.ToString());
            }


        }
    }
}