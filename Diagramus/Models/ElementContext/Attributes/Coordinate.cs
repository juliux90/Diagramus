using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext.Attributes
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Coordinate(Coordinate c)
        {
            X = c.X;
            Y = c.Y;
        }
    }
}