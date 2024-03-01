namespace LogicalSide
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameManager GM;
            GM= new GameManager();
            GM.AllCards[0].Eff.Act();
            Player player1 = new Player("Sweet Kids");
            GM.Generate(player1);
            for (int i = 0; i < player1.Deck.Count; i++)
            {
                Console.WriteLine(player1.Deck[i].CardName);
            }
            GM.Board
        }
    }
}
