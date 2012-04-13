using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext.Attributes
{
    public class Attribute<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual T Value { get; set; }

        public Attribute()
        {
        }

        public Attribute(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (!(obj is Attribute<T>)) return false;
            if (Id != 0)
            {
                return ((Attribute<T>)obj).Id.Equals(Id);
            }
            else
            {
                return ((Attribute<T>)obj).Name == Name;
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