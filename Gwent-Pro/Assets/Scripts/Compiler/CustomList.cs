using System;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
namespace LogicalSide
{

public class CustomList<T>
{
    public bool? AddPosibility;
    public string MyName="";
    public int? MaxElements;
    public CustomList(bool? AddPos, int? MaxElems= null)
    {
        this.AddPosibility = AddPos;
        MaxElements= MaxElems;
    }
    
    public List<T> list = new List<T>();
    public CustomList<T> Find(Expression pred)
    {
        if(pred is PredicateExp predicate)
        {
            CustomList<T> custom= new(true);
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
        if(AddPosibility!= null && (bool)AddPosibility&& item is Card card)
        {
            PlayerDeck Deck;
            if(MyName== "Hand")
            {
                Deck= GameObject.Find("Player Hand").GetComponent<PlayerDeck>();
                Deck.Instanciate(card, Deck.playerZone, Deck.prefabCarta);
            }
            else if(MyName== "OtherHand")
            {
                Deck= GameObject.Find("Enemy Hand").GetComponent<PlayerDeck>();
                Deck.Instanciate(card, Deck.playerZone, Deck.prefabCarta);
            }
            
            list.Add(item);
        }
        else
            throw new Exception(MyName+ " list, is not available to Add elements, due to its Ambiguity");
    }

    public bool Remove(T item)
    {
        if(item is Card card)
        {
            card.DestroyIfDisplayed= true;
        }
        return list.Remove(item);
    }
    // Otros métodos que delegan a la lista interna
    public int Count => list.Count;
    public T this[int index] => list[index];
    public void Shuffle()
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
    public T Pop()
    {
        T obj= list[list.Count-1];
        list.RemoveAt(list.Count-1);
        return obj;
    }
    public void Push(T card)=> list.Add(card);
    public void SendBottom(T card)=> list.Insert(0,card);
}
}