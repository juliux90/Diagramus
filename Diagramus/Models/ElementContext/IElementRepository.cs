using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagramus.Models.ElementContext
{
    interface IElementRepository
    {
        //IQueryable<Element> GetAll();
        Element GetElement(string dn);
        //Element Add(Element item);
        //void Remove(int id);
        //bool Update(Element item);
    }
}
