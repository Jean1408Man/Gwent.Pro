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
        public List<Card> Hand = new List<Card>();
        public List<Card> Cementery;

        public LeaderCard Leader_Card;
        public struct LeaderCard
        {
            public LeaderCard(Card card)
            {
                Leader=card;
                EffectActivated=false;
            }
            public Card Leader;
            public bool EffectActivated;

        }
        public string Faction;
        public int TotalPower=0;
        public bool Surrended=false;
        public bool DownBoard;
        public Player(string Faction) 
        {
            this.Faction = Faction;
            Cementery= new List<Card>();
        }
        public void SetUpPlayer()
        {
            Shuffle();
            AsignHand();
        }
        private void Shuffle()
        {
            Random random = new Random();
            Leader_Card = new LeaderCard(Deck[0]);
            Deck.RemoveAt(0);
            int n = Deck.Count;
            while (n > 0)
            {
                n--;
                int k = random.Next(n + 1);
                (Deck[n], Deck[k]) = (Deck[k], Deck[n]);
            }
        }
        private void AsignHand() 
        {
            for(int i = 0; i < 10; i++)
            {
                Hand.Add(Deck[i]);
            }
        }
    }
}

