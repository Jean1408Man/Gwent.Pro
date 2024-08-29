using LogicalSide;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace LogicalSide
{
    public class Efectos : MonoBehaviour, IContext
    {
        #region Compiler Extension
        public bool Turn{get; set;}
        public CustomList<ICard> Deck
        {
            get
            {
                InvertDecksLocally= false;
                return DeckOfPlayer(TriggerPlayer);
            }
        }
        public CustomList<ICard> OtherDeck
        {
            get
            {
                InvertDecksLocally= true;
                CustomList<ICard> list= DeckOfPlayer(TriggerPlayer);
                InvertDecksLocally= false;
                return list;
            }
        }
        public CustomList<ICard> DeckOfPlayer(IPlayer player)
        {
            CustomList<ICard> custom;
            PlayerDeck Deck;
            if((player.Turn && !InvertDecksLocally)|| (!player.Turn && InvertDecksLocally))
            {
                custom = new(true, true);
                Deck= GameObject.Find("Deck").GetComponent<PlayerDeck>();
                custom.MyName= "Deck";
            }
            else
            {
                custom = new(true, false);
                Deck= GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
                custom.MyName= "OtherDeck";
            }
            custom.list= Deck.deck;
            return custom;
        }
        
        
        public CustomList<ICard> GraveYard
        {
            get
            {
                InvertDecksLocally= false;
                return GraveYardOfPlayer(TriggerPlayer);
            }
        }
        public CustomList<ICard> OtherGraveYard
        {
            get
            {
                InvertDecksLocally= true;
                CustomList<ICard> list= GraveYardOfPlayer(TriggerPlayer);
                InvertDecksLocally= false;
                return list;
            }
        }
        public CustomList<ICard> GraveYardOfPlayer(IPlayer player)
        {
            CustomList<ICard> custom;
            PlayerDeck Deck;
            if((player.Turn && !InvertDecksLocally)|| (!player.Turn && InvertDecksLocally))
            {
                custom = new(true, true);
                Deck= GameObject.Find("Deck").GetComponent<PlayerDeck>();
                custom.MyName= "GraveYard";
            }
            else
            {
                custom = new(true, false);
                Deck= GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
                custom.MyName= "OtherGraveYard";
            }
            custom.list = Deck.cement;
            return custom;
        }
        
        public CustomList<ICard> Field
        {
            get
            {
                InvertDecksLocally= false;
                return FieldOfPlayer(TriggerPlayer);
            }
        }
        public CustomList<ICard> OtherField
        {
            get
            {
                InvertDecksLocally= true;
                CustomList<ICard> list= FieldOfPlayer(TriggerPlayer);
                InvertDecksLocally= false;
                return list;
            }
        }
        public CustomList<ICard> FieldOfPlayer(IPlayer player)
        {
            CustomList<ICard> list;
            int discrimininant;
            if((player.Turn && !InvertDecksLocally)|| (!player.Turn && InvertDecksLocally))
            {
                discrimininant= 0;
                list= new(true, true);
                list.MyName = "Field";
            }
            else
            {
                discrimininant= 6;
                list= new(true, false);
                list.MyName = "OtherField";
            }

            for(int i = discrimininant; i<6+discrimininant ; i++)
            {
                
                for(int j = 0; j< BoardOfGameObject[i].transform.childCount; j++)
                {
                    GameObject card= BoardOfGameObject[i].transform.GetChild(j).gameObject;
                    CardDisplay disp= card.GetComponent<CardDisplay>();
                    list.list.Add(disp.cardTemplate);
                }
            }
            return list;
        }
        
        
        public CustomList<ICard> Hand
        {
            get
            {
                InvertDecksLocally= false;
                return HandOfPlayer(TriggerPlayer);
            } 
        }
        public CustomList<ICard> OtherHand
        {
            get
            {
                InvertDecksLocally= true;
                CustomList<ICard> list= HandOfPlayer(TriggerPlayer);
                InvertDecksLocally = false;
                return list;
            }
        }

        private bool InvertDecksLocally= false;
        public CustomList<ICard> HandOfPlayer(IPlayer player)
        {
            GameObject Hand;
            CustomList<ICard> cards;
            if((player.Turn && !InvertDecksLocally) || (!player.Turn && InvertDecksLocally))
            {
                Hand= GameObject.FindWithTag("P");
                cards= new(true, true, 10);
                cards.MyName= "Hand";
            }
            else
            {
                Hand= GameObject.FindWithTag("E");
                cards= new(true, false, 10);
                cards.MyName= "OtherHand";
            }
            
            GameObject Var= null;
            for(int i = 0; i< Hand.transform.childCount; i++)
            {
                Var= Hand.transform.GetChild(i).gameObject;
                CardDisplay disp= Var.GetComponent<CardDisplay>();
                cards.list.Add(disp.cardTemplate);
            }
            return cards;
        }
        public CustomList<ICard> Board
        {
            get
            {
                CustomList<ICard> list= new(true,null);
                list.MyName = "Board";
                foreach(GameObject zone in BoardOfGameObject)
                {
                    GameObject Var= null;
                    for(int i = 0; i< zone.transform.childCount; i++)
                    {
                        Var= zone.transform.GetChild(i).gameObject;
                        CardDisplay disp= Var.GetComponent<CardDisplay>();
                        list.list.Add(disp.cardTemplate);
                    }
                }
                return list;
            } 
        }
        public IPlayer TriggerPlayer
        {
            get{
                GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                return GM.WhichPlayer(GM.Turn);
            } 
        }

        #endregion
        #region Add in Fields and Board


        public bool AddInField(Card card,bool side)
        {//Este método se encarga de setear la instancia de la carta, de forma que se pueda reutilizar el metodo EndDrag asociado al prefab de la carta.
            PlayerDeck Deck = GameObject.Find("Deck").GetComponent<PlayerDeck>();
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            List<GameObject> PosiblePlaces = new List<GameObject>();
            GameObject Destiny;
            System.Random random = new System.Random();
            //Añadiendo un clima
            if (card.TypeInterno== "C")
            {
                if (Clima.transform.childCount <= 2 || card.Eff== "Light")
                {
                    GameObject Card = Deck.Instanciate(card, null, Deck.prefabCarta, !side);
                    CardDrag drag= Card.GetComponent<CardDrag>();
                    drag.Avalancha = true;
                    card.OnConstruction = true;
                    drag.Start2();
                    drag.dropzones = new(){ Clima};
                    drag.Played = false;
                    drag.IsDragging = true;
                    drag.AssociatedCard = card;
                    card.DownBoard = side;
                    card.Owner = GM.WhichPlayer(card.DownBoard);
                    card.OnConstruction = false;
                    drag.EndDrag();
                    drag.Avalancha = false;
                    //Destroy(Card);
                    return true;
                }
                else
                {
                    GM.SendPrincipal("En ejecución has tratado de agregar un clima al campo, pero ya existían 3");
                }
            }

            //Añadiendo un aumento
            if(card.TypeInterno.IndexOf("A")!= -1)
            {
                for (int i = 0; i < card.TypeInterno.Length; i= i+2)
                {
                    string s= card.TypeInterno[i].ToString()+ card.TypeInterno[i+1].ToString();
                    if (RangeMap.ContainsKey((side, s)))
                    {
                        GameObject zone = RangeMap[(side, s)];
                        if(zone.transform.childCount==0)
                            PosiblePlaces.Add(zone);
                    }
                    else
                        throw new Exception("Problemas añadiendo un aumento no justificados");
                }

                if (PosiblePlaces.Count > 0)
                {
                    Destiny = PosiblePlaces[random.Next(0, PosiblePlaces.Count)];
                    GameObject Card = Deck.Instanciate(card, null, Deck.prefabCarta, !side);
                    CardDrag drag = Card.GetComponent<CardDrag>();
                    drag.Avalancha = true;
                    card.OnConstruction = true;
                    drag.Start2();
                    drag.dropzones = new() { Destiny };
                    drag.Played = false;
                    drag.AssociatedCard = card;
                    drag.IsDragging = true;
                    card.DownBoard = side;
                    card.Owner = GM.WhichPlayer(card.DownBoard);
                    card.OnConstruction = false;
                    drag.EndDrag();
                    drag.Avalancha = false;
                    //Destroy(Card);
                    return true;
                }
                else
                    GM.SendPrincipal($"No hay un lugar disponible para la carta: {card.Name} en el campo de {GM.WhichPlayer(side).name}");

            }

            if (card.TypeInterno== "U")
            {
                for (int i = 0; i < card.Range.Length; i++)
                {
                    string s = card.Range[i].ToString();
                    if (RangeMap.ContainsKey((side, s)))
                    {
                        GameObject zone = RangeMap[(side, s)];
                        if (zone.transform.childCount <= 6)
                            PosiblePlaces.Add(zone);
                    }
                    else
                        throw new Exception("Problemas añadiendo una carta de unidad no justificados");
                }
                if (PosiblePlaces.Count > 0)
                {
                    Destiny = PosiblePlaces[random.Next(0, PosiblePlaces.Count)];
                    GameObject Card = Deck.Instanciate(card, null, Deck.prefabCarta, !side);
                    CardDrag drag = Card.GetComponent<CardDrag>();
                    card.OnConstruction = true;
                    drag.Avalancha = true;
                    drag.Start2();
                    drag.dropzones = new() { Destiny };
                    drag.Played = false;
                    drag.AssociatedCard= card;
                    drag.IsDragging = true;
                    card.DownBoard = side;
                    card.Owner = GM.WhichPlayer(card.DownBoard);
                    card.OnConstruction = false;
                    drag.EndDrag();
                    drag.Avalancha= false;
                    //Destroy(Card);
                    return true;

                }
                else
                    GM.SendPrincipal($"No hay un lugar disponible para la carta: {card.Name} en el campo de {GM.WhichPlayer(side).name}");

            }
            return false;
        }


        #endregion

        //todos los objetos a los que puede afectar un efecto
        #region
        public GameObject P1S;
        public GameObject P1R;
        public GameObject P1M;
        public GameObject P2S;
        public GameObject P2R;
        public GameObject P2M;
        public GameObject P1AM;
        public GameObject P1AR;
        public GameObject P1AS;
        public GameObject P2AM;
        public GameObject P2AR;
        public GameObject P2AS;
        public GameObject Clima;
        #endregion
        public List<GameObject> BoardOfGameObject;
        public Dictionary<(bool, string), GameObject> RangeMap;
        public Dictionary<string, Action<Card>> ListEffects;
        public Dictionary<(bool, string), GameObject> RaiseMap;
        private void Start()
        {
            RaiseMap = new Dictionary<(bool, string), GameObject>
            {
                [(true, "S")] = P1AS,
                [(true, "R")] = P1AR,
                [(true, "M")] = P1AM,
                [(false, "S")] = P2AS,
                [(false, "R")] = P2AR,
                [(false, "M")] = P2AM,
            };
            RangeMap = new Dictionary<(bool, string), GameObject>()
            {
                [(true, "M")] = P1M,
                [(true, "R")] = P1R,
                [(true, "S")] = P1S,
                [(true, "AS")] = P1AS,
                [(true, "AR")] = P1AR,
                [(true, "AM")] = P1AM,
                [(false, "M")] = P2M,
                [(false, "R")] = P2R,
                [(false, "S")] = P2S,
                [(false, "AS")] = P2AS,
                [(false, "AR")] = P2AR,
                [(false, "AM")] = P2AM,
            };
            ListEffects = new Dictionary<string, Action<Card>>()
        {
            {"Weather", Weather },
            {"Raise", Raise },
            {"None", None },
            {"Planet", Planet },
            {"Most Pwr", MostPwr},
            {"Less Pwr", LessPwr},
            {"Colmena", Colmena},
            {"Zone Cleaner", ZoneCleaner},
            {"Steal", Stealer},
            {"Light", Light},
            {"Media", Media}
        };

        BoardOfGameObject= new List<GameObject>()
        {
            P1M, 
            P1R, 
            P1S,
            P1AS,
            P1AR,
            P1AM,
            P2M,
            P2R,
            P2S,
            P2AS,
            P2AR,
            P2AM ,
            Clima,
        };
        }
        #region Unity
        public void None(Card card)
        {
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta sin efecto", GM.EffTeller);
        }
        public void Planet(Card card)
        {
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.AddScore(card.DownBoard, 20);
        }
        public void Weather(Card card)
        {//Efecto Clima Gen�rico
            foreach(char c in card.current_Rg)
            {
                GameObject C = RangeMap[(card.DownBoard, c.ToString())];
                C.GetComponent<DropProp>().DropStatus(-1);
                C = RangeMap[(!card.DownBoard, c.ToString())];
                C.GetComponent<DropProp>().DropStatus(-1);
                GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                GM.Send("Tu oponente ha jugado una carta clima", GM.EffTeller);
            }
        }
        public void Raise(Card card)
        {
            foreach (char c in card.current_Rg)
            {
                GameObject C = RangeMap[(card.DownBoard, c.ToString())];
                C.GetComponent<DropProp>().DropStatus(+1);
                GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                GM.Send("Tu oponente ha jugado una carta de aumento", GM.EffTeller);
            }
        }
        public void PlayCard(Card card)
        {
            string rg = card.current_Rg;
            int increase = 0;
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.AddScore(card.DownBoard, card.Power);
            GameObject C = RangeMap[(card.DownBoard, card.current_Rg)];
            increase = C.GetComponent<DropProp>().weather + C.GetComponent<DropProp>().raised;
            if(card.unit!= TypeUnit.Golden)
            card.Power = card.Power + increase;
            
        }
        public void Decoy(Card card)
        {//Este efecto realmente establece las dropzones
            if(card.Eff== "Weather")
            {
                foreach (char c in card.current_Rg)
                {
                    GameObject C = RangeMap[(card.DownBoard, c.ToString())];
                    C.GetComponent<DropProp>().DropOnReset(+1);
                    C = RangeMap[(!card.DownBoard, c.ToString())];
                    C.GetComponent<DropProp>().DropOnReset(+1);
                }
            }
            if (card.Eff == "Raise")
            {
                foreach (char c in card.current_Rg)
                {
                    GameObject C = RangeMap[(card.DownBoard,c.ToString())];
                    C.GetComponent<DropProp>().DropOnReset(-1);
                    //C = RangeMap[(!card.DownBoard, c.ToString())];
                    //C.GetComponent<DropProp>().DropOnReset(-1);
                }
            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta de se�uelo", GM.EffTeller);
        }
        public void MostPwr(Card card)
        {
            GameObject Bigger = null;
            GameObject Var = null;
            Card disp = null;
            Card dispvar = null;
            System.Random random = new();
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                if(Gamezone.tag.IndexOf("A") == -1)
                for (int i = 0; i < Gamezone.transform.childCount; i++)
                {
                    if (Bigger == null)
                    {
                        Var = Gamezone.transform.GetChild(i).gameObject;
                        dispvar = Var.GetComponent<CardDisplay>().cardTemplate;
                        if ((dispvar.TypeInterno == "U" || dispvar.TypeInterno == "D") && dispvar.unit == TypeUnit.Silver && dispvar.Removable)
                        {
                            Bigger = Gamezone.transform.GetChild(i).gameObject;
                            disp = Bigger.GetComponent<CardDisplay>().cardTemplate;
                        }
                    }
                    else
                    {
                        Var = Gamezone.transform.GetChild(i).gameObject;
                        dispvar = Var.GetComponent<CardDisplay>().cardTemplate;
                        if ((dispvar.TypeInterno == "U" || dispvar.TypeInterno=="D")&& dispvar.unit == TypeUnit.Silver && dispvar.Removable)
                        {
                            if (dispvar.Power > disp.Power)
                            {
                                disp = dispvar;
                                Bigger = Var;
                            }
                            else if (dispvar.Power == disp.Power)
                            {
                                int var = random.Next(0, 1);
                                if (var == 0)
                                {
                                    Bigger = Var;
                                    disp = dispvar;
                                }
                            }
                        }
                    }
                }
            }
            if (Bigger != null && disp != null)
            {
                PlayerDeck Current = Decking(disp.DownBoard);
                Decoy(disp);
                Restart(disp);
                Current.AddToCement(disp);
                Destroy(Bigger);
            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto elimina la carta con mayor poder del campo", GM.EffTeller);
        }
        public void LessPwr(Card card)
        {
            GameObject Bigger = null;
            GameObject Var = null;
            Card disp = null;
            Card dispvar = null;
            System.Random random = new();
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                if(Gamezone.tag.IndexOf("A") == -1)
                for (int i = 0; i < Gamezone.transform.childCount; i++)
                {
                    if (Bigger == null)
                    {
                        Var = Gamezone.transform.GetChild(i).gameObject;
                        dispvar = Var.GetComponent<CardDisplay>().cardTemplate;
                        if ((dispvar.TypeInterno == "U" || dispvar.TypeInterno == "D") && dispvar.unit == TypeUnit.Silver && dispvar.Removable)
                        {
                            Bigger = Gamezone.transform.GetChild(i).gameObject;
                            disp = Bigger.GetComponent<CardDisplay>().cardTemplate;
                        }
                    }
                    else
                    {
                        Var = Gamezone.transform.GetChild(i).gameObject;
                        dispvar = Var.GetComponent<CardDisplay>().cardTemplate;
                        if ((dispvar.TypeInterno == "U" || dispvar.TypeInterno == "D") && dispvar.unit == TypeUnit.Silver && dispvar.Removable)
                        {
                            if (dispvar.Power < disp.Power)
                            {
                                disp = dispvar;
                                Bigger = Var;
                            }
                            else if (dispvar.Power == disp.Power)
                            {
                                int var = random.Next(0, 1);
                                if (var == 0)
                                {
                                    Bigger = Var;
                                    disp = dispvar;
                                }
                            }
                        }
                    }
                }
            }
            if (Bigger != null && disp != null)
            {
                PlayerDeck Current = Decking(disp.DownBoard);
                Decoy(disp);
                Restart(disp);
                Current.AddToCement(disp);
                Destroy(Bigger);
            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto elimina la carta con mayor poder del campo", GM.EffTeller);
        }
        public void Media(Card card)
        {
            int totalPwr = 0;
            int cant = 0;
            Card dispvar;
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                if(Gamezone.tag.IndexOf("A") == -1)
                for (int i = 0; i < Gamezone.transform.childCount; i++)
                {
                    dispvar = Gamezone.transform.GetChild(i).gameObject.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar != null&& (dispvar.TypeInterno=="U" || dispvar.TypeInterno == "D"))
                    {
                        totalPwr += dispvar.Power;
                        cant++;
                    }
                }
            }
            int media= totalPwr/cant;
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                if(Gamezone.tag.IndexOf("A") == -1)
                for (int i = 0; i < Gamezone.transform.childCount; i++)
                {
                    dispvar = Gamezone.transform.GetChild(i).gameObject.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar != null && (dispvar.TypeInterno == "U" || dispvar.TypeInterno == "D") && dispvar.unit== TypeUnit.Silver)
                    {
                        dispvar.Power = media;
                    }
                }
            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto iguala el poder de todas las cartas de unidad del campo a al poder promedio entre todas ", GM.EffTeller);
        }
        public void Stealer(Card card)
        {
            Decking(card.Owner.Turn).InstanciateLastOnDeck(1,false);
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto le permite robar una carta", GM.EffTeller);
        }
        public void Colmena(Card card)
        {
            int increase = 0;
            Card dispvar;
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                for (int i = 0; i < Gamezone.transform.childCount; i++)
                {
                    dispvar = Gamezone.transform.GetChild(i).gameObject.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar != null && dispvar.Name == card.Name)
                    {
                        increase++;
                    }
                }
            }
            card.Power += increase;
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto provoca un aumento en el poder de dicha carta si exiten m�s cartas iguales a ella en el campo", GM.EffTeller);
        }
        public void ZoneCleanerMax(Card card)
        {//Este efecto es la misma idea del expuesto en el pdf, solo me parecio mejor eliminar la zona mas poblada, en caso de que quieran probar su funcionamiento para el otro caso basta cambiar el signo > por <
            GameObject Me;
            int childs = 0;
            GameObject Target = null;
            Card dispvar = null;

            System.Random random = new();
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                if (Gamezone.transform.childCount > childs && Gamezone.tag.IndexOf("A")==-1)
                {
                    childs = Gamezone.transform.childCount;
                    Target = Gamezone;
                }

            }
            if (Target != null && childs > 0)
            {
                for (int i = 0; i < Target.transform.childCount; i++)
                {
                    Me = Target.transform.GetChild(i).gameObject;
                    dispvar = Me.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar.Removable&& dispvar.unit!= TypeUnit.Golden)
                    {
                        PlayerDeck Current = Decking(dispvar.DownBoard);
                        Decoy(dispvar);
                        Restart(dispvar);
                        Current.AddToCement(dispvar);
                        Destroy(Me);
                    }
                }

            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto elimina la zona m�s poblada del campo(fuera de la zona propia)", GM.EffTeller);
        }
        public void ZoneCleaner(Card card)
        {
            GameObject Me;
            int childs = int.MaxValue;
            GameObject Target = null;
            Card dispvar = null;

            System.Random random = new();
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                if (Gamezone.transform.childCount!=0 && Gamezone.transform.childCount < childs && Gamezone.tag.IndexOf("A") == -1)
                {
                    childs = Gamezone.transform.childCount;
                    Target = Gamezone;
                }
            }
            if (Target != null && childs > 0)
            {
                for (int i = 0; i < Target.transform.childCount; i++)
                {
                    Me = Target.transform.GetChild(i).gameObject;
                    dispvar = Me.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar.Removable && dispvar.unit != TypeUnit.Golden)
                    {
                        PlayerDeck Current = Decking(dispvar.DownBoard);
                        Decoy(dispvar);
                        Restart(dispvar);
                        Current.AddToCement(dispvar);
                        Destroy(Me);
                    }
                }

            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto elimina la zona menos poblada del campo(no incluye la propia)", GM.EffTeller);
        }
        public void Light(Card card)
        {
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                DropProp props = Gamezone.GetComponent<DropProp>();
                if (props != null)
                {
                    for (int i = 0; i < Gamezone.transform.childCount; i++)
                    {
                        Card disp = Gamezone.transform.GetChild(i).GetComponent<CardDisplay>().cardTemplate;
                        if (disp.unit == TypeUnit.Silver&& disp.TypeInterno!="D")
                            disp.Power -= props.weather;
                    }
                    props.weather = 0;
                }
            }
            for (int i = 0; i < Clima.transform.childCount; i++)
            {
                GameObject weather = Clima.transform.GetChild(i).gameObject;
                Card disp = Clima.transform.GetChild(i).GetComponent<CardDisplay>().cardTemplate;
                PlayerDeck Current = Decking(weather);
                Current.AddToCement(disp);
                Destroy(weather);
            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.Send("Tu oponente ha jugado una carta cuyo efecto elimina los climas del campo", GM.EffTeller);
        }
        #endregion
        #region Utilities
        public void RestartCard(GameObject Card, GameObject Place, bool home)
        {
            Card card = Card.GetComponent<CardDisplay>().cardTemplate;
            Restart(card);
            if (home)
            {
                Card.GetComponent<CardDrag>().Played = false;
                GameObject Hand;
                if (card.DownBoard)
                    Hand = GameObject.FindWithTag("P");
                else
                    Hand = GameObject.FindWithTag("E");
                Card.transform.SetParent(Hand.transform, false);
            }
        }
        public PlayerDeck Decking(bool DownBoard)
        {
            if (DownBoard)
                return GameObject.Find("Deck").GetComponent<PlayerDeck>();
            else
                return GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
        }
        public void Restart(Card card)
        {//Jugando con el set de Card para que actualice automaticamente el score
            card.Power = 0;
            card.current_Rg = "";
            card.Power = card.OriginPwr;
        }
        public void ToCementery()
        {
            PlayerDeck DeckP = GameObject.Find("Deck").GetComponent<PlayerDeck>();
            PlayerDeck DeckE = GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
            PlayerDeck Current;
            GameObject card;
            List<Card> Permanents = new List<Card>();
            foreach (GameObject GameZone in RangeMap.Values)
            {
                DropProp drop = GameZone.GetComponent<DropProp>();
                if (drop != null)
                {
                    drop.weather = 0;
                    drop.raised = 0;
                }
            }
            foreach (GameObject C in RangeMap.Values)
            {
                if (C == P1M || C == P1R || C == P1S || C == P1AM || C == P1AR || C == P1AS)
                    Current = DeckP;
                else
                    Current = DeckE;

                for (int i = 0; i < C.transform.childCount; i++)
                {
                    card = C.transform.GetChild(i).gameObject;
                    CardDisplay disp = card.GetComponent<CardDisplay>();
                    if (disp != null)
                    {
                        if (disp.cardTemplate.TypeInterno == "U"&& disp.cardTemplate.Removable)
                            Restart(disp.cardTemplate);
                        if (disp.cardTemplate.Removable)
                        {
                            Current.AddToCement(disp.cardTemplate);
                            Destroy(card);
                        }
                        else
                        {
                            Permanents.Add(disp.cardTemplate);
                        }
                    }
                }
            }

            for (int i = 0; i < Clima.transform.childCount; i++)
            {
                card = Clima.transform.GetChild(i).gameObject;
                CardDisplay disp = card.GetComponent<CardDisplay>();
                Current = Decking(disp.cardTemplate.DownBoard);
                if (disp != null)
                {
                    Restart(disp.cardTemplate);
                    Current.AddToCement(disp.cardTemplate);
                    Destroy(card);
                }
            }
            foreach (Card disp in Permanents)
            {
                //Primero verifico que en el otro terreno no haya quedado en juego un clima casualmente
                int increase = 0;
                disp.Power= disp.OriginPwr;
                GameObject C = RangeMap[(disp.DownBoard, disp.current_Rg)];
                increase = C.GetComponent<DropProp>().weather + C.GetComponent<DropProp>().raised;
                if (disp.unit != TypeUnit.Golden)
                    disp.Power = disp.Power + increase;
                disp.Removable = true;
                if(disp.Eff== "Weather"|| disp.Eff== "Raise"|| disp.Eff == "Colmena")
                    ListEffects[disp.Eff](disp);
            }
        }
        #endregion

        #region Leaders
        public bool RandomizedRem(Player Player)
        {
            int cant = 0;
            Card dispvar;
            System.Random r= new();
            foreach (GameObject Gamezone in RangeMap.Values)
            {
                for (int i = 0; i < Gamezone.transform.childCount; i++)
                {
                    dispvar = Gamezone.transform.GetChild(i).gameObject.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar != null && (dispvar.TypeInterno == "U"|| dispvar.TypeInterno== "D" )&& dispvar.Owner== Player)
                    {
                        cant++;
                    }
                }
            }
            if (cant > 0)
            {
                int cant2 = r.Next(1, cant);
                cant = 1;
                foreach (GameObject Gamezone in RangeMap.Values)
                {
                    for (int i = 0; i < Gamezone.transform.childCount; i++)
                    {
                        dispvar = Gamezone.transform.GetChild(i).gameObject.GetComponent<CardDisplay>().cardTemplate;
                        if (dispvar != null && (dispvar.TypeInterno == "U" || dispvar.TypeInterno == "D") && dispvar.Owner == Player)
                        {
                            if (cant2 == cant)
                            {
                                dispvar.Removable = false;
                                return true;
                            }
                            else
                                cant++;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
