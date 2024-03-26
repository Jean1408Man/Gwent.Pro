using LogicalSide;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            {"Planet", Planet }

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

        GameObject GameZone = RangeMap[(card.DownBoard, card.Atk_Rg)];
        if (GameZone != null)
        {
            foreach (Transform cardTransform in GameZone.transform)
            {
                CardDisplay disp = cardTransform.GetComponent<CardDisplay>();
                if (disp != null && disp.cardTemplate.unit == TypeUnit.Silver)
                {
                    disp.cardTemplate.Pwr -= 1;
                }
            }
        }
        GameZone = RangeMap[(!card.DownBoard, card.Atk_Rg)];
        if(GameZone != null) 
        { 
            foreach (Transform cardTransform in GameZone.transform)
            {
                CardDisplay disp = cardTransform.GetComponent<CardDisplay>();
                if (disp != null && disp.cardTemplate.unit == TypeUnit.Silver)
                {
                    disp.cardTemplate.Pwr -= 1;
                }
            }
        }
    }
    public void Raise(Card card)
    {
        GameObject GameZone = RangeMap[(card.DownBoard, card.Atk_Rg)];
        if (GameZone != null)
        {
            foreach (Transform cardTransform in GameZone.transform)
            {
                CardDisplay disp = cardTransform.GetComponent<CardDisplay>();
                if (disp != null && disp.cardTemplate.unit == TypeUnit.Silver)
                {
                    disp.cardTemplate.Pwr += 1;
                }
            }
        }
    }
    public void PlayCrad(Card card)
    {
        string rg = card.current_Rg;
        int increase = 0;
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.AddScore(card.DownBoard, card.Pwr);
        if( card.unit == TypeUnit.Silver)
        foreach(Transform game in C.transform)
        {
            CardDisplay disp = game.GetComponent<CardDisplay>();
            if (disp != null && disp.cardTemplate.Atk_Rg== rg)
            {
                    increase--;
            }
        }
        foreach(Transform game in RaiseMap[(card.DownBoard, rg)].transform)
        {
            increase++;
        }
        card.Pwr = card.Pwr+increase;
    }

    public void Decoy(Card card)
    {
        //    DecoyCard decoy = card as DecoyCard;
        //    if (decoy != null)
        //    {
        //        List<Card> GameZone = decoy.Board.Map[decoy.currentRg.index];
        //        if (GameZone != null)
        //        {
        //            UnityCard unity;
        //            foreach (Card cd in GameZone)//Recorre las cartas d la fila que afecta
        //            {
        //                if (cd is UnityCard)
        //                {
        //                    unity = cd as UnityCard;
        //                    if (unity != null && unity == decoy.Exchange)
        //                    {
        //                        card.Owner.Hand.Remove(decoy);
        //                        card.Owner.Hand.Add(unity);
        //                        GameZone.Remove(unity);
        //                        GameZone.Add(decoy);
        //                    }
        //                }
        //            }
        //        }
        //    }
    }
    public void MostPwr(Card card)
    {
        //Card Temp = null;
        //int? BoardPos = null;
        //Random random = new Random();
        //for (int i = 0; i < 6; i++)
        //{
        //    List<Card> Gamezone = card.Board.Map[i];
        //    if (Gamezone != null)
        //    {
        //        for (int j = 0; j < Gamezone.Count; j++)
        //        {
        //            if (Gamezone[j] != null)
        //            {
        //                if (Temp == null)
        //                {
        //                    Temp = Gamezone[j];
        //                    BoardPos = i;
        //                }
        //                else
        //                {
        //                    if (Gamezone[j].Pwr > Temp.Pwr)
        //                    {
        //                        Temp = Gamezone[j];
        //                        BoardPos = i;
        //                    }
        //                    else if (Gamezone[j].Pwr == Temp.Pwr)
        //                    {
        //                        int al = random.Next(2);
        //                        if (al == 0)
        //                        {
        //                            Temp = Gamezone[j];
        //                            BoardPos = i;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        //if (BoardPos != null)
        //{
        //    card.Board.Map[Convert.ToInt32(BoardPos)].Remove(Temp);
        //    Temp.Owner.Cementery.Add(Temp);
        //}
    }
    //public static void LessPwrRval(Card card)
    //{
    //    Card Temp = null;
    //    int? BoardPos = null;
    //    Random random = new Random();
    //    int k = 0;
    //    if (card.Owner.DownBoard)
    //    {
    //        k = 3;
    //    }
    //    for (int i = k; i < k + 3; i++)
    //    {
    //        List<Card> Gamezone = card.Board.Map[i];
    //        if (Gamezone != null)
    //        {
    //            for (int j = 0; j < Gamezone.Count; j++)
    //            {
    //                if (Gamezone[j] != null)
    //                {
    //                    if (Temp == null)
    //                    {
    //                        Temp = Gamezone[j];
    //                        BoardPos = i;
    //                    }
    //                    else
    //                    {
    //                        if (Gamezone[j].Pwr < Temp.Pwr)
    //                        {
    //                            Temp = Gamezone[j];
    //                            BoardPos = i;
    //                        }
    //                        else if (Gamezone[j].Pwr == Temp.Pwr)
    //                        {
    //                            int al = random.Next(2);
    //                            if (al == 0)
    //                            {
    //                                Temp = Gamezone[j];
    //                                BoardPos = i;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    if (BoardPos != null)
    //    {
    //        card.Board.Map[Convert.ToInt32(BoardPos)].Remove(Temp);
    //        Temp.Owner.Cementery.Add(Temp);
    //    }
    //}
    //public static void Steal(Card card)
    //{
    //    card.Owner.Steal(1);
    //}
    //public static void SeaMen(Card card)
    //{//Este efecto incrementa el poder de la carta lanzada en 1 x cada carta igual a ella en el campo en ese momento
    //    int counter = 0;
    //    for (int i = 0; i < 6; i++)
    //    {
    //        List<Card> Gamezone = card.Board.Map[i];
    //        if (Gamezone != null)
    //        {
    //            for (int j = 0; j < Gamezone.Count; j++)
    //            {
    //                if (Gamezone[j] != null)
    //                {
    //                    if (card.CardName == Gamezone[j].CardName)
    //                        counter++;
    //                }
    //            }
    //        }
    //    }
    //    card.Pwr += counter;
    //}
}
