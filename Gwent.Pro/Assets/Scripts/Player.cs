using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalSide
{
    public class Player
    {
        public List<Card> Deck = new List<Card>();
        public Player(string Faction) 
        {
            Deck= MainObjects.Generate(Faction);
        }
    }
}
