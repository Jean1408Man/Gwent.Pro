using LogicalSide;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace LogicalSide
{
    public class CardDisplay : MonoBehaviour
    {   
        private void Start() 
        {
            Ranges= new Dictionary<char, Sprite>
            {
                {'M', Resources.Load<Sprite>("Melee")},
                {'R', Resources.Load<Sprite>("Range")},
                {'S', Resources.Load<Sprite>("Siege")}
            };
        }
        public Dictionary<char, Sprite> Ranges;
        public bool ImBig= false;
        bool displayed= false;
        public Card cardTemplate;
        void Update()
        {
            if (cardTemplate != null)
            {
                if(cardTemplate.Destroy)
                {
                    Destroy(gameObject);
                }
                //Actualizacion de Poder
                if(cardTemplate.Power != 0)
                {
                    gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = cardTemplate.Power.ToString();
                }
                else
                    gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
                if(!displayed)
                {
                    //Fondo de carta
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = cardTemplate.Fondo;
                    //Descripcion
                    gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardTemplate.description;
                    //Back
                    gameObject.transform.GetChild(7).GetComponent<Image>().sprite = Resources.Load<Sprite>("Deck");
                    //Nombre de carta
                    gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text= cardTemplate.Name;
                    //Faction de carta
                    gameObject.transform.GetChild(5).GetComponent<Image>().sprite= cardTemplate.FactionIcon;
                    //Imagen de carta
                    gameObject.transform.GetChild(1).GetComponent<Image>().sprite = cardTemplate.Artwork;

                    PlayerDeck deck = GameObject.Find("Deck").GetComponent<PlayerDeck>();
                    GameObject prefab;
                    Transform iconzone= gameObject.transform.GetChild(6).transform;
                    if(ImBig)
                    prefab = deck.BigRangeIcons;
                    else
                    prefab = deck.RangeIcons;

                    foreach(char c in cardTemplate.Range)
                    {
                        GameObject instanciarange = Instantiate(prefab, iconzone);
                        instanciarange.GetComponent<Image>().sprite= Ranges[c];
                    }
                    displayed= true;
                    
                }
            }
        }
    }
}
