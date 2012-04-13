using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diagramus.Models;
using Diagramus.Models.ElementContext;
using Newtonsoft.Json.Linq;

namespace Diagramus.Controllers
{
    public class HomeController : Controller
    {
        //private ElementContext ec = new ElementContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //IEnumerable<Entity> e = ec.Entities.Select(p => p);
            using (ElementContext ec = new ElementContext())
            {
                // Az ElementContext legyen állapotmentes
                ec.Configuration.AutoDetectChangesEnabled = false;
                // Ne legyen lusta betöltődés, az adatokat az object contexten kívül fogjuk úgyis használni
                ec.Configuration.LazyLoadingEnabled = false;

                // Domainek lekérdezése
                //var domains = ec.Elements
                //    .Include(k => k.Domain)
                //    .OfType<Domain>()
                //    .Include(k => k.Elements);

                var domains = ec.Elements
                    .Include(k => k.Domain)
                    .Include(k => k.StringAttributes)
                    .Include(k => k.NumberAttributes)
                    .OfType<Domain>()
                    .Where(d => d.Domain == null).IncludeElementSubTrees().ToList();

                //// Asszociációk navigation propertyjeinek behúzása az ElementContextbe
                //foreach (var domain in domains)
                //{
                //    ec.Elements.OfType<Association>()
                //        .Where(a => a.Domain.Dn.Equals(domain.Dn))
                //        .Include(a => a.Roles)
                //        .Include(a => a.Roles.Select(r => r.Elements))
                //        .Load();
                //}

                return View(domains);
            }
        }

        public ActionResult GetElement(string dn)
        {
            using (ElementContext ec = new ElementContext())
            {
                // Az ElementContext legyen állapotmentes
                ec.Configuration.AutoDetectChangesEnabled = false;

                var jdomain = ec.Elements
                    .OfType<Domain>()
                    .Where(d => d.Dn == dn)
                    .IncludeElementSubTrees()
                    .Single().ToJObject();

                return new JsonNetResult(jdomain);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
    }
}
