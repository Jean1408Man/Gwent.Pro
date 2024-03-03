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
            {"Smug", Smug }
        };
        public static void HallDog(Card card)
        {
            UnityCard unityCard = card as UnityCard;
            if (unityCard != null)
            {
                unityCard.Pwr += 2;
            }
        }
        public static void Smug(Card card)
        {
            WeatherCard weatherCard = card as WeatherCard;
            if (weatherCard!= null)
            {
                List<UnityCard> GameZone = weatherCard.Board.Map[GameManager.BoardRange(weatherCard.Owner, weatherCard.Atk_Rg)];
                if (GameZone != null)
                {
                    foreach (UnityCard unity in weatherCard.Board.Map[GameManager.BoardRange(weatherCard.Owner, weatherCard.Atk_Rg)])//Recorre las cartas d la fila que afecta
                    {
                        unity.Pwr -= 1;
                    }
                }
            }
            
        }
    }
}
