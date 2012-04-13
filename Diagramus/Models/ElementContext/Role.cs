using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Element> Elements { get; set; }

        public Role() {
            Elements = new HashSet<Element>();
        }

        public Role(string rolename)
        {
            Name = rolename;
            Elements = new HashSet<Element>();
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (!(obj is Role)) return false;
            if (Id != 0)
            {
                return ((Role)obj).Id.Equals(Id);
            }
            else
            {
                return ((Role)obj).Name == Name && ((Role)obj).Elements == Elements;
            }
        }

        public override int GetHashCode()
        {
            //return base.GetHashCode();
            int hash = Name.GetHashCode();
            hash = 29 * hash + Id;
            return hash;
        }
    }
}