using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext.Attributes
{
    public class StringAttribute : Attribute<string>
    {
        public StringAttribute() { }
        public StringAttribute(string name, string value)
            : base(name, value)
        {}
    }
}