using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Diagramus.Models.ElementContext;
using System.Data.Entity;

namespace Diagramus.Controllers
{
    public class ElementController : ApiController
    {

        public Element GetElement(string dn)
        {
            using (ElementContext ec = new ElementContext())
            {
                // Az ElementContext legyen állapotmentes
                ec.Configuration.AutoDetectChangesEnabled = false;
                // Ne legyen lusta betöltődés, az adatokat az object contexten kívül fogjuk úgyis használni
                ec.Configuration.LazyLoadingEnabled = false;

                var domain = ec.Elements
                    .Include(k => k.Domain)
                    .OfType<Domain>()
                    .Where(d => d.Dn == "001")
                    .IncludeElementSubTrees()
                    .Single();
                return domain;
            }
        }
    }
}
