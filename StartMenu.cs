using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2_BlackJack
{
    internal class Startmenu
    {
        Kasse kasse;

        public Startmenu(Kasse kasse)
        {
            this.kasse = kasse;
        }

        public static void Logo()
        {
            Console.WriteLine("\r\n /$$$$$$$  /$$                     /$$                               /$$      \r\n| $$__  $$| $$                    | $$                              | $$      \r\n| $$  \\ $$| $$  /$$$$$$   /$$$$$$$| $$   /$$ /$$  /$$$$$$   /$$$$$$$| $$   /$$\r\n| $$$$$$$ | $$ |____  $$ /$$_____/| $$  /$$/|__/ |____  $$ /$$_____/| $$  /$$/\r\n| $$__  $$| $$  /$$$$$$$| $$      | $$$$$$/  /$$  /$$$$$$$| $$      | $$$$$$/ \r\n| $$  \\ $$| $$ /$$__  $$| $$      | $$_  $$ | $$ /$$__  $$| $$      | $$_  $$ \r\n| $$$$$$$/| $$|  $$$$$$$|  $$$$$$$| $$ \\  $$| $$|  $$$$$$$|  $$$$$$$| $$ \\  $$\r\n|_______/ |__/ \\_______/ \\_______/|__/  \\__/| $$ \\_______/ \\_______/|__/  \\__/\r\n                                       /$$  | $$                              \r\n                                      |  $$$$$$/                              \r\n                                       \\______/                               \r\n");
        }
        public void DisplayMenu()
        {
            Console.Clear();
            Logo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1] Spiel starten");
            Console.WriteLine("[2] Geld einzahlen");
            Console.WriteLine("[3] Spiel beenden\n");
            Console.ResetColor();
            MenuOption();
        }
        void MenuOption()
        {
            bool check = false;

            while (!check)
            {
                decimal eingabe = Eingabe();

                if (eingabe == 1 && kasse.Balance == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nBitte zuerst Guthaben aufladen!\n");
                    Console.ResetColor();
                }
                else
                {
                    switch (eingabe)
                    {
                        case 1:
                            Spiel spiel = new Spiel(kasse);
                            spiel.Spielstart();
                            check = true;
                            break;
                        case 2:
                            kasse.ChipsAufladen();
                            DisplayMenu();
                            check = true;
                            break;
                        case 3:
                            Console.WriteLine("\nDanke fürs Spielen. Programm wird beendet...");
                            Thread.Sleep(1500);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Fehlerhafte Eingabe. Versuche es bitte erneut!");
                            break;
                    }
                }
            }
        }
        public static decimal Eingabe()
        {
            decimal eingabe = 0;
            bool checkEingabe = false;

            while (!checkEingabe)
            {
                Console.Write("Eingabe: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal input))
                {
                    eingabe = input;
                    checkEingabe = true;
                    return input;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nBitte gebe eine gültige Zahl ein!\n");
                    Console.ResetColor();
                    checkEingabe = false;
                }
            }
            return eingabe;
        }

    }
}
