namespace Projekt2_BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kasse kasse = new Kasse();
            Startmenu menu = new Startmenu(kasse);
            menu.DisplayMenu();
        }
    }
}
