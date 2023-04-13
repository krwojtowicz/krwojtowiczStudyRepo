using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Collections;

namespace ASK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AX AABB -> AH[0]{AA} AL[1]{BB} BX -> 
            string[] reg = new string[] {"0000", "1111", "0000", "0000", "0000", "0000", "0000", "0000" };
            string[] memory = Enumerable.Repeat("0000", 65536).ToArray();
            Stack<string> stos = new Stack<string>();
            int offset = 0;
            while (true)
            {
                printReg(reg);
                Console.WriteLine();
                printMEM(memory);
                Console.WriteLine("\nStos:");
                foreach(var elem in stos)
                {
                    Console.WriteLine(elem);
                }
                
                Console.WriteLine("\nZdefiniuj działanie.");
                Console.WriteLine("Lista dostepnych działań wraz ze składnią:");
                Console.WriteLine("MOV AX,[BP] - przypisz podaną wartość lub wartość innego rejestru/miejsca pamieci");
                Console.WriteLine("XCHG AX,BX - zamień ze sobą wartości wskazanych rejestrów/miejsc w pamieci");
                Console.WriteLine("PUSH AX - dodaj na górę stosu wartość z podanego rejestru");
                Console.WriteLine("POP DX - przypisz wartość z góry stosu do podanego rejesru\n");
                string[] input =  Console.ReadLine().Trim().Split();
                if(input.Length == 3)
                {
                    Console.WriteLine("Niepoprawne formatowanie polecenia!");
                    continue;
                }
                string task = input[0];
                if (task != "MOV" && task != "XCHG" && task != "PUSH" && task != "POP")
                {
                    Console.WriteLine("Zły rozkaz działania");
                    continue;
                }

                if(task == "PUSH")
                {
                    if (getNumber(input[1]) == -1)
                    {
                        Console.WriteLine("W przypadku tej operacji powinieneś podać rejestr");
                        continue;
                    }
                    else
                    {
                        int rejestr = getNumber(input[1]);
                        stos.Push(reg[rejestr]);
                        continue;
                    }
                }

                if (task == "POP")
                {
                    if (getNumber(input[1]) == -1)
                    {
                        Console.WriteLine("W przypadku tej operacji powinieneś podać rejestr do którego chcesz zapisać wartość ze stosu");
                        continue;
                    }
                    else
                    {
                        int rejestr = getNumber(input[1]);
                        if(stos.Count == 0)
                        {
                            Console.WriteLine("Nie ma nic na stosie!");
                            continue;
                        }
                        reg[rejestr] = stos.Pop();
                        continue;
                    }
                }
                string[] fields = input[1].Split(',');
                string f1 = fields[0];
                string f1typ = type(f1);
                if (f1typ == "wartosc")
                {
                    Console.WriteLine("W polu nr.1 nie może być wartości, spróbuj ponownie wpisując rejestr lub offset");
                    continue;
                }
                string f2 = fields[1];
                string f2typ = type(f2);
                if (f2typ == "wartosc")
                    if (validateInput(f2)) continue; //true oznacza złe dane,
                Console.WriteLine();

                if((f1typ == "rejestr" && f2typ == "rejestr") || (f1typ == "rejestr" && f2typ == "wartosc"))
                {
                    switch (task)
                    {
                        case "MOV":
                            move(f1, f2, reg);
                            break;
                        case "XCHG":
                            xchange(f1, f2, reg);
                            break;
                    }
                }
                else if(f1typ == "rejestr" && f2typ == "pamiec")
                {
                    string[] f2skladniki = f2.TrimStart('[').TrimEnd(']').Split('+');
                    string reg1value = reg[getNumber(f2skladniki[0])];
                    if (f2skladniki.Length == 1) offset = hexToDecimal(reg1value);
                    else if (f2skladniki.Length == 2)
                    {
                        offset = hexToDecimal(reg1value) + hexToDecimal(f2skladniki[1]);
                    }
                    else if(f2skladniki.Length == 3)
                    {
                        string reg2value = reg[getNumber(f2skladniki[1])];
                        offset = hexToDecimal(reg1value) + hexToDecimal(reg2value) + hexToDecimal(f2skladniki[2]);
                    }

                    switch (task)
                    {
                        case "MOV":
                            reg[getNumber(f1)] = memory[offset];
                            break;
                        case "XCHG":
                            string temp = reg[getNumber(f1)];
                            reg[getNumber(f1)] = memory[offset];
                            memory[offset] = temp;
                            break;
                    }

                }
                else if (f1typ == "pamiec" && f2typ == "rejestr")
                {
                    string[] f1skladniki = f1.TrimStart('[').TrimEnd(']').Split('+');
                    string reg1value = reg[getNumber(f1skladniki[0])];
                    if (f1skladniki.Length == 1) offset = hexToDecimal(reg1value);
                    else if (f1skladniki.Length == 2)
                    {
                        offset = hexToDecimal(reg1value) + hexToDecimal(f1skladniki[1]);
                    }
                    else if (f1skladniki.Length == 3)
                    {
                        string reg2value = reg[getNumber(f1skladniki[1])];
                        offset = hexToDecimal(reg1value) + hexToDecimal(reg2value) + hexToDecimal(f1skladniki[2]);
                    }

                    switch (task)
                    {
                        case "MOV":
                            memory[offset] = reg[getNumber(f2)];
                            break;
                        case "XCHG":
                            string temp = reg[getNumber(f2)];
                            reg[getNumber(f2)] = memory[offset];
                            memory[offset] = temp;
                            break;
                    }
                }
            }

        }
        static string type(string field)
        {
            if (getNumber(field) != -1) return "rejestr";
            if (field[0] == '[' && field[field.Length - 1] == ']') return "pamiec";
            return "wartosc";
        }
        static int hexToDecimal(string number)
        {
            int val = Convert.ToInt32(number, 16);
            return val;
        }
        static void printReg(string[] reg)
        {
            Console.WriteLine($"\nWartości rejestrów:");
            Console.WriteLine($"AX {reg[0]} BX {reg[1]}");
            Console.WriteLine($"CX {reg[2]} DX {reg[3]}");
            //Console.WriteLine($"SP {reg[4]}");
            Console.WriteLine($"BP {reg[5]} DI {reg[6]}"); 
            Console.WriteLine($"SI {reg[7]}");
        }

        static bool validateInput(string input)
        {
            var regexItem = new Regex("^[A-F0-9]{0,4}$");

            if (input.Length > 4)
            {
                Console.WriteLine("Za długa wartość w polu");
                return true;
            }
            else if (!regexItem.IsMatch(input))
            {
                    Console.WriteLine("Zła wartość w 2 polu");
                    return true;
            }
            return false;
        }
        static void move(string R1, string R2, string[] reg)
        {
            if(getNumber(R2) == -1)
            {
                int indexR1 = getNumber(R1);
                string value = R2;
                reg[indexR1] = value;
            }
            else
            {
                int indexR1 = getNumber(R1);
                int indexR2 = getNumber(R2);
                reg[indexR1] = reg[indexR2];
            }      
        }
        static void xchange(string R1, string R2, string[] reg)
        {
            if (getNumber(R2) == -1 || getNumber(R1) == -1)
                Console.WriteLine("Błąd, podano nieprawidłową wartość. (Obie wartości powinny być rejestrami)");
            else
            {
                int indexR1 = getNumber(R1);
                int indexR2 = getNumber(R2);
                string temp = reg[indexR1];
                reg[indexR1] = reg[indexR2];
                reg[indexR2] = temp;
            }

        }
        static void printMEM(string[] memory)
        {
            Console.WriteLine("Komórka w pamieci wraz z jej wartością (puste komórki '0000' nie są wyświetlane):");
            for (int i=0; i< memory.Length;i++)
            {
                if (memory[i] == "0000") continue;
                else
                {
                    Console.Write($"{i.ToString("X")}:x{memory[i].ToString()} ");
                }
                
            }
                
        }
        static int getNumber(string num)
        {
            switch (num)
            {
                case "AX":
                    return 0;
                case "BX":
                    return 1;
                case "CX":
                    return 2;
                case "DX":
                    return 3;
                case "SP":
                    return 4;
                case "BP":
                    return 5;
                case "DI":
                    return 6;
                case "SI":
                    return 7;
                default:
                    return -1;
            }
        }
    }
}