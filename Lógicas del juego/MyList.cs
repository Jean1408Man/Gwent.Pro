using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógicas_del_juego
{
    public class MyList<Card>: List<Card>
    {
        public new void Add(Card item)
        {
            base.Add(item);
        }
        public new void Remove(Card item) 
        { 
            base.Remove(item);
        }
    }
}
