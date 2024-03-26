using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LogicalSide;
public class GameManager : MonoBehaviour
{
    public int playerLifes = 3;
    public int oponentlifes = 3;
    public TMP_Text Pwrplayer;
    public TMP_Text Pwroponent;
    public bool PlayerSurr=false;
    public bool OponentSurr= false;
    public GameObject prefabCard;
    public GameObject prefabLeader;
    // Start is called before the first frame update
    void Start()
    {
        SetupPLayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetupPLayer()
    {
        GameObject deck = GameObject.Find("Deck");
        if (deck != null )
        {
            Player1Deck setup = deck.GetComponent<Player1Deck>();
            CardDataBase.GetCelestial(true);
            setup.deck = CardDataBase.CelestiallistCard;
            setup.Shuffle(setup.deck);
            for (int i = 0; i < 10; i++)
            {
                setup.Instanciate(setup.deck[setup.deck.Count-1],setup.playerZone,prefabCard);
            }
        }
    }
    public void AddScore(bool Downboard, int value)
    {
        if(Downboard)
        {
            Pwrplayer.text= (System.Convert.ToInt32(Pwrplayer.text) + value).ToString();
        }
        else
            Pwrplayer.text = (System.Convert.ToInt32(Pwrplayer.text) + value).ToString();
    }
    
}
