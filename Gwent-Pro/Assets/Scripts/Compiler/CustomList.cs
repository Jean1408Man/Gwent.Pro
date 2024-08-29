using System;
using System.Collections.Generic;
using UnityEngine;
namespace LogicalSide
{
    public class CustomList<T>
    {
        public bool? PlayerOwner;
        public bool? AddPosibility;
        public string MyName="";
        public int? MaxElements;
        public CustomList(bool? AddPos, bool? Owner, int? MaxElems= null)
        {
            this.AddPosibility = AddPos;
            MaxElements= MaxElems;
            PlayerOwner= Owner;
        }
        
        public List<T> list = new List<T>();
        public CustomList<T> Find(Expression pred, EvaluateScope scope)
        {
            if(pred is PredicateExp predicate)
            {
                CustomList<T> custom= new(true,null);
                foreach(var item in this.list)
                {
                    if((bool)predicate.Evaluate(scope, item))
                        custom.list.Add(item);
                }
                return custom;
            }
            else
            {
                GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                GM.SendPrincipal("Para usar el método Find de una lista, debes introducir un predicate");
                throw new Exception("Para usar el método Find de una lista, debes introducir un predicate");
            }
        }
        public void Add(T item)
        {
            if(MaxElements== null || list.Count< MaxElements){
                if (AddPosibility != null && (bool)AddPosibility && item is Card Card)
                {
                    GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                    bool allfine = true;
                    Card card = (Card)Card.CreateCopy();
                    PlayerDeck Deck;
                    if (MyName == "Hand")
                    {
                        Deck = GameObject.Find("Deck").GetComponent<PlayerDeck>();
                        Deck.Instanciate(card, Deck.playerZone, Deck.prefabCarta, false);
                    }
                    else if (MyName == "OtherHand")
                    {
                        Deck = GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
                        Deck.Instanciate(card, Deck.playerZone, Deck.prefabCarta, true);
                    }
                    else if (MyName == "Field")
                    {
                        Efectos efectos = GameObject.Find("Effects").GetComponent<Efectos>();
                        allfine = efectos.AddInField(card, true);
                    }
                    else if (MyName == "OtherField")
                    {
                        Efectos efectos = GameObject.Find("Effects").GetComponent<Efectos>();
                        allfine = efectos.AddInField(card, false);
                    }
                    else if (MyName == "Board")
                    {//En este caso hay probabilidad de que se juegue a ambos lados, luego hay q sortear, y si el lado 
                     //elegido al azar no se encuentra disponible, se añade al otro lado de ser posible(2 de cada 3 veces se elegirá el lado del propietario)

                        bool[] luck = new bool[3] { card.DownBoard, card.DownBoard, !(card.DownBoard) };
                        System.Random random = new System.Random();
                        bool result = luck[random.Next(0, luck.Length)];
                        Efectos efectos = GameObject.Find("Effects").GetComponent<Efectos>();

                        if (!efectos.AddInField(card, result))
                        {
                            if (card.TypeInterno != "C" && !efectos.AddInField(card, !result))
                            {
                                GM.SendPrincipal($"Imposible añadir la carta {card.Name}");
                                allfine = false;
                            }
                        }
                    }
                    if (allfine && PlayerOwner != null && MyName != "Board" && MyName != "OtherField" && MyName != "Field")
                    {
                        card.DownBoard = (bool)PlayerOwner;
                        card.OnConstruction = true;
                        card.Owner = GM.WhichPlayer((bool)PlayerOwner);
                        card.OnConstruction = false;
                    }
                    if (allfine)
                        list.Add(item);
                }
                else
                {
                    GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                    GM.SendPrincipal(MyName + " list, is not available to Add elements, due to its Ambiguity");
                    throw new Exception(MyName + " list, is not available to Add elements, due to its Ambiguity");
                }
            }
            else
            {
                GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                GM.SendPrincipal(MyName + " list, is not available to Add elements, because you exceed the Max Elements it supports");
                throw new Exception(MyName + " list, is not available to Add elements, due to its Ambiguity");
            }
        }

        public void Remove(T item)
        {
            if(item is Card card)
            {//En caso de que la carta este siendo mostrada en la interfaz, 
            //ella seteará internamente que debe ser destruida
            //y los scripts que heredan de MonoBehavior lo detectarán, y la destruirán automaticamente
                card.Destroy= true;
            }
            for(int i = 0; i< Count; i++)
            {
                if(list[i].Equals(item)){
                    list.RemoveAt(i);
                    break;
                }
            }
        }
        // Otros métodos que delegan a la lista interna
        public int Count => list.Count;
        public T this[int index] => list[index];
        public void Shuffle()
        {
            if(MyName== "Deck"|| MyName== "OtherDeck"|| MyName== "GraveYard"|| MyName== "OtherGraveYard")
            {
                int n = list.Count;
                System.Random random= new System.Random();
                while (n > 0)
                {
                    n--;
                    int k = random.Next(n + 1);
                    (list[n], list[k]) = (list[k], list[n]);
                }
            }
            else
            {
                GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                GM.SendPrincipal("You are trying to Shuffle a not shuffable list, please read the instructions and check the shuffable lists");
                throw new Exception("You are trying to Shuffle a not shuffable list, please read the instructions and check the shuffable lists");
            }
        }
        public T Pop()
        {
            if(Count>0)
            {
                T obj= this[Count-1];
                Remove(obj);
                return obj;
            }
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.SendPrincipal("Trying to Pop from an empty List");
            throw new Exception("Trying to Pop from an empty List");
        }
        public void Push(T card)=> Add(card);
        public void SendBottom(T card)
        {
            Add(card);
            list.RemoveAt(Count-1);
            list.Insert(0,card);
        }
    }
}