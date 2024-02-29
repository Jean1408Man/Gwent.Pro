using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide
{
    [CreateAssetMenu(fileName ="New Card", menuName ="Card")]
    public class Card: ScriptableObject
    {
        // Properties
        string CardName {get;}
        public string Faction { get; }// Means what deck is using
        public string Type { get; }// Means 
        public string Description { get; }
        public int Pwr { get; set; }
        public int OriginPwr { get; }
        public Sprite Appearence { get; set; }
        public Effe

        //Constructor
        public Card(string Cardname,string Faction, string Description, int Pwr)
        {
            this.CardName = Cardname;
            this.Faction = Faction;
            this.Description = Description;
            this.Pwr = Pwr;
        }
        

        // Methods
        
    }
}
