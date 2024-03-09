using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide
{
    [CreateAssetMenu(fileName ="New Card", menuName = "Card")]
    public class CardTemplate : ScriptableObject
    {
        public Sprite Artwork;
        public int Pwr;
        public string description;
        public string Atk_Rg;
        public string current_Atk;
    }
}
