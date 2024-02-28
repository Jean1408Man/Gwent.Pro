using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName ="New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    string CardName;
    public string Faction;
    public string CardType;
    public string Description;
    public int Power;
    public Sprite Appearence;

}
