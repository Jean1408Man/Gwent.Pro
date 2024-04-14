using LogicalSide;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Efectos: MonoBehaviour 
{
    //todos los objetos a los que puede afectar un efecto
    #region
    public  GameObject P1S;
    public  GameObject P1R;
    public  GameObject P1M;
    public  GameObject P2S;
    public  GameObject P2R;
    public  GameObject P2M;
    public  GameObject P1AM;
    public  GameObject P1AR;
    public  GameObject P1AS;
    public  GameObject P2AM;
    public  GameObject P2AR;
    public  GameObject P2AS;
    public  GameObject C;
    #endregion
    public List<GameObject>[] Board;
    public Dictionary<(bool,string), GameObject> RangeMap;
    public Dictionary<string, Action<Card>> ListEffects;
    public Dictionary<(bool, string), GameObject> RaiseMap;
    private void Start()
    {
        RaiseMap = new Dictionary<(bool, string), GameObject> 
        {
            [(true,"S")] = P1AS,
            [(true, "R")] = P1AR,
            [(true, "M")] = P1AM,
            [(false,"S")] = P2AS,
            [(false,"R")] = P2AR,
            [(false,"M")] = P2AM,
        };
        RangeMap = new Dictionary<(bool,string), GameObject>()
        {
            [(true,"M")] = P1M,
            [(true,"R")] = P1R,
            [(true,"S")] = P1S,
            [(true,"AS")] = P1AS,
            [(true,"AR")] = P1AR,
            [(true,"AM")] = P1AM,
            [(false, "M")] = P2M,
            [(false, "R")] = P2R,
            [(false, "S")] = P2S,
            [(false, "AS")] = P2AS,
            [(false, "AR")] = P2AR,
            [(false, "AM")] = P2AM,
        };
        ListEffects = new Dictionary<string, Action<Card>>()
        {
            {"Weather", Weather },
            {"Raise", Raise },
            {"None", None },
            {"Decoy", Decoy },
            {"Planet", Planet },
            {"Most Pwr", MostPwr},
            {"Less Pwr", LessPwr},
            {"Colmena", Colmena},
            {"Zone Cleaner", ZoneCleaner},
            {"Steal", Stealer}
        };
    }
    public void None(Card card)
    {

    }
    public void Planet(Card card)
    {
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.AddScore(card.DownBoard, 20);
    }
    public void Weather(Card card)
    {//Efecto Clima Genérico
        GameObject C = RangeMap[(card.DownBoard, card.current_Rg)];
        C.GetComponent<DropProp>().DropStatus(-1,card);
        C = RangeMap[(!card.DownBoard, card.current_Rg)];
        C.GetComponent<DropProp>().DropStatus(-1, card);
    }
    public void Raise(Card card)
    {
        GameObject C = RangeMap[(card.DownBoard, card.current_Rg)];
        C.GetComponent<DropProp>().DropStatus(+1, card);
    }
    public void PlayCard(Card card)
    {
        string rg = card.current_Rg;
        int increase = 0;
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.AddScore(card.DownBoard, card.Pwr);
        GameObject C = RangeMap[(card.DownBoard, card.current_Rg)];
        increase= C.GetComponent<DropProp>().weather+ C.GetComponent<DropProp>().raised;
        card.Pwr = card.Pwr+increase;
        if (GM.Turn)
            GM.PlayerSurr = false;
        else
            GM.OponentSurr = false;
    }

    public void Decoy(Card card)
    {
        //    DecoyCard decoy = card as DecoyCard;
        //    if (decoy != null)
        //    {
        //        List<Card> C = decoy.Board.Map[decoy.currentRg.index];
        //        if (C != null)
        //        {
        //            UnityCard unity;
        //            foreach (Card cd in C)//Recorre las cartas d la fila que afecta
        //            {
        //                if (cd is UnityCard)
        //                {
        //                    unity = cd as UnityCard;
        //                    if (unity != null && unity == decoy.Exchange)
        //                    {
        //                        card.Owner.Hand.Remove(decoy);
        //                        card.Owner.Hand.Add(unity);
        //                        C.Remove(unity);
        //                        C.Add(decoy);
        //                    }
        //                }
        //            }
        //        }
        //    }
    }
    public void RestartCard(GameObject Card, GameObject Place, bool home)
    {
        Card card = Card.GetComponent<CardDisplay>().cardTemplate;
        Restart(card);
        if (home)
        {
            Card.GetComponent<CardDrag>().Played = false;
            GameObject Hand;
            if (card.DownBoard)
                Hand = GameObject.FindWithTag("P");
            else
                Hand = GameObject.FindWithTag("E");
            Card.transform.SetParent(Hand.transform, false);
        }
    }
    private void Restart(Card card)
    {//Jugando con el set de Card para que actualice automaticamente el score
        card.Pwr = 0;
        card.current_Rg = "";
        card.Pwr = card.OriginPwr;
    }
    public void ToCementery()
    {
        PlayerDeck DeckP= GameObject.Find("Deck").GetComponent<PlayerDeck>();
        PlayerDeck DeckE = GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
        PlayerDeck Current;
        GameObject card;
        foreach (GameObject C in RangeMap.Values)
        {
            if (C == P1M || C == P1R || C == P1S || C == P1AM || C == P1AR || C == P1AS)
                Current = DeckP;
            else
                Current = DeckE;
            
            for (int i = 0; i< C.transform.childCount; i++)
            {
                card = C.transform.GetChild(i).gameObject;
                CardDisplay disp = card.GetComponent<CardDisplay>();
                if (disp != null)
                {
                    Restart(disp.cardTemplate);
                    if (disp.cardTemplate.Removable)
                    {
                        Current.cement.Add(disp.cardTemplate);
                        Destroy(card);
                    }
                }
            }
        }
        for (int i = 0; i < C.transform.childCount; i++)
        {
            card = C.transform.GetChild(i).gameObject;
            CardDisplay disp = card.GetComponent<CardDisplay>();
            if (disp.cardTemplate.DownBoard==true)
                Current = DeckP;
            else
                Current = DeckE;
            if (disp != null)
            {
                Restart(disp.cardTemplate);
                if (disp.cardTemplate.Removable)
                {
                    Current.cement.Add(disp.cardTemplate);
                    Destroy(card);
                }
            }
        }
    }
    public void MostPwr(Card card)
    {
        GameObject Bigger = null;
        GameObject Var= null;
        Card disp = null;
        Card dispvar = null;
        System.Random random = new();
        foreach(GameObject Gamezone in RangeMap.Values)
        {
            
            for(int i = 0;i< Gamezone.transform.childCount;i++)
            {
                if (Bigger == null)
                {
                    Bigger = Gamezone.transform.GetChild(i).gameObject;
                    disp = Bigger.GetComponent<CardDisplay>().cardTemplate;
                }
                else
                {
                    Var= Gamezone.transform.GetChild(i).gameObject;
                    dispvar= Var.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar.type == "U"&& dispvar.Removable&& dispvar!=card)
                    {
                        if (dispvar.Pwr > disp.Pwr)
                        {
                            disp = dispvar;
                            Bigger = Var;
                        }
                        else if (dispvar.Pwr == disp.Pwr)
                        {
                            int var = random.Next(0, 1);
                            if(var == 0)
                            {
                                Bigger = Var;
                                disp= dispvar;
                            }
                        }
                    }
                }
            }
        }
        if(Bigger != null&& disp != null&& card!=disp)
        {
            PlayerDeck Current= Decking(disp.DownBoard);
            Restart(disp);
            Current.cement.Add(disp);
            Destroy(Bigger);
        }
    }
    public PlayerDeck Decking(bool DownBoard)
    {
        if(DownBoard)
            return GameObject.Find("Deck").GetComponent<PlayerDeck>();
        else
            return GameObject.Find("DeckEnemy").GetComponent<PlayerDeck>();
    }
    public void LessPwr(Card card)
    {
        GameObject Bigger = null;
        GameObject Var = null;
        Card disp = null;
        Card dispvar = null;
        System.Random random = new();
        foreach (GameObject Gamezone in RangeMap.Values)
        {

            for (int i = 0; i < Gamezone.transform.childCount; i++)
            {
                if (Bigger == null)
                {
                    Bigger = Gamezone.transform.GetChild(i).gameObject;
                    disp = Bigger.GetComponent<CardDisplay>().cardTemplate;
                }
                else
                {
                    Var = Gamezone.transform.GetChild(i).gameObject;
                    dispvar = Var.GetComponent<CardDisplay>().cardTemplate;
                    if (dispvar.type == "U" && dispvar.Removable && dispvar != card)
                    {
                        if (dispvar.Pwr < disp.Pwr)
                        {
                            disp = dispvar;
                            Bigger = Var;
                        }
                        else if (dispvar.Pwr == disp.Pwr)
                        {
                            int var = random.Next(0, 1);
                            if (var == 0)
                            {
                                Bigger = Var;
                                disp = dispvar;
                            }
                        }
                    }
                }
            }
        }
        if (Bigger != null && disp != null)
        {
            PlayerDeck Current = Decking(disp.DownBoard);
            Restart(disp);
            Current.cement.Add(disp);
            Destroy(Bigger);
        }
    }
    public void Stealer(Card card)
    {
        Decking(card).InstanciateLastOnDeck(1);
    }
    public void Colmena(Card card)
    {
        int increase=0;
        Card dispvar = null;
        System.Random random = new();
        foreach (GameObject Gamezone in RangeMap.Values)
        {
            for (int i = 0; i < Gamezone.transform.childCount; i++)
            {
                dispvar=Gamezone.transform.GetChild(i).gameObject.GetComponent<CardDisplay>().cardTemplate;
                if (dispvar != null&& dispvar.Name== card.Name&& dispvar!=card)
                {
                    increase++;
                }
            }
        }
        card.Pwr += increase;
    }
    public void ZoneCleaner(Card card)
    {//No depurado!!!!!
        GameObject Me = RangeMap[(card.DownBoard, card.current_Rg)];
        int childs = 0;
        GameObject Target = null;
        Card dispvar = null;

        System.Random random = new();
        foreach (GameObject Gamezone in RangeMap.Values)
        {
            if(Gamezone!=Me&& Gamezone.transform.childCount> childs)
            {
                childs= Gamezone.transform.childCount;
                Target = Gamezone;
            }
            
        }
        if (Target != null && childs>0)
        {
            for (int i = 0; i < Target.transform.childCount; i++)
            {
                Me = Target.transform.GetChild(i).gameObject;
                dispvar = Me.GetComponent<CardDisplay>().cardTemplate;
                if(dispvar.Removable)
                {
                    PlayerDeck Current = Decking(dispvar.DownBoard);
                    Restart(dispvar);
                    Current.cement.Add(dispvar);
                    Destroy(Me);
                }
            }

        }
    }
}
