using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Diagramus.Models.ElementContext
{
    public class Domain : Element
    {
        public ICollection<Element> Elements { get; set; }

        public Domain()
        {
            Elements = new List<Element>();
        }

        public Domain(string rn, string type, Domain domain)
            : base(rn, type, domain)
        {
            Elements = new List<Element>();
        }

        public override JObject ToJObject()
        {
            JObject o = base.ToJObject();
            o.Add("elements", Elements.ToJArray());
            return o;
        }
    }
}