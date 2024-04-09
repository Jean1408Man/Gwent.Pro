using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LogicalSide;
using UnityEngine.UIElements;
using System;
public class GameManager : MonoBehaviour
{
    public GameObject Eff;
    public GameObject World;
    public int playerLifes = 3;
    public int oponentlifes = 3;
    public TMP_Text Pwrplayer;
    public TMP_Text Pwroponent;
    public UnityEngine.UI.Button Pass;
    public bool PlayerSurr=false;
    public bool OponentSurr= false;
    public GameObject prefabCard;
    public GameObject prefabLeader;
    private bool _turn1=true;
    public bool Turn1
    {
        get { return _turn1; }
        set 
        { 
            if(_turn1 != value)
            {
                _turn1 = value;
                Rotate();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupPLayers();
        Turn1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if(OponentSurr&& PlayerSurr)
            //Ronda Terminada
    }
    public void SetupPLayers()
    {
        GameObject deck = GameObject.Find("Deck");
        if (deck != null )
        {
            Player1Deck setup = deck.GetComponent<Player1Deck>();
            setup.deck = CardDataBase.GetCelestial(true);
            setup.Shuffle(setup.deck);
            for (int i = 0; i < 10; i++)
            {
                setup.Instanciate(setup.deck[setup.deck.Count-1],setup.playerZone,prefabCard);
            }
        }
        deck = GameObject.Find("DeckEnemy");
        GameObject hand = GameObject.Find("Enemy Hand");
        if (deck != null)
        {
            Player1Deck setup = deck.GetComponent<Player1Deck>();
            setup.deck = CardDataBase.GetCelestial(false);//Cambiar a false cuando este listo el segundo Deck
            setup.Shuffle(setup.deck);
            for (int i = 0; i < 10; i++)
            {
                setup.Instanciate(setup.deck[setup.deck.Count - 1], setup.playerZone, prefabCard);
                hand.transform.GetChild(i).Rotate(0, 0, 180);
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
            Pwroponent.text = (System.Convert.ToInt32(Pwroponent.text) + value).ToString();
    }
    private void Rotate()
    {
        World.transform.Rotate(0,0,180);
        Pwrplayer.transform.Rotate(0, 0, 180);
        Pwroponent.transform.Rotate(0, 0, 180);
        Pass.transform.Rotate(0, 0, 180);
    }
    public void PassedTurn()
    {
        if (Turn1)
            PlayerSurr = true;
        else
            OponentSurr = true;
        if (PlayerSurr && OponentSurr)
            EndRound();
        else
        if (Turn1)
        {
            Turn1 = false;
        }
        else
        {
            Turn1 = true;
        }
        
        Debug.Log("Turnos Cambiados");
    }
    public void EndRound()
    {
        GameObject lifes;
        int diff= Convert.ToInt32(Pwrplayer.text) - Convert.ToInt32(Pwroponent.text);
        if (diff > 0)
        {
            lifes = GameObject.Find("LifesPlayer");
        }
        else
        {
            lifes= GameObject.Find("LifesEnemy");
        }
        if (lifes.transform.GetChild(0).gameObject.activeSelf)
        {
            lifes.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            EndGame();
            if (lifes.name.IndexOf("LifesPlayer") != -1)
                Debug.Log("Ganador Player");
            else
                Debug.Log("Ganador Enemy");
        }
        Eff.GetComponent<Efectos>().ToCementery();
    }
    public void EndGame()
    {

    }

}
