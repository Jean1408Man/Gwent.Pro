using Lógicas_del_juego;
using System;
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
        public List<Card> AllCards= new List<Card>();
        public static Tablero Board;

        public GameManager()
        {
            InitializeProperties();
            Board = new Tablero();
        }
        public void InitializeProperties()
        {
            //Initialize Faction Sweet Kids
            AllCards.Add(new Card("The Hall Guardian", "Sweet Kids", "You'll never pass if you don't have a permission", 5,"Silver", new HallDog(),(true,false,false)));
            AllCards.Add(new Card("1", "Sweet Kids", "You'll never pass if you don't have a permission", 1,"Silver", new HallDog(),(true,false,false)));
            AllCards.Add(new Card("2", "Sweet Kids", "You'll never pass if you don't have a permission", 2,"Silver", new HallDog(),(true,false,false)));
            AllCards.Add(new Card("3", "Sweet Kids", "You'll never pass if you don't have a permission", 3,"Silver", new HallDog(),(true,false,false)));
            AllCards.Add(new Card("4", "Sweet Kids", "You'll never pass if you don't have a permission", 4,"Silver", new HallDog(),(true,false,false)));
            AllCards.Add(new Card("5", "Sweet Kids", "You'll never pass if you don't have a permission", 5,"Silver", new HallDog(),(true,false,false)));
            AllCards.Add(new Card("6", "Sweet Kids", "You'll never pass if you don't have a permission", 6,"Silver", new HallDog(),(true,false,false)));
            //Initialize Faction 
        }
        public void Generate(Player owner)
        {
            for (int i = 0; i < AllCards.Count; i++)
                if (AllCards[i].Faction == owner.Faction)
                    owner.Deck.Add(AllCards[i]);
        }
    }
}
