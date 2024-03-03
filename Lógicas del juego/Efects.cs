using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalSide
{
    public abstract class Effects
    {
        public Card AssociatedCard { get; set; }
        public abstract void Act();
    }
    public class HallDog: Effects 
    {
        public UnityCard AssociatedCard { get; set; }
        public override void Act()
        {
            AssociatedCard.Pwr += 2;
        }
    }
    public class Rain : Effects
    {
        public WeatherCard AssociatedCard { get; set; }
        public override void Act()
        {
            List<UnityCard> GameZone = AssociatedCard.Board.Map[GameManager.BoardRange(AssociatedCard.Owner, AssociatedCard.Atk_Rg)];
                if (GameZone != null)
                {
                    foreach (UnityCard unity in AssociatedCard.Board.Map[GameManager.BoardRange(AssociatedCard.Owner, AssociatedCard.Atk_Rg)])//Recorre las cartas d la fila que afecta
                    {
                        unity.Pwr -= 1;
                    }
                }
        }
    }
}
