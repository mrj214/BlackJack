namespace Projekt2_BlackJack
{
    internal class Spieler
    {
        public string Name { get; set; }

        public void NamenEingeben()
        {
            Console.Write("Gebe deinen Namen ein: ");
            Name = Console.ReadLine().Trim();
        }
    }
}
