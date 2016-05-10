using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.WeiXin.EFDAL
{
    public class WXContext : DbContext
    {
        public WXContext()
            : base("DbConnectionString")
        {

        }

        public DbSet<BusinessModels.SysConfigItem> SysConfigItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<
                System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}
