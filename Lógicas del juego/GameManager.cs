using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Unity.VisualScripting;

namespace LogicalSide
{
    public class GameManager
    {
        // Properties
        public Tablero Board;
        Player P1, P2;
        static Dictionary<string, int> RangeMap1 = new Dictionary<string, int>()
        {
            ["M"] = 2,
            ["R"] = 1,
            ["S"] = 0,
        };
        static Dictionary<string, int> RangeMap2 = new Dictionary<string, int>()
        {
            ["M"] = 3,
            ["R"] = 4,
            ["S"] = 5,
        };
        public static int BoardRange(Player player, string Rg)
        {
            if (player.DownBoard)
                return RangeMap1[Rg];
            else
                return RangeMap2[Rg];
        }

        public GameManager(Player P1, Player P2)
        {
            this.P1 = P1;
            this.P2 = P2;
            Board = new Tablero();
            InitializeProperties();
        }
        
        public void InitializeProperties()
        {
            AllCardsFrom(P1);
            AllCardsFrom(P2);
        }
        public void AllCardsFrom(Player player)
        {//Inizialize Particular Cards
            switch(player.Faction)
            {
                case "Cartman Boys":
                    player.Deck.Add(new UnityCard("Erick Cartman", "Cartman Boys", "Is truly evil in many creative ways", 0, "Leader", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog1", "Cartman Boys", "You'll never pass if you don't have a permission", 1, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog2", "Cartman Boys", "You'll never pass if you don't have a permission", 2, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog3", "Cartman Boys", "You'll never pass if you don't have a permission", 3, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog4", "Cartman Boys", "You'll never pass if you don't have a permission", 4, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog5", "Cartman Boys", "You'll never pass if you don't have a permission", 5, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog6", "Cartman Boys", "You'll never pass if you don't have a permission", 6, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog1", "Cartman Boys", "You'll never pass if you don't have a permission", 1, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog2", "Cartman Boys", "You'll never pass if you don't have a permission", 2, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog3", "Cartman Boys", "You'll never pass if you don't have a permission", 3, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog4", "Cartman Boys", "You'll never pass if you don't have a permission", 4, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog5", "Cartman Boys", "You'll never pass if you don't have a permission", 5, "Silver", new HallDog(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog6", "Cartman Boys", "You'll never pass if you don't have a permission", 6, "Silver", new HallDog(), "M", Board, player));
                    break;
                case "Stan and Kyle's crew":
                    player.Deck.Add(new UnityCard("Rain0", "School Devils", "You'll never pass if you don't have a permission", 0, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain1", "School Devils", "You'll never pass if you don't have a permission", 1, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain2", "School Devils", "You'll never pass if you don't have a permission", 2, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain3", "School Devils", "You'll never pass if you don't have a permission", 3, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain4", "School Devils", "You'll never pass if you don't have a permission", 4, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain5", "School Devils", "You'll never pass if you don't have a permission", 5, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain6", "School Devils", "You'll never pass if you don't have a permission", 6, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain0", "School Devils", "You'll never pass if you don't have a permission", 0, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain1", "School Devils", "You'll never pass if you don't have a permission", 1, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain2", "School Devils", "You'll never pass if you don't have a permission", 2, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain3", "School Devils", "You'll never pass if you don't have a permission", 3, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain4", "School Devils", "You'll never pass if you don't have a permission", 4, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain5", "School Devils", "You'll never pass if you don't have a permission", 5, "Silver", new Rain(), "M", Board, player));
                    player.Deck.Add(new UnityCard("Rain6", "School Devils", "You'll never pass if you don't have a permission", 6, "Silver", new Rain(), "M", Board, player));
                    break;
                   
            }
            //Añade Cartas Clima
            player.Deck.Add(new UnityCard("Clima M", "Weather", "You'll never pass if you don't have a permission", 6, "Silver", new Rain(), "M", Board, player));
            player.Deck.Add(new UnityCard("Clima R", "Weather", "You'll never pass if you don't have a permission", 6, "Silver", new Rain(), "M", Board, player));
            player.Deck.Add(new UnityCard("Clima S", "Weather", "You'll never pass if you don't have a permission", 6, "Silver", new Rain(), "M", Board, player));
        }
    }
}
