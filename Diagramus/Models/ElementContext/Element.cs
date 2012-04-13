using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Diagramus.Models.ElementContext.Attributes;
using Newtonsoft.Json.Linq;

namespace Diagramus.Models.ElementContext
{
    public class Element : IJObjectConvertable
    {
        [Key]
        public string Dn { get; set; }
        public string Rn { get; set; }
        public string Type { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual ICollection<StringAttribute> StringAttributes { get; set; }
        public virtual ICollection<NumberAttribute> NumberAttributes { get; set; }

        public Element() 
        {
            StringAttributes = new HashSet<StringAttribute>();
            NumberAttributes = new HashSet<NumberAttribute>();
        }

        public Element(string rn, string type, Domain domain = null)
        {
            Rn = rn;
            Type = type;
            StringAttributes = new HashSet<StringAttribute>();
            NumberAttributes = new HashSet<NumberAttribute>();
            if (domain != null)
            {
                Domain = domain;
                domain.Elements.Add(this);
                Dn = String.Format("{0}/{1}", domain.Dn, Rn);
            }
            else
            {
                Dn = String.Format("{0}", Rn);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (!(obj is Element)) return false;
            return ((Element)obj).Dn.Equals(Dn);
        }

        public override int GetHashCode()
        {
            return Dn.GetHashCode();
        }

        public virtual JObject ToJObject() {
            JObject o = new JObject(
                new JProperty("dn", Dn),
                new JProperty("rn", Rn),
                new JProperty("type", Type)
            );
            if (StringAttributes.Count != 0) 
            {
                foreach (var item in StringAttributes)
	            {
		            o.Add(item.Name, item.Value);
	            }
            }
            if (NumberAttributes.Count != 0) 
            {
                foreach (var item in NumberAttributes)
	            {
		            o.Add(item.Name, item.Value);
	            }
            }
            return o;
        }
    }
}