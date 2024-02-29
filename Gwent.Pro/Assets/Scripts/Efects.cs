using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalSide
{
    public abstract class Effects
    {
        public abstract void Act(Card card);
    }
    public class HallDog: Effects 
    {
        public override void Act(Card card)
        {
            card.Pwr += 2; 
        }
    }
}
