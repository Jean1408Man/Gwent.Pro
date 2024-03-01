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
        public string Faction;
        public int TotalPower=0;
        public bool Surrended=false;
        public Player(string Faction) 
        {
            this.Faction = Faction;
        }
    }
}
