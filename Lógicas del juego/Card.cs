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
        public (bool M,bool R, bool S) Atk_Rg;
        public bool OnPlay = false;
        public string Description { get; }
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
        //public Sprite Appearence { get; set; }
        public Effects Eff; 

        //Constructor
        public Card(string Cardname,string Faction, string Description, int Pwr,string Type,  Effects Eff, (bool M, bool R, bool S) Atk_Rg)
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
        }
        

        //Methods
        
    }
}
