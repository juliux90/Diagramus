using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Newtonsoft.Json.Linq;

namespace Diagramus.Models.ElementContext
{
    public static partial class QueryExtensions
    {
        /**
         * A kapott IJObjectConvertable kollekció elemein
         * végigiterálunk, meghívjuk a ToJObject() metódusaikat
         * majd egy JArray-al térünk vissza
         */
        public static JArray ToJArray(this IEnumerable<IJObjectConvertable> objects)
        {
            JArray result = new JArray();
            foreach (var item in objects)
            {
                result.Add(item.ToJObject());
            }
            return result;
        }

        /**
         * A Domain alá tartozó elemek betöltése, rekurzívan.
         * Asszociációk kapcsolódó objektumait nem tölti be!
         */
        public static IQueryable<Domain> IncludeElementSubTrees(this IQueryable<Domain> domains)
        {
            // TODO: körök?
            IQueryable<Element> childelements = domains.SelectMany(d => d.Elements);
            childelements.Load();
            IQueryable<Domain> childdomains = childelements.OfType<Domain>();
            if (childdomains.Any())
            {
                childdomains.IncludeElementSubTrees();
            }
            return domains;
        }

        /**
         * A Domain alá tartozó elemek betöltése, rekurzívan.
         * Asszociációk kapcsolódó objektumait is betölti!
         */
        public static IQueryable<Domain> IncludeFullElementSubTrees(this IQueryable<Domain> domains)
        {
            // TODO: körök?
            IQueryable<Element> childelements = domains.SelectMany(d => d.Elements);
            childelements.Load();
            IQueryable<Domain> childdomains = childelements.OfType<Domain>();
            if (childdomains.Any())
            {
                childdomains.IncludeFullElementSubTrees();
            }
            IQueryable<Association> childassociations = childelements.OfType<Association>();
            if (childassociations.Any())
            {
                childassociations.IncludeFullParticipatingElementSubTrees();
            }
            return domains;
        }

        /** 
         * Betölti a Role-okat, hozzátartozó Elementeket, illetve a Domain elementek alá tartozó elementeket
         * Az asszociációk kapcsolódó objektumait nem, arra a IncludeFullParticipatingElementSubTrees függvény való
         */
        public static IQueryable<Association> IncludeParticipatingElementSubTrees(this IQueryable<Association> associations)
        {
            // TODO: körök?
            associations.Select(a => a.Roles).Load();
            IQueryable<Element> pements = associations.Include(a => a.Roles).SelectMany(a => a.Roles).SelectMany(r => r.Elements);
            pements.Load();
            IQueryable<Domain> pdomains = pements.OfType<Domain>();
            if (pdomains.Any())
            {
                pdomains.IncludeElementSubTrees();
            }
            return associations;
        }

        /**
         * Betölti a Role-okat, hozzátartozó Elementeket, a Domain elementek alá tartozó elementeket,
         * illetve a kapcsolódó asszociációk hasonló objektumait.
         */
        public static IQueryable<Association> IncludeFullParticipatingElementSubTrees(this IQueryable<Association> associations)
        {
            // TODO: körök?
            associations.Select(a => a.Roles).Load();
            associations.SelectMany(a => a.Roles).Include(r => r.Elements).Load();
            IQueryable<Element> pements = associations.SelectMany(a => a.Roles).SelectMany(r => r.Elements);
            //pements.Load();
            IQueryable<Domain> pdomains = pements.OfType<Domain>();
            if (pdomains.Any())
            {
                pdomains.IncludeElementSubTrees();
            }
            IQueryable<Association> passociations = pements.OfType<Association>();
            if (passociations.Any())
            {
                passociations.IncludeFullParticipatingElementSubTrees();
            }
            return associations;
        }
    }
}