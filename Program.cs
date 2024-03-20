namespace Projekt2_BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kasse kasse = new();
            Startmenu menu = new(kasse);
            menu.DisplayMenu();
        }
    }
}
