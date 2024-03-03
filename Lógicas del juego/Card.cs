using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

namespace LogicalSide
{
//    [CreateAssetMenu(fileName ="New Card", menuName ="Card")]
    
    public abstract class Card
    {
        public abstract string CardName { get; }
        public abstract string Atk_Rg { get; set; }
        public abstract bool OnPlay { get; set; }
        public abstract string Description { get; }
        public abstract Tablero Board {  get; set; }
        public abstract Player Owner { get; set; }
        public abstract Effects Eff { get; set;}
        public abstract void PlayCard(string Rg);
    }
    public class UnityCard: Card //ScriptableObject
    {
        // Properties
        public override string CardName {get;}
        public string Faction { get; }// Means what deck is using
        public string Type { get; }// Means what kind of unity is it(Leader, silver, etc)
        public override string Atk_Rg { get; set;}
        public override bool OnPlay { get; set; }
        public override string Description { get; }
        public override Tablero Board { get; set;}
        public override Player Owner { get; set; }
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
        public override Effects Eff { get; set; } 

        //Constructor
        public UnityCard(string Cardname,string Faction, string Description, int Pwr,string Type,  Effects Eff, string Atk_Rg, Tablero Board, Player Owner)
        {
            this.CardName = Cardname;
            this.Faction = Faction;
            this.Description = Description;
            this.Pwr = Pwr;
            this.OriginPwr = Pwr;
            this.Eff = Eff;
            Eff.AssociatedCard = this;
            this.Type = Type;
            this.Atk_Rg = Atk_Rg;
            this.Board = Board;
            this.Owner = Owner;
        }
        public override void PlayCard(string Rg)
        {//Añade la carta al tablero usando su referencia
            List<UnityCard> GameZone=Board.Map[GameManager.BoardRange(this.Owner, Rg)];
            if (this.Atk_Rg.IndexOf(Rg) != -1 && Owner.Hand.Contains(this))//Comprueba que la carta puede ser jugada en esa zona y si el jugador tiene la carta en su poder
            {
                if (GameZone == null)
                {
                    GameZone = new List<UnityCard>
                        {
                            this
                        };
                }
                else if (GameZone.Count < 6)
                {
                    GameZone.Add(this);
                    this.Eff.Act();
                    this.OnPlay = true;
                }
                foreach (WeatherCard weather in Board.Weather)
                {
                    if (weather.Atk_Rg.IndexOf(Rg) != -1)
                    {
                        this.Pwr -= 1;
                    }
                }
                Board.Map[GameManager.BoardRange(this.Owner, Rg)] = GameZone;
            }
        }
    }
    public class WeatherCard : Card
    {
        public override string CardName { get; }
        public override string Atk_Rg { get; set; }
        public override bool OnPlay { get; set; }
        public override string Description { get; }
        public override Tablero Board { get; set; }
        public override Player Owner { get; set; }
        public override Effects Eff { get; set; }

        public WeatherCard(string Cardname, string Description,Effects Eff, string Atk_Rg, Tablero Board, Player Owner)
        {
            this.CardName = Cardname;
            this.Description = Description;
            this.Eff = Eff;
            this.Eff.AssociatedCard = this;
            this.Atk_Rg = Atk_Rg;
            this.Board = Board;
            this.Owner = Owner;
        }
        public override void PlayCard(string Rg)
        {//Añade la carta a la zona de climas si es posible
            if (Owner.Hand.Contains(this) && Board.Weather.Count<=2)
            {
                this.Eff.Act();
                Board.Weather.Add(this);
            }
        }
    }
}
