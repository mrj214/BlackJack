using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projekt2_BlackJack
{
    public enum Farbe
    {
        Kreuz,
        Pik,
        Herz, 
        Karo   
    }
    internal class Karten(Farbe farbe, string wert)
    {
        public static readonly string[] Werte = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public string Wert { get; set; } = wert;
        public Farbe Farbe { get; set; } = farbe;
        public int Punkte { get; set; } = BerechnePunkte(wert);

        public override string ToString()
        {
            var symbol = Farbe switch
            {
                Farbe.Kreuz => "\u2663",  
                Farbe.Pik => "\u2660",    
                Farbe.Herz => "\u2665",   
                Farbe.Karo => "\u2666",   
                _ => " "
            };
            return $"[{Wert}{symbol}] ";       
        }
        private static int BerechnePunkte(string wert)
        {
            return wert switch
            {
                "A" => 11,
                "J" or "Q" or "K" => 10,
                _ => int.Parse(wert),
            };
        }

    }
}
