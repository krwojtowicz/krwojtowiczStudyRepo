namespace Czas24h
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine(t);

            //Console.WriteLine(t);
            var t = new Czas24h(2, 15, 37);
            Console.WriteLine(t);
            t.Minuta = 20;
            Console.WriteLine(t);
            t.Godzina = 23;
            Console.WriteLine(t);
            t.Godzina = 1;
            Console.WriteLine(t);
            t.Sekunda = 15;
            Console.WriteLine(t);
            t.Minuta = 10;
            Console.WriteLine(t);
            t.Sekunda = 23;
            Console.WriteLine(t);

            t.Sekunda = 1;
            Console.WriteLine(t);

            t.Minuta = 12;
            Console.WriteLine(t);

        }
    }
    public class Czas24h
    {
        private int liczbaSekund;
        
        public int Sekunda
        {
            get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
            // uzupełnij kod - zdefiniuj setters'a
            set
            {
                if (value < 0 || value > 59) throw new ArgumentException();
                else liczbaSekund = value  + 60 * Minuta + 3600 * Godzina;
            }
        }

        public int Minuta
        {
            get => (liczbaSekund / 60) % 60;
            // uzupełnij kod - zdefiniuj setters'a
            set
            {
                if (value < 0 || value > 59) throw new ArgumentException();
                liczbaSekund -= Minuta * 60;
                liczbaSekund = Sekunda  + 60 * value + 3600 * Godzina;
            }
        }

        public int Godzina
        {
            get => liczbaSekund / 3600;
            // uzupełnij kod - zdefiniuj setters'a
            set
            {
                if (value < 0 || value > 23) throw new ArgumentException();
                liczbaSekund -= Godzina * 3600;
                liczbaSekund = Sekunda  + 60 * Minuta + 3600 * value;
            }
        }

        public Czas24h(int godzina, int minuta, int sekunda)
        {
            // uzupełnij kod zgłaszając wyjątek ArgumentException
            // w sytuacji niepoprawnych danych
            int minValue = 0;
            int maxHourValue = 23;
            int maxOtherValue = 59;
            if (sekunda < minValue || minuta < minValue || godzina < minValue || sekunda > maxOtherValue || minuta > maxOtherValue || godzina > maxHourValue) throw new ArgumentException();

            liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
        }

        public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
    }
}