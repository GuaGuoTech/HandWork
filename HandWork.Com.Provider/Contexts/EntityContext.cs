using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using HandWork.Com.Model.Dealers;
using HandWork.Com.Model.Workers;
using HandWork.Com.Model.Employment;
using HandWork.Com.Model.Recruits;

namespace HandWork.Com.Provider.Contexts
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=EntityContext") { }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Recruit> Recruits { get; set; }


    }
}