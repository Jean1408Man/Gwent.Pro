using LogicalSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalSide
{
    public class Tablero
    {
        public List<UnityCard>[] Map;
        public List<WeatherCard> Weather;
        public (int X, int Y) Dim = (6,6);
        public Tablero() 
        {
            Map = new List<UnityCard>[Dim.Y];
            Weather= new List<WeatherCard>();
        }
    }
}
