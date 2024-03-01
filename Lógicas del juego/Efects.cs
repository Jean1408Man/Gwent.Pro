using Lógicas_del_juego;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalSide
{
    public abstract class Effects
    {
        public abstract Card AssociatedCard { get; set; }
        public abstract Tablero AsociatedBoard
        public abstract void Act();
    }
    public class HallDog: Effects 
    {
        public override Card AssociatedCard { get; set; }
        public override void Act()
        {
            AssociatedCard.Pwr += 2;
        }
    }
}
