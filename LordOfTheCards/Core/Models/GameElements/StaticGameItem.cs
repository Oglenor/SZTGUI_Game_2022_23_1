using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    public abstract class StaticGameItem
    {
        private static int idGen = 0;
        public int Id { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }
        public Orientations Orientation { get; set; }
        public bool IsAnimated { get; set; }

        public StaticGameItem(double x, double y)
        {
            Id = ++idGen;
            X = x;
            Y = y;
            Z = 0;            
            Orientation = Orientations.Up;
            IsAnimated = false;
        }

        public StaticGameItem(double x, double y, int z)
        {
            Id = ++idGen;
            X = x;
            Y = y;
            Z = z;            
            Orientation = Orientations.Up;
            IsAnimated = false;
        }

        public StaticGameItem(double x, double y, int z, Orientations orientation)
        {
            Id = ++idGen;
            X = x;
            Y = y;
            Z = z;            
            Orientation = orientation;
            IsAnimated = false;
        }

        public StaticGameItem(double x, double y, int z, Orientations orientation, bool isAnimated)
        {
            Id = ++idGen;
            X = x;
            Y = y;
            Z = z;
            Orientation = orientation;
            IsAnimated = isAnimated;
        }
    }
}