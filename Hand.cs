using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2_BlackJack
{
    internal class Hand
    {
        public List<Karten> Karten {  get; set; } = new List<Karten>();
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
                gesamtpunkte -= 10; // Ein Ass von 11 auf 1 Punkte reduzieren
                anzahlAsse--;
            }
            return gesamtpunkte;
        }
    }
}
