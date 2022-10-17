using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    public class Map
    {
        public string Name { get; set; }
        public int RowCapacity { get; set; }
        public int ColumnCapacity { get; set; }
        public IEnumerable<Tile> Tiles { get; set; }

        public Map(string name, int rowCapacity, int columnCapacity)
        {
            Name = name;
            RowCapacity = rowCapacity;
            ColumnCapacity = columnCapacity;
            Tiles = new List<Tile>();
        }

        public Map(string name, int rowCapacity, int columnCapacity, IEnumerable<Tile> tiles)
        {
            Name = name;
            RowCapacity = rowCapacity;
            ColumnCapacity = columnCapacity;
            Tiles = tiles;
        }
    }
}
