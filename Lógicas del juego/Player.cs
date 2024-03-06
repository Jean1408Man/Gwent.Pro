using System;
using System.Buffers;
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
        public int lifes {  get; set; }
        public Player(string Faction) 
        {
            this.Faction = Faction;
            Cementery= new List<Card>();
            lifes = 2;
        }
        public void SetUpPlayer()
        {
            //Shuffle();
            AsignHand();
        }
        //private void Shuffle()
        //{
        //    Random random = new Random();
        //    Leader_Card = new LeaderCard(Deck[0]);
        //    Deck.RemoveAt(0);
        //    int n = Deck.Count;
        //    while (n > 0)
        //    {
        //        n--;
        //        int k = random.Next(n + 1);
        //        (Deck[n], Deck[k]) = (Deck[k], Deck[n]);
        //    }
        //}
        private void AsignHand() 
        {
            for(int i = 0; i < 10; i++)
            {
                Hand.Add(Deck[i]);
            }
        }
        public void Robar(int veces)
        {//Robar del Deck
            for (int i = 0; i < veces; i++)
            {
                if (Deck != null && Hand.Count < 10)
                {
                    Hand.Add(Deck[Deck.Count - 1]);
                    Deck.RemoveAt(Deck.Count - 1);
                }
            }
        }
        public void Awake(Card card)
        {
            if(card != null && card.Owner.Cementery.Contains(card))
            {
                card.Owner.Cementery.Remove(card);
                card.Owner.Hand.Add(card);

                card.OnPlay = false;
                if(card as UnityCard != null)
                {
                    UnityCard unity= card as UnityCard;
                    unity.Pwr = unity.OriginPwr;
                }
                else if(card as DecoyCard!= null)
                {
                    DecoyCard decoy= card as DecoyCard;
                    decoy.Pwr = 0;
                }
            }

        }
    }
}

