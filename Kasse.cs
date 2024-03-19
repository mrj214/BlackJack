using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2_BlackJack
{
    internal class Kasse
    {
        public decimal Balance { get; private set; }

        public void Gewonnen(decimal einsatz)
        {
            Balance += einsatz + einsatz * 1.5M;
        }
        public void Aufgeben(decimal einsatz)
        {
            Balance = Balance + einsatz * 0.5M;
        }
        public void ChipsAufladen()
        {
            Console.Clear();
            Startmenu.Logo();
            while (true)
            {
                Console.Write("Welchen Betrag möchtest du einzahlen: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal input))
                {
                    Balance += input;
                    break;
                }
                else
                    Console.WriteLine("Bitte einen gültigen Wert eingeben!");
            }
        }     
        public void Einsatz(decimal einsatz)
        {
            Balance = Balance - einsatz;
        }
        public void Unentschieden(decimal einsatz)
        {
            Balance = Balance + einsatz;
        }
    }
}
