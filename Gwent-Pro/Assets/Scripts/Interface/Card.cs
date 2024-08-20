using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LogicalSide
{
    public class Card: ICard
    {
        private IPlayer _player;
        public override IPlayer Owner
        {
            get { return _player; }
            set
            {
                if (OnConstruction) _player = value;
                else
                {
                    GameManager GM = null;
                    GameObject Object = GameObject.Find("GameManager");
                    if (Object != null)
                        GM = Object.GetComponent<GameManager>();
                    GM.SendPrincipal("El dueño(Owner) de las cartas es de solo lectura");
                }
            }
        }

        public Sprite Artwork;
        public Sprite Fondo;
        public Sprite FactionIcon;
        private string _nombre;
        public override string Name
        {
            get { return _nombre; }
            set
            {
                if (OnConstruction) _nombre = value;
                else
                {
                    GameManager GM = null;
                    GameObject Object = GameObject.Find("GameManager");
                    if (Object != null)
                        GM = Object.GetComponent<GameManager>();
                    GM.SendPrincipal("El nombre de las cartas es de solo lectura");
                }
            }
        }
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
                    Displayed = false;
                }
            }
        }
        public bool Displayed=false;


        public bool OnConstruction = true;
        public override int Power
        {
            get { return _pwr; }
            set
            {
                if(!OnConstruction)
                {
                    GameManager GM=null;
                    GameObject Object = GameObject.Find("GameManager");
                    if(Object != null)
                        GM= Object.GetComponent<GameManager>();
                    if (_pwr != value)
                    {
                        if (GM != null && Type != null && (Type == "C" || Type.IndexOf("A") != -1))
                            GM.SendPrincipal("Has tratado de modificar el poder de un clima o un aumento, lo cual no es permitido pues no tienen");
                        else
                        {

                            int provi = _pwr;
                            _pwr = value; // Almacena el valor en el campo de respaldo
                            if (GM != null && current_Rg != "" && current_Rg != null)
                            {
                                GM.AddScore(DownBoard, _pwr - provi);
                            }

                        }
                    }
                }
                else
                {
                    int provi = _pwr;
                    _pwr = value;
                }
            }

        }
        private string _faccion;
        public override string Faction{ 
            get { return _faccion; } 
            set 
            {
                if (OnConstruction) _faccion = value;
                else
                {
                    GameManager GM = null;
                    GameObject Object = GameObject.Find("GameManager");
                    if (Object != null)
                        GM = Object.GetComponent<GameManager>();
                    GM.SendPrincipal("La facción de las cartas es de solo lectura");
                }
            } 
        }

        public int OriginPwr;
        public string description;
        private string _rango;
        public override string Range
        {
            get { return _rango; }
            set
            {
                if (OnConstruction) _rango = value;
                else
                {
                    GameManager GM = null;
                    GameObject Object = GameObject.Find("GameManager");
                    if (Object != null)
                        GM = Object.GetComponent<GameManager>();
                    GM.SendPrincipal("El rango de las cartas es de solo lectura");
                }
            }
        }
        public string current_Rg;
        private string _tipo;
        public override string Type
        {
            get { return _tipo; }
            set
            {
                if (OnConstruction) _tipo = value;
                else
                {
                    GameManager GM = null;
                    GameObject Object = GameObject.Find("GameManager");
                    if (Object != null)
                        GM = Object.GetComponent<GameManager>();
                    GM.SendPrincipal("El tipo de las cartas es de solo lectura");
                }
            }
        }
        public TypeUnit unit;
        public string Eff;
        public bool DownBoard;
        
        //Compiler Important Member
        public override List<IEffect> Effects{get; set;}
        public override ICard CreateCopy()
        {
            Card card = new Card(DownBoard, Name, Id, OriginPwr, description, (Player)Owner, unit, Type, Eff, Range, Artwork, Removable);
            CardDataBase.CustomizeCard(card);
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
        ,string type ,string Eff,string atk_Rg, Sprite Img, bool Removable)
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
            OnConstruction = false;
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
