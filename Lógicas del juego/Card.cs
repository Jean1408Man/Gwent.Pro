using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

namespace LogicalSide
{
//    [CreateAssetMenu(fileName ="New Card", menuName ="Card")]
    public class Card //ScriptableObject
    {
        // Properties
        public string CardName {get;}
        public string Faction { get; }// Means what deck is using
        public string Type { get; }// Means what kind of unity is it(Leader, silver, etc)
        public string Atk_Rg;
        public bool OnPlay = false;
        public string Description { get; }
        public Tablero Board;
        public Player Owner { get; set; }
        public int _Pwr;
        public int Pwr 
        {
            get
            {
                return _Pwr;
            }
            set
            {
                if(OnPlay== true)
                {
                    Owner.TotalPower -= Pwr;
                    _Pwr = value;
                    Owner.TotalPower= Pwr;
                }
                else
                    _Pwr = value;
            }
        }
        public int OriginPwr { get; }
        //public Sprite Appearence {get; set;}
        public Effects Eff; 

        //Constructor
        public Card(string Cardname,string Faction, string Description, int Pwr,string Type,  Effects Eff, string Atk_Rg, Tablero Board, Player Owner)
        {
            this.CardName = Cardname;
            this.Faction = Faction;
            this.Description = Description;
            this.Pwr = Pwr;
            this.OriginPwr = Pwr;
            this.Eff = Eff;
            this.Eff.AssociatedCard = this;
            this.Type = Type;
            this.Atk_Rg = Atk_Rg;
            this.Board = Board;
            this.Owner = Owner;
        }
        public void PlayCard(string Rg)
        {//Añade la carta al tablero usando su referencia
            List<Card> GameZone=Board.Map[GameManager.BoardRange(this.Owner, Rg)];
            if (this.Atk_Rg.IndexOf(Rg) != -1 && Owner.Hand.Contains(this))//Comprueba que la carta puede ser jugada en esa zona y si el jugador tiene la carta en su poder
            {
                if (GameZone == null)
                {
                    GameZone = new List<Card>
                    {
                        this
                    };
                }
                else if(GameZone.Count<6)
                GameZone.Add(this);
            }
        } 

        //Methods
        
    }
}
