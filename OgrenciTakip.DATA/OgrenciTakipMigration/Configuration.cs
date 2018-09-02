using OgrenciTakip.DATA.Contexts;
using System.Data.Entity.Migrations;

namespace OgrenciTakip.DATA.OgrenciTakipMigration
{
    public class Configuration :DbMigrationsConfiguration<OgrenciTakipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
