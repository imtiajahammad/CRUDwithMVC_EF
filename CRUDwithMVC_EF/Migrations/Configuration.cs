namespace CRUDwithMVC_EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUDwithMVC_EF.EmployeeDBContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            //
            // to use the EmployeeDBContextSeeder to make test database data
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CRUDwithMVC_EF.EmployeeDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
