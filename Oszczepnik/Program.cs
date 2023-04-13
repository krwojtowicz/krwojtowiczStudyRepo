using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test: poprawne tworzenie obiektu Oszczepnik, dane poprawne
            //       typowe czynności poprawne
            Oszczepnik p = new Oszczepnik(imie: "krzysztof", nazwisko: "molenda", kraj: "pol");
            Console.WriteLine(p);
            p.ZarejestrujWynik("67");
            p.ZarejestrujWynik("71,12");
            Console.WriteLine(p);
            Console.WriteLine(p.ProbujZarejestrowacWynik("x"));
            p.ZarejestrujWynik("70,5");
            Console.WriteLine(p);
        }

        public class Oszczepnik
        {
            private List<string> listaProb = new List<string>();

            private string _imie;

            private string _nazwisko;

            private string _kraj;

            private int _liczbaProb;

            private decimal _wynikNajlepszy;

            private string _wynikOstatni;

            private decimal _sredniWynik;
            public string Imie
            {
                get
                {
                    return _imie;
                }
                set
                {
                    Regex rx = new Regex("^[a - zA - Z]+$");
                    string temp = Regex.Replace(value, @"\s+", "");
                    if (temp == null) throw new ArgumentException("Nazwa nie moze byc null!");
                    if (rx.IsMatch(temp) || temp.Length < 3) throw new ArgumentException("Niepoprawna nazwa!");
                    _imie = char.ToUpper(temp[0]) + temp.Substring(1);
                }
            }

            public string Nazwisko
            {
                get
                {
                    return _nazwisko;
                }
                set
                {
                    Regex rx = new Regex("^[a - zA - Z]+$");
                    string temp = Regex.Replace(value, @"\s+", "");
                    if (temp == null) throw new ArgumentException("Nazwa nie moze byc null!");
                    if (rx.IsMatch(temp) || temp.Length < 3) throw new ArgumentException("Niepoprawna nazwa!");
                    _nazwisko = char.ToUpper(temp[0]) + temp.Substring(1);
                }
            }

            public string Kraj
            {
                get
                {
                    return _kraj;
                }
                set
                {
                    string temp = value;
                    temp = temp.Trim();
                    if (temp.Length != 3) throw new ArgumentException("niepoprawny kod kraju!");
                    temp = temp.ToUpper();
                    _kraj = temp;
                }
            }

            public int LiczbaProb
            {
                get
                {
                    return _liczbaProb;
                }
                set
                {
                    _liczbaProb = value;
                }
            }

            public decimal WynikNajlepszy
            {
                get
                {
                    int count = 0;
                    foreach(var elem in listaProb)
                    {
                        if (elem != "X") count++;
                    }
                    if (LiczbaProb == 0 || count == 0 ) return 0;
                    return _wynikNajlepszy;
                }
                private set
                {
                    decimal best = 0;
                    foreach (var elem in listaProb)
                    {
                        if (elem != "X")
                        {
                            if(best < Decimal.Parse(elem))
                            {
                                best = Decimal.Parse(elem);
                            }
                        }
                    }
                    _wynikNajlepszy = best;
                }
            }

            public string WynikOstatni
            {
                get
                {
                    return _wynikOstatni;
                }
                private set
                {
                    _wynikOstatni = value;
                }

            }

            public decimal WynikSredni
            {
                get
                {
                    return _sredniWynik;
                }
                private set
                {
                    decimal suma = 0;
                    foreach (var elem in listaProb)
                    {
                        bool parsed = Decimal.TryParse(elem, out decimal result);
                        if (parsed) suma += result;
                        else continue;
                    }
                    if (LiczbaProb == 0) _sredniWynik = 0;
                    else
                    {
                        decimal srednia = suma / (decimal)LiczbaProb;
                        _sredniWynik = Math.Round(srednia, 2);
                    }
                    
                }
            }

            public Oszczepnik(string imie, string nazwisko, string kraj)
            {
                Imie = imie;
                Nazwisko = nazwisko;
                Kraj = kraj;
                LiczbaProb = 0;
                WynikNajlepszy = 0;
                WynikOstatni = "0";
                WynikSredni = 0;
            }

            public void ZarejestrujWynik(string wynik)
            {
                string temp = wynik.Trim();
                if (LiczbaProb == 6) throw new ArgumentException("limit wykorzystany");
                if (temp == "x" || temp == "X") listaProb.Add("X");
                bool parsed = Decimal.TryParse(temp, out decimal result);
                if (parsed && result >= 0)
                {
                    listaProb.Add(temp);
                }
                else
                {
                    throw new ArgumentException("niepoprawny format");
                }
                WynikOstatni = temp;
                LiczbaProb += 1;
                WynikSredni = WynikSredni;
                WynikNajlepszy = WynikNajlepszy;

            }

            public bool ProbujZarejestrowacWynik(string wynik)
            {
                string temp = wynik.Trim();
                if (LiczbaProb == 6) return false;
                if (temp == "x" || temp == "X")
                {
                    listaProb.Add("X");
                    WynikOstatni = temp;
                    LiczbaProb += 1;
                    WynikSredni = WynikSredni;
                    WynikNajlepszy = WynikNajlepszy;
                    return true;
                }
                else
                {
                    bool parsed = Decimal.TryParse(temp, out decimal result);
                    if (parsed && result >= 0)
                    {
                        listaProb.Add(temp);
                    }
                    else
                    {
                        return false;
                    }
                    WynikOstatni = temp;
                    LiczbaProb += 1;
                    WynikSredni = WynikSredni;
                    WynikNajlepszy = WynikNajlepszy;
                }
                

                return true;
            }

            public override string ToString()
            {
                string output = "";
                output += $"{Imie} {Nazwisko} ({Kraj})\n";
                output += "wyniki: ";
                if (LiczbaProb == 0) output += "-\n";
                else
                {
                    foreach(var elem in listaProb)
                    {
                        output += $"{elem}, ";
                    }
                    output = output.Substring(0, output.Length - 2);
                    output += '\n';
                }

                output += $"liczba prob: { LiczbaProb}, wynik najlepszy: { WynikNajlepszy:F2}, wynik sredni: { WynikSredni:F2}";

                return output;
            }


        }
    }
}