using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Diagramus.Models.ElementContext
{
    public class ElementContextInitializer : DropCreateDatabaseAlways<ElementContext> //DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(ElementContext context)
        {
            base.Seed(context);

            Domain d = new NamedDomain("001", "Project", null, "testproject", "testproject");
            Domain d1 = new NamedDomain("002", "InnerDomain", d, "InnerDomain", "InnerDomain");
            d.Elements.Add(d1);

            Element e1 = new Element("e1", "Entity", d);
            d.Elements.Add(e1);

            Element e2 = new Element("e2", "Entity", d1);
            d1.Elements.Add(e2);

            Element e3 = new Element("e3", "Entity", d1);
            d1.Elements.Add(e3);

            Association r1 = new Association("r1", "Relation", d);
            d.Elements.Add(r1);

            Role start = new Role("start");
            start.Elements.Add(e1);
            start.Elements.Add(e2);
            r1.Roles.Add(start);

            Role end = new Role("End");
            end.Elements.Add(e2);
            r1.Roles.Add(end);

            Association r2 = new Association("r2", "Relation", d);
            d.Elements.Add(r2);

            Role start1 = new Role("start");
            start1.Elements.Add(e1);
            start1.Elements.Add(e2);
            r2.Roles.Add(start1);

            Role end1 = new Role("end");
            end1.Elements.Add(e3);
            r2.Roles.Add(end1);

            List<Element> elements = new List<Element>
            {
                d,
                d1,
                e1,
                e2,
                r1,
                r2
            };

            elements.ForEach(e => context.Elements.Add(e));

            //Domain d = new NamedDomain
            //{
            //    Rn = "001",
            //    Dn = "001",
            //    Type = "project",
            //    Domain = null
            //}; //("001", "project", null, "testproject", "testproject");

            //Element e1 = new Element
            //{
            //    Rn = "e1",
            //    Dn = "001/e1",
            //    Type = "startentity",
            //    Domain = d
            //}; //("e1", "startentity", d);
            //d.Elements.Add(e1);

            //Element e2 = new Element
            //{
            //    Rn = "e2",
            //    Dn = "001/e2",
            //    Type = "endentity",
            //    Domain = d
            //}; //("e2", "endentity", d);
            //d.Elements.Add(e2);

            //Element e3 = new Element
            //{
            //    Rn = "e3",
            //    Dn = "001/e3",
            //    Type = "endentity",
            //    Domain = d
            //}; //("e3", "endentity", d);
            //d.Elements.Add(e3);

            //Association r1 = new Association
            //{
            //    Rn = "r1",
            //    Dn = "001/r1",
            //    Type = "Relation",
            //    Domain = d
            //};

            //Role start = new Role {
            //    Name = "start"
            //};
            //start.Elements.Add(e1);
            //start.Elements.Add(e2);
            //r1.Roles.Add(start);

            //Role end = new Role
            //{
            //    Name = "end"
            //};
            //end.Elements.Add(e2);
            //r1.Roles.Add(end);

            //Association r2 = new Association
            //{
            //    Rn = "r2",
            //    Dn = "001/r2",
            //    Type = "Relation",
            //    Domain = d
            //};

            //Role start1 = new Role
            //{
            //    Name = "start"
            //};
            //start1.Elements.Add(e1);
            //start1.Elements.Add(e2);
            //r2.Roles.Add(start1);

            //Role end1 = new Role
            //{
            //    Name = "end"
            //};
            //end1.Elements.Add(e3);
            //r2.Roles.Add(end1);
            
            //new Relation("r1", "Relation", d);
            //Relation r2 = //new Relation("r2", "Relation", d);

            /*r1.AddEntity("start", e1);
            //r.AddEntity("start", e1);
            r1.AddEntity("start", e3);
            r1.AddEntity("end", e2);

            r2.AddEntity("start", e1);
            //r.AddEntity("start", e1);
            r2.AddEntity("start", e3);
            r2.AddEntity("end", e2);*/
        }
    }
}