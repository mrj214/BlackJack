using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2_BlackJack
{
    internal class Deck
    {
        List<Karten> karten;
        public Deck()
        {
            karten = [];
            foreach (Farbe farbe in Enum.GetValues(typeof(Farbe)))
            {
                foreach (string wert in Karten.Werte)
                {
                    karten.Add(new Karten(farbe, wert));
                }
            }
        }
        public void KartenMischen()
        {
            Random rnd = new();
            int n = karten.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                (karten[n], karten[k]) = (karten[k], karten[n]);
            }
        }
        public Karten KarteZiehen()
        {
            if (karten.Count > 0)
            {
                Karten gezogeneKarte = karten[0];
                karten.RemoveAt(0);
                return gezogeneKarte;
            }
            throw new Exception("Keine Karten mehr im Deck");
        }
    }
}
