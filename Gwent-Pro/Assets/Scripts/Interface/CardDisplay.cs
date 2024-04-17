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
        bool activated=false;

        void Update()
        {
            if (cardTemplate != null)
            { 
              if (cardTemplate.Pwr != 0)
                {
                    PwrTxt.text = cardTemplate.Pwr.ToString();
                    cardTemplate.PwrText = PwrTxt;
                }
                else
                    PwrTxt.text = "";
                DescriptionText.text = cardTemplate.description;
                ArtworkImg.sprite = cardTemplate.Artwork;
            }
        }
        public void LeaderOnClick()
        {
            Efectos efectos= GameObject.Find("Effects").GetComponent<Efectos>();
            if (efectos != null&& !activated)
            {
                efectos.ListEffects[cardTemplate.Eff].Invoke(cardTemplate);
                activated = true;
            }
        }



    }
}
