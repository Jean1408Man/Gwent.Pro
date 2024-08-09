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
        public Card cardTemplate;
        public TextMeshProUGUI PwrTxt;
        public TextMeshProUGUI DescriptionText;
        public Image ArtworkImg;

        void Update()
        {
            if (cardTemplate != null)
            { 
              if (cardTemplate.Power != 0)
                {
                    PwrTxt.text = cardTemplate.Power.ToString();
                    cardTemplate.PwrText = PwrTxt;
                }
                else
                    PwrTxt.text = "";
                DescriptionText.text = cardTemplate.description;
                ArtworkImg.sprite = cardTemplate.Artwork;
            }
        }
    }
}
