using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.DATA.Contexts
{
    public class BaseDbContext<TContext, TConfiguration> : DbContext
         where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private static string _nameOrConnectionString = typeof(TContext).Name;

        public BaseDbContext() : base(_nameOrConnectionString) { }

        public BaseDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, TConfiguration>());
            _nameOrConnectionString = connectionString;
        }
    }
}
