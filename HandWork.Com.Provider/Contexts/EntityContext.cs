using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
//using HandWork.Com.Model.Dealers;
//using HandWork.Com.Model.Workers;
using HandWork.Com.Model.WantedJobs;
using HandWork.Com.Model.Recruits;
using HandWork.Com.Model.Users;
using HandWork.Com.Model.Weixins;

namespace HandWork.Com.Provider.Contexts
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=EntityContext") { }
        public DbSet<User> Users { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<WantedJob> WantedJobs { get; set; }
        public DbSet<Recruit> Recruits { get; set; }

        public DbSet<WeixinUser> WeixinUsers { get; set; }

    }
}