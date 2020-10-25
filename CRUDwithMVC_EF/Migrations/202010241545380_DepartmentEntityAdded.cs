namespace CRUDwithMVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employee", "Department_Id", c => c.Int());
            CreateIndex("dbo.Employee", "Department_Id");
            AddForeignKey("dbo.Employee", "Department_Id", "dbo.Department", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Department_Id", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_Id" });
            DropColumn("dbo.Employee", "Department_Id");
            DropTable("dbo.Department");
        }
    }
}
