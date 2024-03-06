using System;
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
        public abstract (int index,char value) currentRg { get; set;}
        public abstract bool OnPlay { get; set; }
        public abstract string Description { get; }
        public abstract Tablero Board {  get; set; }
        public abstract Player Owner { get; set; }
        public abstract string Eff { get; set;}
        public abstract void PlayCard(char Rg);
        public abstract string AttributeCard { get; set; }
    }
    public class UnityCard: Card //ScriptableObject
    {//Internamente tb las cartas señuelo serán de tipo UnityCard
        // Properties
        public override string CardName {get;}
        public string Faction { get; }// Means what deck is using
        public string Type { get; }// Means what kind of unity is it( gold, silver, etc)
        public override string Atk_Rg { get; set;}
        public override (int index, char value) currentRg { get; set;}
        public override bool OnPlay { get; set; }
        public override string Description { get; }
        public override Tablero Board { get; set;}
        public override Player Owner { get; set; }
        public override string AttributeCard { get; set; }
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
        public override string Eff { get; set; } 

        //Constructor
        public UnityCard(string Cardname,string Faction, string Description, string Type,  string Eff, string Atk_Rg,string AttributeCard, int Pwr, Tablero Board, Player Owner)
        {
            this.CardName = Cardname;
            this.Faction = Faction;
            this.Description = Description;
            this.Pwr = Pwr;
            this.OriginPwr = Pwr;
            this.Eff = Eff;
            this.Type = Type;
            this.Atk_Rg = Atk_Rg;
            this.Board = Board;
            this.Owner = Owner;
            this.AttributeCard = AttributeCard;
        }
        public override void PlayCard(char Rg)
        {//Añade la carta al tablero usando su referencia
            
            if (this.Atk_Rg.IndexOf(Rg)!=-1 && Owner.Hand.Contains(this)&& !this.OnPlay)//Comprueba que la carta puede ser jugada en esa zona y si el jugador tiene la carta en su poder
            {
                List<Card> GameZone = Board.Map[GameManager.BoardRange(this.Owner.DownBoard, Rg)];
                if (GameZone == null)
                {
                    GameZone = new List<Card>
                        {
                            this
                        };
                    
                }
                else if (GameZone.Count < 6)
                {
                    GameZone.Add(this);
                }
                if(GameZone.Count < 6)
                {
                    this.Owner.Hand.Remove(this);
                    currentRg = (GameManager.BoardRange(this.Owner.DownBoard, Rg),Rg);
                    Effects.Efectos[Eff].Invoke(this);
                    this.OnPlay = true;
                    foreach (WeatherCard weather in Board.Weather)
                    {
                        if (weather.Atk_Rg.IndexOf((Rg)) != -1)
                        {
                            this.Pwr -= 1;
                        }
                    }
                    Board.Map[GameManager.BoardRange(this.Owner.DownBoard, Rg)] = GameZone;
                }
                
            }
        }
    }
    public class WeatherCard : Card
    {
        public override string CardName { get; }
        public override string Atk_Rg { get; set; }
        public override (int index, char value) currentRg { get; set; }
        public override bool OnPlay { get; set; }
        public override string Description { get; }
        public override Tablero Board { get; set; }
        public override Player Owner { get; set; }
        public override string Eff { get; set; }
        public override string AttributeCard { get; set; }

        public WeatherCard(string Cardname, string Description,string Eff, string Atk_Rg,string AttributeCard, Tablero Board, Player Owner)
        {
            this.CardName = Cardname;
            this.Description = Description;
            this.Eff = Eff;
            this.Atk_Rg = Atk_Rg;
            this.Board = Board;
            this.Owner = Owner;
            this.AttributeCard = AttributeCard;
        }
        public override void PlayCard(char Rg)
        {//Añade la carta a la zona de climas si es posible
            if (Owner.Hand.Contains(this) && Board.Weather.Count<=2 && !OnPlay)
            {
                OnPlay=true;
                Effects.Efectos[Eff].Invoke(this);
                currentRg = (GameManager.BoardRange(this.Owner.DownBoard, Rg),Rg);
                Board.Weather.Add(this);
            }
        }
    }
    public class RaiseCard : Card
    {
        public override string CardName { get; }
        public override string Atk_Rg { get; set; }
        public override (int index, char value) currentRg { get; set; }
        public override bool OnPlay { get; set; }
        public override string Description { get; }
        public override Tablero Board { get; set; }
        public override Player Owner { get; set; }
        public override string Eff { get; set; }
        public override string AttributeCard { get; set; }

        public RaiseCard(string Cardname, string Description, string Eff, string Atk_Rg, string AttributeCard, Tablero Board, Player Owner)
        {
            this.CardName = Cardname;
            this.Description = Description;
            this.Eff = Eff;
            this.Atk_Rg = Atk_Rg;
            this.Board = Board;
            this.Owner = Owner;
            this.AttributeCard = AttributeCard;
        }
        public override void PlayCard(char Rg)
        {//Añade la carta a la zona de climas si es posible
            if (Owner.Hand.Contains(this)&& Atk_Rg.IndexOf(Rg)!=-1 && Board.Raise[GameManager.BoardRange(Owner.DownBoard,Rg)]!= null && !OnPlay)
            {
                OnPlay = true;
                currentRg = (GameManager.BoardRange(Owner.DownBoard, Rg), Rg);
                Effects.Efectos[Eff].Invoke(this);
                Board.Raise[currentRg.index]= this;
            }
        }
    }
    public class DecoyCard : Card
    {
        public override string CardName { get; }
        public override string Atk_Rg { get; set; }
        public override (int index, char value) currentRg {  get; set; }
        public override bool OnPlay { get; set; }
        public override string Description { get; }
        public override Tablero Board { get; set; }
        public override Player Owner { get; set; }
        public override string Eff { get; set; }
        public override string AttributeCard { get; set; }
        public int _Pwr=0;
        public int Pwr
        {
            get
            {
                return _Pwr;
            }
            set
            {
                if (OnPlay == true)
                {
                    Owner.TotalPower -= Pwr;
                    _Pwr = value;
                    Owner.TotalPower = Pwr;
                }
                else
                    _Pwr = value;
            }
        }
        public int OriginPwr { get; }

        
        public UnityCard Exchange { get; set; }

        public DecoyCard(string Cardname, string Description, string Eff, string Atk_Rg, string AttributeCard, Tablero Board, Player Owner)
        {
            this.CardName = Cardname;
            this.Description = Description;
            this.Eff = Eff;
            this.Atk_Rg = Atk_Rg;
            this.Board = Board;
            this.Owner = Owner;
            this.AttributeCard = AttributeCard;
        }
        public override void PlayCard(char Rg)
        {//IMPORTANTE, ANTES DE USAR UN DECOY ASIGNAR EXCHANGE 
            if(Owner.Hand.Contains(this) && !OnPlay && Exchange != null)
            for (int i = 0; i < this.Atk_Rg.Length; i++)
            if (this.Atk_Rg[i] == Rg)
            {
                OnPlay = true;
                currentRg = (GameManager.BoardRange(this.Owner.DownBoard, Rg), Rg);
                Effects.Efectos[Eff].Invoke(this);
            }
        }
    }
}
