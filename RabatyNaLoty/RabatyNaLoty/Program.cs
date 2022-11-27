namespace RabatyNaLoty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Witaj użytkowniku! Obliczmy rabat na loty. W tym celu proszę wprowadź poniższe dane. \n");
            Console.Write("Podaj date urodzenia (przeszła w formacie dd.mm.yyyy): ");
            DateTime dataUrodzenia = DateTime.Parse(Console.ReadLine());
            int wiek = getWiek(dataUrodzenia);
            bool czyStaly = false;
            if (wiek >= 18)
            {
                Console.Write("Czy jesteś stałym klientem?(T/N)");
                string czyStalyString = Console.ReadLine().Trim();
                if (czyStalyString == "T")
                    czyStaly = true;
            }
            Console.Write("Podaj date lotu (przyszła w formacie dd.mm.yyyy): ");
            DateTime dataLotu = DateTime.Parse(Console.ReadLine());
            int miesiecyDoLotu = getMiesiecyDoLotu(dataLotu);
            bool czySezonowy = czyLotSezonowy(dataLotu);
            Console.Write("Czy lot jest krajowy (T/N): ");
            string czyKrajowyString = Console.ReadLine().Trim();
            bool czyKrajowy = false;
            if (czyKrajowyString == "T")
                czyKrajowy = true;



        }
        public static int getWiek(DateTime data)
        {
            DateTime pierwszyDzien = new DateTime(1, 1, 1);
            int wiek = (pierwszyDzien + DateTime.Now.Subtract(data)).Year - 1;
            return wiek;
        }
        public static int getMiesiecyDoLotu(DateTime data)
        {
            DateTime pierwszyDzien = new DateTime(1, 1, 1);
            var roznica = data.Subtract(DateTime.Now);
            int Lat = (pierwszyDzien + roznica).Year - 1;
            int miesiecyDoLotu = (Lat*12) + (pierwszyDzien + roznica).Month - 1;
            return miesiecyDoLotu;
        }
        public static bool czyLotSezonowy(DateTime data)
        {
            bool czySezonowy = false;
            int rok = data.Year;
            int miesiac = data.Month;
            if(miesiac == 12)
            {
                if (data >= new DateTime(rok, 12, 20))
                    czySezonowy = true;
            }    
            else if(miesiac == 1)
            {
                if (data <= new DateTime(rok, 1, 10))
                    czySezonowy = true;
            }
            else if (data >= new DateTime(rok, 3, 20) && data <= new DateTime(rok, 4, 10))
                czySezonowy = true;
            else if (data >= new DateTime(rok, 7, 1) && data <= new DateTime(rok, 8, 31))
                czySezonowy = true;

            return czySezonowy;
        }
        
    }
}