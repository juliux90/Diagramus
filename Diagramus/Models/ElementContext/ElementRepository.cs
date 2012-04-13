using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Diagramus.Models.ElementContext
{
    //class ElementRepository : IElementRepository
    //{
    //    /*IQueryable<Element> GetAll()
    //    {

    //    }*/


    //    private void PullDomainChildrenToContext(Domain root, ElementContext ec) 
    //    {

    //    }

    //    private void PullAssociatedEntitiesToContext(Association ass, ElementContext ec)
    //    {
    //        //ass.Roles.AsQueryable().Include(a => a.Roles.Select(r => r.Elements)).Load();




    //        // Asszociációk navigation propertyjeinek behúzása az ElementContextbe

    //        //var elementcolls = ass.Include(a => a.Roles).Select(a => a.Roles.Select(r => r.Elements));


    //        //foreach (var elementcoll in elementcolls)
    //        //{
    //        //    elementcoll.
    //        //}


    //        //foreach (var domain in domains)
    //        //{
    //        //    ec.Elements.OfType<Association>()
    //        //        .Where(a => a.Domain.Dn.Equals(domain.Dn))
    //        //        .Include(a => a.Roles)
    //        //        .Include(a => a.Roles.Select(r => r.Elements))
    //        //        .Load();
    //        //}
    //    }

    //    public Element GetElement(string dn)
    //    {
    //        ElementContext ec = new ElementContext();
    //        // Az ElementContext legyen állapotmentes
    //        ec.Configuration.AutoDetectChangesEnabled = false;
    //        // Ne legyen lusta betöltődés, az adatokat az object contexten kívül fogjuk úgyis használni
    //        ec.Configuration.LazyLoadingEnabled = false;

    //        Element element = ec.Elements.Include(e => e.Domain).Where(e => e.Dn.Equals(dn)).Single();
    //        if (element is Domain)
    //        {

    //        }
    //        else if (element is Association)
    //        {

    //        }
    //        else
    //        {
    //            return element;
    //        }

    //        ec.Dispose();





    //        //using (ElementContext ec = new ElementContext())
    //        //{


    //        //    // Domainek lekérdezése
    //        //    var domains = ec.Elements
    //        //        .Include(k => k.Domain)
    //        //        .OfType<Domain>()
    //        //        .Include(k => k.Elements);

    //        //    // Asszociációk navigation propertyjeinek behúzása az ElementContextbe
    //        //    foreach (var domain in domains)
    //        //    {
    //        //        ec.Elements.OfType<Association>()
    //        //            .Where(a => a.Domain.Dn.Equals(domain.Dn))
    //        //            .Include(a => a.Roles)
    //        //            .Include(a => a.Roles.Select(r => r.Elements))
    //        //            .Load();
    //        //    }
    //        //}


    //        //using (ElementContext ec = new ElementContext())
    //        //{
    //        //    Element element = ec.Elements.Where(e => e.Dn == dn).Single();
    //        //    ec.Entry<Element>(element).State = System.Data.EntityState.Detached;
    //        //    return element;
    //        //}
    //    }
    //}
}
