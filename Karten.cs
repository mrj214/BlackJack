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
    internal class Karten
    {
        public static readonly string[] Werte = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public string Wert { get; set; }
        public Farbe Farbe { get; set; }
        public int Punkte { get; set; }

        public Karten(Farbe farbe, string wert)
        {
            Farbe = farbe;
            Wert = wert;
            Punkte = BerechnePunkte(wert);
        }
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
        private int BerechnePunkte(string wert)
        {
            switch (wert)
            {
                case "A":
                    return 11; // Ass kann später angepasst werden
                case "J":
                case "Q":
                case "K":
                    return 10; // Bildkarten sind 10 Punkte wert
                default:
                    return int.Parse(wert); // Numerische Karten entsprechen ihrem Wert
            }
        }

    }
}
