using Projekt2_BlackJack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Projekt2_BlackJack
{
    internal class Spiel(Kasse kasse)
    {
        Kasse kasse = kasse;
        decimal einsatz;
        bool ersterZug = true;
        //bool ersteAbfrage = true;

        Hand spielerHand = new();
        Hand dealerHand = new();
        Deck deck = new();
        //Spieler spieler = new();
        Startmenu menu = new(kasse);

        public decimal Auswahl()
        {
            //if (ersteAbfrage)
            //{
            //    Console.Clear();
            //    Startmenu.Logo();
            //    spieler.NamenEingeben();
            //    ersteAbfrage = false;
            //}

            Console.Clear();
            Startmenu.Logo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\t\t\tVerfügbares Guthaben: {kasse.Balance} Euro\n\n");
            Console.ResetColor();
            Console.WriteLine("Welchen Betrag möchtest du setzen? (0) Hauptmenu\n");
            decimal einsatz = Startmenu.Eingabe();
            kasse.Einsatz(einsatz);

            if (einsatz == 0)
                menu.DisplayMenu();
            return einsatz;
        }
        public void Spielstart()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                einsatz = Auswahl();

                if (einsatz > 0 && kasse.Balance >= 0 || einsatz <= kasse.Balance && kasse.Balance >= 0)
                {
                    ersterZug = true;
                    deck.KartenMischen();
                    KarteSpieler();
                    KarteSpieler();
                    KarteDealer();
                    SpielerhandAnzeigen();
                    DealerhandAnzeigen();
                    SpielerAuswahl();
                }
                else
                {
                    kasse.Unentschieden(einsatz);
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nDer Einsatz muss positiv sein und darf dein Guthaben nicht überschreiten.\n");
                    Console.ResetColor();
                    Console.WriteLine("Gebe 0 ein um ins Hauptmenu zu gelagen und lade dein Konto auf!");
                    Console.Write("Weiter mit beliebiger Taste...");
                    Console.ReadKey();

                }
            }
        }
        void SpielerAuswahl()
        {
            while (true)
            {
                Console.Write("[1] Karte\t");
                Console.Write("[2] Halten\t");
                Console.Write("[3] Aufgeben\t");
                Console.WriteLine("[4] Hauptmenu\n");

                if (spielerHand.Gesamtpunkte() == 21)
                {
                    Spielentscheidung();
                    NeuesSpiel();
                }

                decimal eingabe = Startmenu.Eingabe();

                if (eingabe == 1)
                {
                    ersterZug = false;
                    Console.Clear();
                    Startmenu.Logo();
                    KarteSpieler();
                    SpielerhandAnzeigen();
                    DealerhandAnzeigen();

                    if (spielerHand.Gesamtpunkte() > 21)
                    {
                        Spielentscheidung();
                        NeuesSpiel();
                    }
                }
                else if (eingabe == 2)
                {
                    while (dealerHand.Gesamtpunkte() < 17)
                    {
                        Console.Clear();
                        Startmenu.Logo();
                        KarteDealer();
                        SpielerhandAnzeigen();
                        DealerhandAnzeigen();
                    }
                    Spielentscheidung();
                    NeuesSpiel();
                    break;
                }
                else if (eingabe == 3)
                {
                    if (ersterZug)
                    {
                        kasse.Aufgeben(einsatz);
                        NeuesSpiel();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAufgeben ist nur im ersten Zug möglich\n");
                        Console.ResetColor();
                    }
                }
                else if (eingabe == 4)
                {
                    menu.DisplayMenu();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFehlerhafte Eingabe, versuche es erneut\n");
                    Console.ResetColor();
                }
            }
        }
        void NeuesSpiel()
        {
            ersterZug = true;
            deck = new Deck();

            while (true)
            {
                Console.Write("\nNeue Runde? (y/n): ");
                string eingabe = Console.ReadLine().ToLower();

                if (eingabe == "y")
                {
                    deck.KartenMischen();
                    spielerHand.Karten.Clear();
                    dealerHand.Karten.Clear();
                    Spielstart();
                    break;
                }
                else if (eingabe == "n")
                {
                    Console.WriteLine("\nDanke fürs Spielen");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nFalsche Eingabe, bitte erneut versuchen\n");
                    Console.ResetColor();
                }
            }

        }
        void KarteSpieler()
        {
            spielerHand.KarteHinzufuegen(deck.KarteZiehen());
        }
        void KarteDealer()
        {
            dealerHand.KarteHinzufuegen(deck.KarteZiehen());
        }
        void SpielerhandAnzeigen()
        {
            Console.Clear();
            Startmenu.Logo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Einsatz: {einsatz} Euro \t\t\t\t");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Guthaben: {kasse.Balance} Euro\n\n\n");
            Console.ResetColor();
            Console.WriteLine($"Deine Hand: {string.Join(", ", spielerHand.Karten.Select(k => k.ToString()))}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Gesamtpunkte: {spielerHand.Gesamtpunkte()}\n");
            Console.ResetColor();
        }
        void DealerhandAnzeigen()
        {
            Console.WriteLine($"Dealer Hand: {string.Join(", ", dealerHand.Karten.Select(k => k.ToString()))}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Gesamtpunkte: {dealerHand.Gesamtpunkte()}\n");
            Console.ResetColor();
        }
        void Spielentscheidung()
        {
            if (spielerHand.Gesamtpunkte() > 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Du hast dich überkauft, du verlierst!\n");
                Console.ResetColor();
            }
            else if (dealerHand.Gesamtpunkte() > 21)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Dealer hat sich überkauft, du gewinnst!\n");
                Console.ResetColor();
                kasse.Gewonnen(einsatz);
            }
            else if (spielerHand.Gesamtpunkte() == 21)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("BlackJack, du hast Gewonnen!\n");
                Console.ResetColor();
                kasse.Gewonnen(einsatz);
            }
            else if (dealerHand.Gesamtpunkte() == 21 && spielerHand.Gesamtpunkte() != 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Dealer hat einen BlackJack, du verlierst!\n");
                Console.ResetColor();
            }
            else if (spielerHand.Gesamtpunkte() < dealerHand.Gesamtpunkte() && dealerHand.Gesamtpunkte() < 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Du hast verloren!\n");
                Console.ResetColor();
            }
            else if (spielerHand.Gesamtpunkte() > dealerHand.Gesamtpunkte() && spielerHand.Gesamtpunkte() < 21)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Du gewinnst!\n");
                Console.ResetColor();
                kasse.Gewonnen(einsatz);
            }
            else if (spielerHand.Gesamtpunkte() == dealerHand.Gesamtpunkte())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Unentschieden!\n");
                Console.ResetColor();
                kasse.Unentschieden(einsatz);
            }

        }
    }

}

