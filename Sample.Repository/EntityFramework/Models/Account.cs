using Sample.Core.DataBaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.EntityFramework.Models
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
