using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LogicalSide
{
    public class Card: ICard
    {
        public override IPlayer Owner{get; set;}

        public Sprite Artwork;
        public Sprite Fondo;
        public Sprite FactionIcon;
        public override string Name{get; set;}
        public int Id;
        private int _pwr; // Campo de respaldo
        public bool Removable;
        private bool _Destroy;
        public bool Destroy
        {
            get
            {
                return _Destroy;
            }
            set
            {
                if(Displayed&& value==true)
                {
                    _Destroy= true;
                }
            }
        }
        public bool Displayed=false;
        public bool SeteablePower;
        public override int Power
        {
            get { return _pwr; }
            set
            {
                int provi = _pwr;
                _pwr = value; // Almacena el valor en el campo de respaldo
                GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (GM != null&& current_Rg!=""&& current_Rg!=null)
                {
                    GM.AddScore(DownBoard,_pwr-provi);
                }
                if(PwrText!=null)
                PwrText.text = _pwr.ToString();
            }

        }
        public override string Faction{get; set;}

        public int OriginPwr;
        public string description;
        public override string Range{get; set;}
        public string current_Rg;
        public override string Type{get; set;}
        public TypeUnit unit;
        public string Eff;
        public bool DownBoard;
        public TextMeshProUGUI PwrText= new();
        
        //Compiler Important Member
        public override List<IEffect> Effects{get; set;}
        public override ICard CreateCopy()
        {
            Card card = new Card(DownBoard, Name, Id, Power, description, (Player)Owner, unit, Type, Eff, Range, Artwork, Removable, SeteablePower);
            card.Effects= Effects;
            return card;
        }
        public bool Igual(Card obj)
        {
            if(obj is Card card)
            {
                if(this.Name != card.Name)
                    return false;
                if(this.Id != card.Id)
                    return false;
                if(this.Power != card.Power)
                return false;
                if(this.description != card.description)
                    return false;
                if(this.Range != card.Range)
                    return false;
                if(this.Artwork != card.Artwork)
                    return false;
                if(this.Type != card.Type)
                    return false;
                if(this.unit != card.unit)
                    return false;
                if(this.Eff != card.Eff)
                    return false;
                if(this.Removable != card.Removable)
                    return false;
                if(this.Owner != card.Owner)
                    return false;
                if(!Effects.Equals(card.Effects))
                    return false;

                return true;
            }
            return false;
        }
        public Card(bool DownBoard ,string name , int id ,int pwr, string description,Player Owner,TypeUnit unit
        ,string type ,string Eff,string atk_Rg, Sprite Img, bool Removable, bool Seteable= true)
        {
            this.Name = name;
            this.Id = id;
            this.Power = pwr;
            OriginPwr = pwr;
            this.description = description;
            this.Range = atk_Rg;
            this.Artwork = Img;
            this.Type = type;
            this.unit = unit;
            this.Eff = Eff;
            this.DownBoard = DownBoard;
            this.Removable = Removable;
            this.Owner = Owner;
        }
    }
    public enum Type
    {
        Leader,
        Weather,
        Unity,
        Decoy,
        Raise,
    }
    public enum TypeUnit
    {
        Golden,
        Silver,
        None
    }
}
