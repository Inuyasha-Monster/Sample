using Sample.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.EntityFramework.DbContexts
{
    public class SampleDbContext : DbContext, ISampleDbContext
    {
        static SampleDbContext()
        {
            Database.SetInitializer<SampleDbContext>(null);
        }

        public SampleDbContext() : base("server=.;database=SampleDb;uid=sa;pwd=123456")
        {

        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
