using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace LogicalSide
{
    public class MainObjects
    {
        List<Card> AllCards= new List<Card>();
        MainObjects()
        {
        }
        public void InitializeProperties()
        {
            AllCards.Add(new Card("The Hall Guardian", "Sweet Kids", "You'll never pass if you don't have a permission",5));
        }
        public List<Card> Generate()
        {

        }
    }
}
