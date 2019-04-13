namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DTO;

    internal sealed class Configuration : DbMigrationsConfiguration<Schedules.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Schedules.Context context)
        {

        }
    }
}
