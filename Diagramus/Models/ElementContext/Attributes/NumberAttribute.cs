using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext.Attributes
{
    public class NumberAttribute : Attribute<double>
    {
        public NumberAttribute() { }
        public NumberAttribute(string name, double value)
            : base(name, value)
        {}
    }
}