using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguryLib
{
    abstract public class Figura
    {
        public ConsoleColor DefaultColor { get; protected set; } = ConsoleColor.Black;
        // wypisuje na konsolę figurę
        public virtual void Rysuj()
        {
            Console.ResetColor();
            Console.ForegroundColor = this.DefaultColor;
            Console.WriteLine(this);
            Console.ResetColor();
        }
    }
}
