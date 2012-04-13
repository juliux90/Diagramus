using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext
{
    //public class EntityList<T> : Relation where T : Entity
    //{
    //    public EntityList(string rn, Domain domain)
    //        : base(rn, domain)
    //    {
    //        Type = "EntityList";
    //    }

    //    public EntityList(string rn, Domain domain, IEnumerable<T> entitylist) : this(rn, domain)
    //    {
    //        Add(entitylist);
    //    }

    //    public void Add(IEnumerable<T> entitylist)
    //    {
    //        int i = 0;
    //        foreach (Entity e in entitylist)
    //        {
    //            Roles.Add(new IndexRole(i, e));
    //            ++i;
    //        }
    //    }

    //    public IEnumerable<T> ToList()
    //    {
    //        return Roles.OfType<IndexRole>().OrderBy(r => r.Index).Select(r => r.Entity).OfType<T>().ToList();
    //    }
    //}
}