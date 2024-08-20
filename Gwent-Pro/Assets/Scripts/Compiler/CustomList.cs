using System;
using System.Collections.Generic;
using UnityEditor.Build;
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
        public CustomList<T> Find(Expression pred)
        {
            if(pred is PredicateExp predicate)
            {
                CustomList<T> custom= new(true,null);
                foreach(var item in this.list)
                {
                    if((bool)predicate.Evaluate(null, item))
                        custom.list.Add(item);
                }
                return custom;
            }
            else
                throw new Exception("Find Argument must be a predicate");
        }
        public void Add(T item)
        {
            if(AddPosibility!= null && (bool)AddPosibility&& item is Card Card)
            {
                Card card = (Card)Card.CreateCopy();
                PlayerDeck Deck;
                if(MyName== "Hand")
                {
                    Deck= GameObject.Find("Deck").GetComponent<PlayerDeck>();
                    Deck.Instanciate(card, Deck.playerZone, Deck.prefabCarta);
                }
                else if(MyName== "OtherHand")
                {
                    Deck= GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
                    Deck.Instanciate(card, Deck.playerZone, Deck.prefabCarta, true);
                }
                if(PlayerOwner!= null)
                {
                    GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                    card.DownBoard= (bool)PlayerOwner;
                    card.OnConstruction = true;
                    card.Owner= GM.WhichPlayer((bool)PlayerOwner);
                    card.OnConstruction = false;
                }
                list.Add(item);
            }
            else
                throw new Exception(MyName+ " list, is not available to Add elements, due to its Ambiguity");
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
                throw new Exception("You are trying to Shuffle a not shuffable list, please read the instructions and check the shuffable lists");
        }
        public T Pop()
        {
            if(Count>0)
            {
                T obj= this[Count-1];
                Remove(obj);
                return obj;
            }
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