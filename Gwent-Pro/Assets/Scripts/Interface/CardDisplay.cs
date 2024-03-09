using LogicalSide;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LogicalSide
{
    public class CardDisplay : MonoBehaviour
    {
        public CardTemplate cardTemplate;
        public TMP_Text Pwr;
        public TMP_Text DescriptionText;
        public Image ArtworkImg;
        public Transform objetoVacio;


        void Start()
        {
            Pwr.text = cardTemplate.Pwr.ToString();
            DescriptionText.text = cardTemplate.description;
            ArtworkImg.sprite = cardTemplate.Artwork; 

        }



    }
}
