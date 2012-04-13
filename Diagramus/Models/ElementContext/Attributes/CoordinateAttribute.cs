using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext.Attributes
{
    public class CoordinateAttribute : Attribute<Coordinate>
    {
        public CoordinateAttribute(string name, double x, double y)
            : base(name, new Coordinate(x, y))
        {}
    }
}