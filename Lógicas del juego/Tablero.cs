using LogicalSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógicas_del_juego
{
    public class Tablero
    {
        public Card[,] Map;
        public (int X, int Y) Dim = (6,6);
        public Tablero() 
        {
            Map = new Card[Dim.X, Dim.Y];
        }
    }
}
