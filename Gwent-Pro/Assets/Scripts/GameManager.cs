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
        static Dictionary<char, int> RangeMap1 = new Dictionary<char, int>()
        {
            ['M'] = 2,
            ['R'] = 1,
            ['S'] = 0,
        };
        static Dictionary<char, int> RangeMap2 = new Dictionary<char, int>()
        {
            ['M'] = 3,
            ['R'] = 4,
            ['S'] = 5,
        };
        public static int BoardRange(bool Downboard, char Rg)
        {
            if (Downboard)
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
        public void EndRound()
        {
            if (P1.TotalPower > P2.TotalPower)
                P2.lifes -= 1;
            else if(P2.TotalPower > P1.TotalPower)
                P1.lifes -= 1;
            else
            {
                P1.lifes-=1; P2.lifes -= 1;
            }
            if (P1.lifes == 0 || P2.lifes == 0)
                EndGame();
            else
            {
                P1.Steal(2);
                P2.Steal(2);
            }
        }
        public void EndGame()
        {//Acciones a ejecutar si terminó el juego

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
                    //player.Deck.Add(new UnityCard("Erick Cartman", "Cartman Boys", "Is truly evil in many creative ways", "Leader", "HallDog", "M","kid",2, Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M","kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    player.Deck.Add(new DecoyCard("Kenny", "You'll never pass if you don't have a permission", "HallDog", "M", "kid", Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog1", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog2", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog3", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog4", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog5", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog6", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog1", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog2", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog3", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog4", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    //player.Deck.Add(new UnityCard("Hall Dog6", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M","kid",2, Board, player));
                    break;
                case "Stan and Kyle's crew":
                    player.Deck.Add(new WeatherCard("Rain0", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain1", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new UnityCard("Hall Dog1", "Cartman Boys", "You'll never pass if you don't have a permission", "Silver", "HallDog", "M", "kid", 2, Board, player));
                    player.Deck.Add(new WeatherCard("Rain2", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain3", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain4", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain5", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain6", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain0", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain1", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain2", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain3", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain4", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain5", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    player.Deck.Add(new WeatherCard("Rain6", "You'll never pass if you don't have a permission", "Smug", "M","",Board, player));
                    break;
            }
            //Añade Cartas Clima
            //player.Deck.Add(new WeatherCard("Rain4", "You'll never pass if you don't have a permission", "Smug", "M", "", Board, player));
            //player.Deck.Add(new WeatherCard("Rain5", "You'll never pass if you don't have a permission", "Smug", "M", "", Board, player));
            //player.Deck.Add(new WeatherCard("Rain6", "You'll never pass if you don't have a permission", "Smug", "M", "", Board, player));
        }
    }
}
