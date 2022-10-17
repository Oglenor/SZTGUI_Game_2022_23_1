using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    public class Tile : StaticGameItem
    {
        public bool IsSolid { get; set; }

        public Tile(double x, double y, bool isSolid) : base(x, y)
        {
            IsSolid = isSolid;
        }

        public Tile(double x, double y, int z, bool isSolid) : base(x, y, z)
        {
            IsSolid = isSolid;
        }

        public Tile(double x, double y, int z, Orientations orientation, bool isSolid) : base(x, y, z, orientation) 
        { 
            IsSolid = isSolid; 
        }

        public Tile(double x, double y, int z, Orientations orientation, bool isAnimated, bool isSolid) : base(x, y, z, orientation, isAnimated)
        {
            IsSolid=isSolid;
        }
    }
}
