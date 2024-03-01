using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide
{
    [CreateAssetMenu(fileName ="New Card", menuName ="Card")]
    public class Card: ScriptableObject
    {
        // Properties
        public string CardName {get;}
        public string Faction { get; }// Means what deck is using
        public string Type { get; }// Means what kind of unity is it
        public string Description { get; }
        public bool Increased=false;
        public Player Owner { get; set; }
        public int Pwr 
        {
            get {  return Pwr; } 
            set
            {
                Debug.Log("All Right set");
                Owner.TotalPower -= Pwr;
                Debug.Log("All Right TotalPwr");
                Pwr = value;
                Debug.Log("All Right Pwr");
                Owner.TotalPower += Pwr;
            }
                
        }
        public int OriginPwr { get; }
        public Sprite Appearence { get; set; }
        public Effects Eff; 

        //Constructor
        public Card(string Cardname,string Faction, string Description, int Pwr, Effects Eff)
        {
            this.CardName = Cardname;
            this.Faction = Faction;
            this.Description = Description;
            this.Pwr = Pwr;
            this.OriginPwr = Pwr;
            this.Eff = Eff;
            this.Eff.AssociatedCard = this;
        }
        

        // Static Methods
        
    }
}
