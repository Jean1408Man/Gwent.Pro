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
using System.Diagnostics;
using System.Threading;
public class GameManager : MonoBehaviour
{
    public GameObject PanelWinner;
    public TextMeshProUGUI WinnerTxt;
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
    public MenuGM Sounds;
    public Player P1;
    public Player P2;
    public GameObject PlayerZone;
    public GameObject EnemyZone;
    public bool CardFilter = false;


    private Queue<string> SMS;

    public bool Turn
    {
        get { return _Turn;}
        set 
        { 
            if(_Turn != value)
            {
                GameObject.Find("Effects").GetComponent<Efectos>().Turn= value;
                _Turn = value;
                Rotate();
            }
            if (Turn)
            {
                P1.SetedUp = P1.SetedUp;
                SendPrincipal("Turno de " + P1.name);
            }
            else
            {
                P2.SetedUp = P2.SetedUp;
                SendPrincipal("Turno de " + P2.name);
            }
            VisibilityGM();
            Textos();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SMS = new();
        SavedData data= null;
        if (GameObject.Find("SoundManager")!= null)
        {
            data = GameObject.Find("SoundManager").GetComponent<SavedData>();
        }
        if (data != null && !data.debug)
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
        Sounds = GameObject.Find("Menus").GetComponent<MenuGM>();
        Turn = true;
    }
    private void Update()
    {
        if (SMS != null)
        {
            if (SMS.Count > 0)
            {
                Send(SMS.Peek(), Message);
            }
            if (Input.anyKey && SMS.Count != 0)
            {
                GetPrincipal();
                Delay(1);
            }
        }
        else
            SMS = new();
        
    }
    private void Textos()
    {
        if (WhichPlayer(Turn).SetedUp != true)
        {
            Teller.gameObject.SetActive(true);
            Send("Puedes descartar hasta dos cartas de tu mano haciendo click sobre ellas en este momento, si est�s conforme con tu mano puedes pulsar el bot�n OK", Teller);
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
            setup.deck = CardDataBase.GetDeck(P1);
            setup.Shuffle(setup.deck);
        }
        deck = GameObject.Find("DeckEnemy");
        GameObject hand = GameObject.Find("Enemy Hand");
        if (deck != null)
        {
            PlayerDeck setup = deck.GetComponent<PlayerDeck>();
            setup.deck = CardDataBase.GetDeck(P2);
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
                PlayerZone.transform.GetChild(i).transform.GetChild(7).gameObject.SetActive(false);
            }
            for (int i = 0; i < EnemyZone.transform.childCount; i++)
            {
                EnemyZone.transform.GetChild(i).transform.GetChild(7).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < PlayerZone.transform.childCount; i++)
            {
                PlayerZone.transform.GetChild(i).transform.GetChild(7).gameObject.SetActive(true);
            }
            for (int i = 0; i < EnemyZone.transform.childCount; i++)
            {
                EnemyZone.transform.GetChild(i).transform.GetChild(7).gameObject.SetActive(false);
            }
        }
    }
    #endregion
    #region RoundLogic
    int indexP =0; int indexE=0;
    public void EndRound()
    {
        #region AlwaysWin
        int diff = Convert.ToInt32(Pwrplayer.text) - Convert.ToInt32(Pwroponent.text);
        if (diff > 0)
        {
            //Gana el P1
            oponentlifes.transform.GetChild(indexE).gameObject.SetActive(false);
            indexE++;
            SendPrincipal((P1.name + " Gan� la ronda"));
            Turn = true;
        }
        else if(diff<0)
        {
            playerLifes.transform.GetChild(indexP).gameObject.SetActive(false);
            indexP++;
            SendPrincipal(P2.name + " Gan� la ronda");
            Turn =false;
        }
        else
        {
            bool alwayswin=false;
            string result = "";
            bool turno=false;
            if (P1.AlwaysAWinner == true)
            {
                oponentlifes.transform.GetChild(indexE).gameObject.SetActive(false);
                indexE++;
                result = ((P1.name + " Gan� la ronda aplicando el efecto de su l�der"));
                turno = true;
            }
            else
            {
                alwayswin= !alwayswin;
            }
            if (P2.AlwaysAWinner == true)
            {
                playerLifes.transform.GetChild(indexP).gameObject.SetActive(false);
                indexP++;
                result= ((P2.name + " Gan� la ronda aplicando el efecto de su l�der"));
                turno = false;
            }
            else
            {
                alwayswin = !alwayswin;
            }
            if (!alwayswin)
            {
                if (!P1.AlwaysAWinner)
                {
                    playerLifes.transform.GetChild(indexP).gameObject.SetActive(false);
                    indexP++;
                    oponentlifes.transform.GetChild(indexE).gameObject.SetActive(false);
                    indexE++;
                    turno = true;
                }
                SendPrincipal(("Ronda Empatada"));
            }
            else
            { 
                SendPrincipal(result); 
            }
            Turn = turno;
        }
        #endregion
        if (indexE == indexP && indexP == 2)
            EndGame("Ambos");
        else if (indexP == 2)
            EndGame(P2.name);
        else if (indexE == 2)
            EndGame(P1.name); 
        #region Not Removable
        string res = ""; bool b;
        if (P1.RandomizedNotRem)
        {
            Efectos ef= Eff.GetComponent<Efectos>();
            b= ef.RandomizedRem(P1);
            if(b)
            res=P1.name + " ha mantenido una de sus cartas en el campo aleatoriamente debido al efecto de su lider";
        }
        if (P2.RandomizedNotRem)
        {
            Efectos ef = Eff.GetComponent<Efectos>();
            b=ef.RandomizedRem(P2);
            if(b)
            res=(P2.name + " ha mantenido una de sus cartas en el campo aleatoriamente debido al efecto de su lider");
        }
        if(P2.RandomizedNotRem&& P1.RandomizedNotRem)
            SendPrincipal("Ambos jugadores han mantenido una de sus cartas en el campo aleatoriamente debido al efecto de sus l�deres");
        else
            if(res!="")
                SendPrincipal(res);
        Eff.GetComponent<Efectos>().ToCementery();
        #endregion
        #region Stealer
        string r = "";
        PlayerDeck deck = GameObject.Find("Deck").GetComponent<PlayerDeck>();
        if (P1.Stealer)
        {
            deck.InstanciateLastOnDeck(3, false);
            r = P1.name + " ha robado una carta de m�s gracias al efecto de su lider";
        }
        else
        {
            deck.InstanciateLastOnDeck(2, false);
        }
        deck = GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
        if (P2.Stealer)
        { 
            deck.InstanciateLastOnDeck(3, false);
            r = P2.name + " ha robado una carta de m�s gracias al efecto de su lider";
        }
        else
            deck.InstanciateLastOnDeck(2, false);
        if (P1.Stealer && P2.Stealer)
            r = "Ambos jugadores han robado una carta de m�s gracias al efecto de su lider";
        if(r!= "")
        {
            SendPrincipal(r);
        }
        #endregion
        VisibilityGM();
        Send("", EffTeller);
        P1.Surrender = false;
        P2.Surrender = false;
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
        {
            if (Turn)
            {
                Turn = false;
            }
            else
            {
                Turn = true;
            }
            Send("Tu oponente pas� turno", EffTeller);
        }
        
    }
    public void EndGame(string winner)
    {
        if (winner == "Ambos")
            WinnerTxt.text= "El juego acaba en empate";
        else
            WinnerTxt.text = winner+ " gan� la partida";
        PanelWinner.SetActive(true);   
    }
    #endregion
    #region Messaging
    public void Send(string message, TextMeshProUGUI Mess)
    {
        Mess.gameObject.SetActive(true);
        Mess.text = message;
        
    }
    public void EndMessage(TextMeshProUGUI Mess) 
    {
        Mess.gameObject.SetActive(false);
        Mess.text = "";
        Teller.gameObject.SetActive(true);
    }
    public void SendPrincipal(string s)
    {
        SMS.Enqueue(s);
        Message.gameObject.SetActive(true);
        MessagePanel.SetActive(true);
    }
    public string GetPrincipal()
    {
        if (SMS.Count == 1)
        {
            MessagePanel.gameObject.SetActive(false);
        }
        return SMS.Dequeue();
    }
    public void OK()
    {
        WhichPlayer(Turn).SetedUp = true;
    }
    #endregion

