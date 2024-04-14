using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using LogicalSide;
using UnityEngine.UIElements;
using System;
using JetBrains.Annotations;
public class GameManager : MonoBehaviour
{
    public GameObject Visualizer;
    public GameObject Visualizer2;
    public GameObject Eff;
    public GameObject World;
    public GameObject playerLifes;
    public GameObject oponentlifes;
    public TMP_Text Pwrplayer;
    public TMP_Text Pwroponent;
    public UnityEngine.UI.Button Pass;
    public bool PlayerSurr=false;
    public bool OponentSurr= false;
    public GameObject prefabCard;
    public GameObject prefabLeader;
    private bool _Turn=true;
    public Player P1;
    public Player P2;
    public bool Turn
    {
        get { return _Turn; }
        set 
        { 
            if(_Turn != value)
            {
                _Turn = value;
                Rotate();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SavedData data = GameObject.Find("SoundManager").GetComponent<SavedData>();
        P1 = new Player(data.faction_1, data.name_1);
        P2 = new Player(data.faction_2, data.name_2);
        SetupPLayers();
        Turn = true;
    }

    
    public void SetupPLayers()
    {
        GameObject deck = GameObject.Find("Deck");
        if (deck != null )
        {
            PlayerDeck setup = deck.GetComponent<PlayerDeck>();
            if(P1.faction==1)
                setup.deck = CardDataBase.GetCelestial(true);
            else
                setup.deck = CardDataBase.GetCelestial(true);
            setup.Shuffle(setup.deck);
            setup.InstanciateLastOnDeck(10);
        }
        deck = GameObject.Find("DeckEnemy");
        GameObject hand = GameObject.Find("Enemy Hand");
        if (deck != null)
        {
            PlayerDeck setup = deck.GetComponent<PlayerDeck>();
            if (P1.faction == 1)
                setup.deck = CardDataBase.GetCelestial(false);
            else
                setup.deck = CardDataBase.GetCelestial(false);
            setup.Shuffle(setup.deck);
            setup.InstanciateLastOnDeck(10);
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
        if (Turn)
            PlayerSurr = true;
        else
            OponentSurr = true;
        if (PlayerSurr && OponentSurr)
            EndRound();
        else
        if (Turn)
        {
            Turn = false;
        }
        else
        {
            Turn = true;
        }
        
        Debug.Log("Turnos Cambiados");
    }
    int indexP=0; int indexE=0;
    public void EndRound()
    {
        int diff= Convert.ToInt32(Pwrplayer.text) - Convert.ToInt32(Pwroponent.text);
        if (diff <= 0)
        {
            playerLifes.transform.GetChild(indexP).gameObject.SetActive(false);
            indexP++;
        }
        if(diff>=0)
        {
            oponentlifes.transform.GetChild(indexE).gameObject.SetActive(false);
            indexE++;
        }
        if(indexE==2|| indexP==2)
            EndGame(indexE,indexP);
        Eff.GetComponent<Efectos>().ToCementery();

        PlayerDeck deck = GameObject.Find("Deck").GetComponent<PlayerDeck>();
        deck.InstanciateLastOnDeck(2);
        deck = GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
        deck.InstanciateLastOnDeck(2);
    }
    public void EndGame(int indexE, int indexP)
    {
        SceneManager.LoadScene(0);   
    }

}
public class Player: ScriptableObject
{
    public int faction;
    public string name;
    public int lifes;
    public bool Surrender;

    public Player(int faction, string name)
    {
        this.name = name;
        this.faction = faction;
        Surrender = false;
        lifes = 2;
    }
}
