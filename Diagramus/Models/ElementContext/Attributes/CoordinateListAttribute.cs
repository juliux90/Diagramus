using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext.Attributes
{
    public class CoordinateListAttribute : Attribute<ICollection<CoordinateListElement>>
    {
        public CoordinateListAttribute(string name)
        {
            Name = name;
        }

        public CoordinateListAttribute(string name, IEnumerable<Coordinate> coordinates)
            : this(name)
        {
            int i = 0;
            foreach (Coordinate c in coordinates)
            {
                Value.Add(new CoordinateListElement(i, c));
                ++i;
            }
        }

        public IEnumerable<Coordinate> ToList()
        {
            return Value.OrderBy(r => r.Index).Select(p => new Coordinate(p)).ToList();
        }
    }
}