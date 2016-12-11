using Sample.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.EntityFramework.Mappings
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.Name).IsRequired().HasMaxLength(32);
            this.Property(x => x.Password).IsRequired().HasMaxLength(32);
        }
    }
}
