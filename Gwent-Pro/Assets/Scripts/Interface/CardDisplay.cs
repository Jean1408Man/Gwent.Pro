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
        public Image Back;
        bool activated=false;
        public GameObject Playerzone;
        public GameObject Enemyzone;
        GameManager GM;
        private void Start()
        {
            GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            Playerzone = GameObject.FindWithTag("P");
            Enemyzone = GameObject.Find("Enemy Hand");
        }

        void Update()
        {
            if (cardTemplate == null)
            {
                Debug.Log("nullll");
                GameObject debug = gameObject;
            }
            else
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
                if (cardTemplate.DownBoard != GM.Turn && (transform.parent == Playerzone || transform.parent == Enemyzone))
                    Back.gameObject.SetActive(true);
            }
        }
        public void Checkout()
        {
            
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
