using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Diagramus.Models.ElementContext.Attributes;

namespace Diagramus.Models.ElementContext
{
    public class ElementContext : DbContext
    {
        public DbSet<Element> Elements { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<StringAttribute> StringAttributes { get; set; }
        //public DbSet<NumberAttribute> NumberAttributes { get; set; }
        //public DbSet<CoordinateAttribute> CoordinateAttributes { get; set; }
        //public DbSet<CoordinateListElement> CoordinateListElements { get; set; }
        //public DbSet<CoordinateListAttribute> CoordinateListAttributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(t => t.Elements).WithMany();//.WillCascadeOnDelete(false);
        }
    }
}