    public Player WhichPlayer(bool b)
    {
        if(P1==null)
        {
            UnityEngine.Debug.Log("Player nulo");
            P1= new Player(10, "jua", true);
        }
        if (b == P1.Turn)
            return P1;
        return P2;
    }
    public void Delay(float seconds)
    {
        Thread.Sleep(Convert.ToInt32(seconds*1000));
    }
}
public class Player: IPlayer
{
    #region UsualProps
    public int faction;
    public new string name;
    public int lifes;
    public bool Surrender;
    public bool Turn{get; set;}
    private bool _seted;
    public bool SetedUp
    {
        get
        {
            return _seted;
        }
        set
        {
            _seted= value;GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            if(!_seted && GM.Turn== Turn)
            {
                GM.ButtonOK.SetActive(true);
                GM.Teller.gameObject.SetActive(true);
                GM.TellerPanel.SetActive(true);
            }
            else
            {
                GM.ButtonOK.SetActive(false);
                GM.Teller.gameObject.SetActive(false);
                GM.TellerPanel.SetActive(false);
            }
        }
    }
    //    if ((Turn == true && P1.SetedUp == false) || (Turn == false && P2.SetedUp == false))
    //        {
    //            ButtonOK.SetActive(true);
    //            Teller.gameObject.SetActive(true);
    //            TellerPanel.SetActive(true);
    //        }
    //        else
    //            GM.ButtonOK.SetActive(false);
    //            GM.Teller.gameObject.SetActive(false);
    //            GM.TellerPanel.SetActive(false);
//{
//    
//}
    private int _cards;
    #endregion

    #region EffectProps
    public bool Stealer;
    public bool AlwaysAWinner;
    public bool RandomizedNotRem;
    #endregion
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
        this.Turn = b;
        SetedUp = false;
        cardsExchanged = 0;
    }
}

