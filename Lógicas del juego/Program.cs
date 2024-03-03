using System.Numerics;

namespace LogicalSide
{
    public class Program
    {

        static void Main(string[] args)
        {
            GameManager GM;
            Player Player1 = new Player("Cartman Boys");
            Player1.DownBoard = true;
            Player Player2 = new Player("School Devils");
            Player2.DownBoard = false;
            GM = new GameManager(Player1, Player2);
            Player1.SetUpPlayer();
            Player1.Deck[1].PlayCard("M");
            Player1.Deck[1].PlayCard("M");
            Player1.Deck[1].PlayCard("M");
            Player1.Deck[1].PlayCard("M");
            Player1.Deck[1].PlayCard("M");
            for (int i = 0; i < GM.Board.Dim.Y; i++)
            {
                if (GM.Board.Map[i] != null)
                    for (int j = 0; j < GM.Board.Map[i].Count; j++)
                    {
                        if (GM.Board.Map[i][j] != null)
                        {
                            Console.Write(GM.Board.Map[i][j].Pwr);
                        }
                        Console.WriteLine();
                    }

            }
            //for(int i = 0; i < Player1.Deck.Count; i++)
            //{
            //    Console.WriteLine(Player1.Deck[i].CardName);
            //}
            //Console.WriteLine("Leader:"+Player1.Leader_Card.Leader.CardName);
            //for(int i = 0;i < Player1.Hand.Count; i++)
            //{
            //    Console.WriteLine(Player1.Hand[i].CardName);
            //}
        }
    }
}
