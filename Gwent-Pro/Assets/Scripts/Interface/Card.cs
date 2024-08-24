using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LogicalSide
{
    public class Card: ICard
    {
        [SerializeField]private IPlayer _player;
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
                    GM.SendPrincipal("El due�o(Owner) de las cartas es de solo lectura");
                }
            }
        }

        public Sprite Artwork;
        public Sprite Fondo;
        public Sprite FactionIcon;
        [SerializeField]private string _nombre;
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
        [SerializeField] private int _pwr; // Campo de respaldo
        public bool Removable;
        [SerializeField] private bool _Destroy;
        public bool Destroy
        {
            get
            {
                return _Destroy;
            }
            set
            {
                if(value==true)
                {
                    if (Displayed)
                    {
                        _Destroy = true;
                        Displayed = false;
                    }
                }
                else
                    _Destroy = false;
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
                        if (GM != null && TypeInterno != null && (TypeInterno == "C" || TypeInterno.IndexOf("A") != -1))
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
        [SerializeField] private string _faccion;
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
                    GM.SendPrincipal("La facci�n de las cartas es de solo lectura");
                }
            } 
        }

        public int OriginPwr;
        public string description;
        [SerializeField] private string _rango;
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

        public override string Type{
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
        [SerializeField] private string _tipo;
        public string TypeInterno
        {
            get;
            set;
        }
        public TypeUnit unit;
        public string Eff;
        public bool DownBoard;
        
        //Compiler Important Member
        public override List<IEffect> Effects{get; set;}
        public override ICard CreateCopy()
        {
            Card card = new Card(DownBoard, Name, Id, OriginPwr, description, (Player)Owner, unit, TypeInterno, Eff, Range, Artwork, Removable, Type);
            CardDataBase.CustomizeCard(card);
            card.Effects= Effects;
            card.OnConstruction = true;
            card.Faction = Faction;
            card.OnConstruction = false;
            return card;
        }
        public Card(bool DownBoard ,string name , int id ,int pwr, string description,Player Owner,TypeUnit unit
        ,string type ,string Eff,string atk_Rg, Sprite Img, bool Removable, string Type)
        {
            this.Name = name;
            this.Id = id;
            this.Power = pwr;
            OriginPwr = pwr;
            this.description = description;
            this.Range = atk_Rg;
            this.Artwork = Img;
            this.TypeInterno = type;
            this.unit = unit;
            this.Eff = Eff;
            this.DownBoard = DownBoard;
            this.Removable = Removable;
            this.Owner = Owner;
            this.Type= Type;
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
