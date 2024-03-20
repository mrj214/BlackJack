using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2_BlackJack
{
    internal class Hand
    {
        public List<Karten> Karten {  get; set; } = [];
        public void KarteHinzufuegen(Karten karte)
        {
            Karten.Add(karte);
        }
        public int Gesamtpunkte()
        {
            int gesamtpunkte = Karten.Sum(karte => karte.Punkte);
            int anzahlAsse = Karten.Count(karte => karte.Wert == "A");

            while (gesamtpunkte > 21 && anzahlAsse > 0)
            {
                gesamtpunkte -= 10; 
                anzahlAsse--;
            }
            return gesamtpunkte;
        }
    }
}
