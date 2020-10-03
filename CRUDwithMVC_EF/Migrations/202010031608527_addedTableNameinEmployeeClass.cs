namespace CRUDwithMVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTableNameinEmployeeClass : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employees", newName: "Employee");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Employee", newName: "Employees");
        }
    }
}
