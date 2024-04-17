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
    public GameObject Eff;
    public GameObject World;
    public GameObject playerLifes;
    public GameObject oponentlifes;
    public TMP_Text Pwrplayer;
    public TMP_Text Pwroponent;
    public TextMeshProUGUI Message;
    public TextMeshProUGUI Teller;
    public TextMeshProUGUI EffTeller;
    public GameObject ButtonOK;
    public GameObject MessagePanel;
    public GameObject TellerPanel;
    public UnityEngine.UI.Button Pass;
    public GameObject prefabCard;
    public GameObject prefabLeader;
    private bool _Turn=true;
    public Player P1;
    public Player P2;
    public GameObject PlayerZone;
    public GameObject EnemyZone;
    public bool CardFilter = false;
    public bool Turn
    {
        get { return _Turn;}
        set 
        { 
            if(_Turn != value)
            {
                _Turn = value;
                Rotate();
            }
            if (Turn)
            {
                Send("Turno de " + P1.name, Message);
                MessagePanel.SetActive(true);
            }
            else
            {
                Send("Turno de " + P2.name, Message);
                MessagePanel.SetActive(true);
            }
            VisibilityGM();
            Textos();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SavedData data= null;
        if (GameObject.Find("SoundManager")!= null)
        {
            data = GameObject.Find("SoundManager").GetComponent<SavedData>();
        }
        if (data != null)
        {
            P1 = new Player(data.faction_1, data.name_1, true);
            P2 = new Player(data.faction_2, data.name_2,false);
        }
        else
        {
            P1 = new Player(2, "Jean",true);
            P2 = new Player(1, "Deiny",false);
        }
        SetupPLayers();
        
        Turn = true;
    }
    private void Update()
    {
        if (IsMessaging && Input.anyKey)
        {
            EndMessage(Message);
            MessagePanel.SetActive(false);
        }
        if ((Turn == true && P1.SetedUp == false) || (Turn == false && P2.SetedUp == false))
        {
            ButtonOK.SetActive(true);
            Teller.gameObject.SetActive(true);
            TellerPanel.SetActive(true);
        }
        else
        {
            ButtonOK.SetActive(false);
            Teller.gameObject.SetActive(false);
            TellerPanel.SetActive(false);
        }
    }
    private void Textos()
    {
        if (WhichPlayer(Turn).SetedUp != true&& Message)
        {
            Teller.gameObject.SetActive(true);
            Send("Puedes descartar hasta dos cartas de tu mano haciendo click sobre ellas en este momento, si estás conforme con tu mano puedes pulsar el botón OK", Teller);
        }
        else
        {
            Send("", Teller);
            Teller.gameObject.SetActive(false);
        }
    }

    #region SetupingGame
    public void SetupPLayers()
    {
        GameObject deck = GameObject.Find("Deck");
        if (deck != null )
        {
            PlayerDeck setup = deck.GetComponent<PlayerDeck>();
            setup.deck = CardDataBase.GetDeck(true, P1.faction);
            setup.Shuffle(setup.deck);
        }
        deck = GameObject.Find("DeckEnemy");
        GameObject hand = GameObject.Find("Enemy Hand");
        if (deck != null)
        {
            PlayerDeck setup = deck.GetComponent<PlayerDeck>();
            setup.deck = CardDataBase.GetDeck(false, P2.faction);
            setup.Shuffle(setup.deck);
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
   
    public void VisibilityGM()
    {
        if (Turn)
        {
            for(int i= 0; i< PlayerZone.transform.childCount; i++)
            {
                PlayerZone.transform.GetChild(i).transform.GetChild(3).gameObject.SetActive(false);
            }
            for (int i = 0; i < EnemyZone.transform.childCount; i++)
            {
                EnemyZone.transform.GetChild(i).transform.GetChild(3).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < PlayerZone.transform.childCount; i++)
            {
                PlayerZone.transform.GetChild(i).transform.GetChild(3).gameObject.SetActive(true);
            }
            for (int i = 0; i < EnemyZone.transform.childCount; i++)
            {
                EnemyZone.transform.GetChild(i).transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
    #endregion
    #region RoundLogic
    int indexP =0; int indexE=0;
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
        deck.InstanciateLastOnDeck(2, false);
        deck = GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
        deck.InstanciateLastOnDeck(2, false);
        VisibilityGM();
    }
    public void PassedTurn()
    {
        if (Turn)
            P1.Surrender = true;
        else
            P2.Surrender = true;
        if (P1.Surrender && P2.Surrender)
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
    public void EndGame(int indexE, int indexP)
    {
        SceneManager.LoadScene(0);   
    }
    #endregion
    #region Messaging
    bool IsMessaging = false;
    public void Send(string message, TextMeshProUGUI Mess)
    {
        if(Mess!=Teller)
        {
            indexE = 0;
        }
        Mess.gameObject.SetActive(true);
        IsMessaging = true;
        Mess.text = message;
        if(Mess== Message)
            Teller.gameObject.SetActive(false);
    }
    public void EndMessage(TextMeshProUGUI Mess) 
    {
        Mess.gameObject.SetActive(false);
        Mess.text = "";
        Teller.gameObject.SetActive(true);
    }
    public void OK()
    {
        WhichPlayer(Turn).SetedUp = true;
    }
    #endregion

    public Player WhichPlayer(bool b)
    {
        if (b == P1.P)
            return P1;
        return P2;
    }
    public void Delay(float seconds)
    {
        StartCoroutine(DelayInternal(seconds));
    }
    private IEnumerator DelayInternal(float s)
    {
        yield return new WaitForSeconds(s);
    }
}
public class Player: ScriptableObject
{
    public int faction;
    public string name;
    public int lifes;
    public bool Surrender;
    public bool P;
    public bool SetedUp;
    private int _cards;
    public int cardsExchanged 
    {
        get
        {
            return _cards;
        }
        set
        {
            _cards = value;
            if (_cards == 2)
            {
                SetedUp = true;
                
            }
        }
    }
    public Player(int faction, string name, bool b)
    {
        this.name = name;
        this.faction = faction;
        Surrender = false;
        this.P = b;
        SetedUp = false;
        cardsExchanged = 0;
    }
}

