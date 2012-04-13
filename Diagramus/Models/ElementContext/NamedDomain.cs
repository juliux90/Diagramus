using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagramus.Models.ElementContext.Attributes;

namespace Diagramus.Models.ElementContext
{
    public class NamedDomain : Domain
    {
        public NamedDomain() { }
        public NamedDomain(string rn, string type, Domain domain, string name, string desc)
            : base(rn, type, domain)
        {
            Type = "NamedDomain";
            StringAttributes.Add(new StringAttribute("name", name));
            StringAttributes.Add(new StringAttribute("description", desc));
        }
    }
}