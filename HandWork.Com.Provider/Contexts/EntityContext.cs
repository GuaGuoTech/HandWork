using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace HandWork.Com.Provider.Contexts
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=EntityContext") { }
        public DbSet<Dealer> DealerS { get; set; }
        public DbSet<Worker> WorkerS { get; set; }
       
    }
}