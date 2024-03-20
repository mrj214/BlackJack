namespace Projekt2_BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spieler spieler = new Spieler();
            Kasse kasse = new();
            Startmenu menu = new(kasse, spieler);
            menu.DisplayMenu();
        }
    }
}
