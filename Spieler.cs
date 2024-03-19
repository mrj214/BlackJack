using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2_BlackJack
{
    internal class Spieler
    {
        public string Name { get; set; }

        public void NamenEingeben()
        {
            Console.Write("Gebe deinen Namen ein: ");
            Name = Console.ReadLine().Trim();
        }
    }
}
