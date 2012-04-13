using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Newtonsoft.Json.Linq;

namespace Diagramus.Models.ElementContext
{
    public class Association : Element
    {
        public ICollection<Role> Roles { get; set; }

        public Association() 
        {
            Roles = new HashSet<Role>();
        }

        public Association(string rn, string type, Domain domain)
            : base(rn, type, domain)
        {
            Roles = new HashSet<Role>();
        }

        public void AddEntity(string role, Element e)
        {
            if (!Roles.Any(r => r.Name == role))
            {
                Role r = new Role(role);
                r.Elements.Add(e);
                Roles.Add(r);
            }
            else
            {
                Roles.Single(r => r.Name == role).Elements.Add(e);
            }
        }

        public override JObject ToJObject()
        {
            JObject o = base.ToJObject();
            foreach (var role in Roles)
            {
                o.Add(role.Name, role.Elements.ToJArray());
            }
            return o;
        }
    }
}