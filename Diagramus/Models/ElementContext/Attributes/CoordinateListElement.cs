using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext.Attributes
{
    public class CoordinateListElement : Coordinate
    {
        public int Id { get; set; }
        public int Index { get; set; }

        public CoordinateListElement(int index, double x, double y)
            : base(x, y)
        {
            Index = index;
        }

        public CoordinateListElement(int index, Coordinate c)
            : base(c)
        {
            Index = index;
        }
    }
}