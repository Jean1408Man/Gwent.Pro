using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalSide
{
    public class Effects
    {
        public static Dictionary<string, Action<Card>> Efectos = new Dictionary<string, Action<Card>>
        {
            {"HallDog", HallDog },
            {"Smug", Smug },
            {"Raise", Raise },
            {"Decoy", Decoy },
            {"Most Pwr",MostPwr},
            {"Less Pwr Rival", LessPwrRval}

        };
        public static void HallDog(Card card)
        {//A toda carta del campo contrario que sea "kid" se le disminuye su poder en 1 
            UnityCard unityCard = card as UnityCard;
            if (unityCard != null)
            {
                List<Card> GameZone = unityCard.Board.Map[GameManager.BoardRange(!unityCard.Owner.DownBoard, unityCard.currentRg.value)];
                if (GameZone != null)
                {
                    foreach (Card cd in GameZone)//Recorre las cartas d la fila que afecta
                    {
                        if (cd is UnityCard)
                        {
                            unityCard = cd as UnityCard;
                            if (unityCard != null)
                                if (unityCard.Type != "Golden")
                                    unityCard.Pwr -= 1;
                        }
                    }
                }

            }
        }
        public static void Smug(Card card)
        {//Smug se comporta como efecto Clima Genérico, puede tomar cualquier cualquier rango y actuar sobre él(incluso puede actuar sobre más de 1) 
            WeatherCard weatherCard = card as WeatherCard;
            UnityCard unity;
            if (weatherCard!= null)
            {
                for (int i = 0; i < weatherCard.Atk_Rg.Length; i++)
                {

                    List<Card> GameZone = weatherCard.Board.Map[GameManager.BoardRange(weatherCard.Owner.DownBoard, weatherCard.Atk_Rg[i])];
                    if (GameZone != null)
                    {
                        foreach (Card cd in GameZone)//Recorre las cartas d la fila que afecta
                        {
                            if (cd is UnityCard)
                            {
                                unity = cd as UnityCard;
                                if (unity != null)
                                    if (unity.Type != "Golden")
                                        unity.Pwr -= 1;
                            }
                        }
                    }
                    GameZone = weatherCard.Board.Map[GameManager.BoardRange(!weatherCard.Owner.DownBoard, weatherCard.Atk_Rg[i])];
                    if (GameZone != null)
                    {
                        foreach (Card cd in GameZone)//Recorre las cartas d la fila que afecta
                        {
                            if (cd is UnityCard)
                            {
                                unity = cd as UnityCard;
                                if (unity != null)
                                    if (unity.Type != "Golden")
                                        unity.Pwr -= 1;
                            }
                        }
                    }
                }
            }
        }
        public static void Raise(Card card)
        {
            RaiseCard raise = card as RaiseCard;
            if (raise != null)
            {
                List<Card> GameZone = raise.Board.Map[raise.currentRg.index];
                if (GameZone != null)
                {
                    UnityCard unity;
                    foreach (Card cd in GameZone)//Recorre las cartas d la fila que afecta
                    {
                        if (cd is UnityCard)
                        {
                            unity = cd as UnityCard;
                            if (unity != null)
                                if (unity.Type != "Golden")
                                    unity.Pwr += 1;
                        }
                    }
                }
            }
        }
        public static void Decoy(Card card)
        {
            DecoyCard decoy = card as DecoyCard;
            if(decoy != null)
            {
                List<Card> GameZone = decoy.Board.Map[decoy.currentRg.index];
                if(GameZone != null)
                {
                    UnityCard unity;
                    foreach (Card cd in GameZone)//Recorre las cartas d la fila que afecta
                    {
                        if (cd is UnityCard)
                        {
                            unity = cd as UnityCard;
                            if (unity != null&& unity == decoy.Exchange)
                            {
                                card.Owner.Hand.Remove(decoy);
                                card.Owner.Hand.Add(unity);
                                GameZone.Remove(unity);
                                GameZone.Add(decoy);
                            }
                        }
                    }
                }
            }
        }
        public static void MostPwr(Card card)
        {
            Card Temp= null;
            int? BoardPos = null;
            Random random = new Random();
            for(int i = 0;i<6; i++)
            {
                List<Card> Gamezone = card.Board.Map[i];
                if(Gamezone != null)
                {
                    for(int j = 0; j < Gamezone.Count; j++)
                    {
                        if (Gamezone[j]!= null)
                        {
                            if (Temp == null) {
                                Temp = Gamezone[j];
                                BoardPos= i;
                            }
                            else
                            {
                                if (Gamezone[j].Pwr > Temp.Pwr)
                                {
                                    Temp= Gamezone[j];
                                    BoardPos= i;
                                }
                                else if (Gamezone[j].Pwr== Temp.Pwr)
                                {
                                    int al= random.Next(2);
                                    if(al==0)
                                    {
                                        Temp = Gamezone[j];
                                        BoardPos = i;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (BoardPos != null)
            { 
                card.Board.Map[Convert.ToInt32(BoardPos)].Remove(Temp);
                Temp.Owner.Cementery.Add(Temp);
            }
        }
        public static void LessPwrRval(Card card)
        {
            Card Temp = null;
            int? BoardPos= null;
            Random random = new Random();
            int k = 0;
            if (card.Owner.DownBoard)
            {
                k = 3;
            }
            for(int i = k; i < k+3; i++)
            {
                List<Card> Gamezone = card.Board.Map[i];
                if (Gamezone != null)
                {
                    for (int j = 0; j < Gamezone.Count; j++)
                    {
                        if (Gamezone[j] != null)
                        {
                            if (Temp == null)
                            {
                                Temp = Gamezone[j];
                                BoardPos = i;
                            }
                            else
                            {
                                if (Gamezone[j].Pwr < Temp.Pwr)
                                {
                                    Temp = Gamezone[j];
                                    BoardPos = i;
                                }
                                else if (Gamezone[j].Pwr == Temp.Pwr)
                                {
                                    int al = random.Next(2);
                                    if (al == 0)
                                    {
                                        Temp = Gamezone[j];
                                        BoardPos = i;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (BoardPos != null)
            {
                card.Board.Map[Convert.ToInt32(BoardPos)].Remove(Temp);
                Temp.Owner.Cementery.Add(Temp);
            }
        }
        public static void Steal(Card card)
        {
            card.Owner.Steal(1);
        } 

    }
}
