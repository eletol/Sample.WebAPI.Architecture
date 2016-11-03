namespace App.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "Department_DId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "Manager_EId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "DId" });
            DropIndex("dbo.Employees", new[] { "Manager_EId" });
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Employees", "Department_DId", c => c.Int());
            AlterColumn("dbo.Departments", "DId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Employees", "EId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Employees", "DId", c => c.String());
            AlterColumn("dbo.Employees", "Manager_EId", c => c.Int());
            AddPrimaryKey("dbo.Departments", "DId");
            AddPrimaryKey("dbo.Employees", "EId");
            CreateIndex("dbo.Employees", "Department_DId");
            CreateIndex("dbo.Employees", "Manager_EId");
            AddForeignKey("dbo.Employees", "Department_DId", "dbo.Departments", "DId");
            AddForeignKey("dbo.Employees", "Manager_EId", "dbo.Employees", "EId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Manager_EId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Department_DId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Manager_EId" });
            DropIndex("dbo.Employees", new[] { "Department_DId" });
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Employees", "Manager_EId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "DId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "EId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Departments", "DId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Employees", "Department_DId");
            AddPrimaryKey("dbo.Employees", "EId");
            AddPrimaryKey("dbo.Departments", "DId");
            CreateIndex("dbo.Employees", "Manager_EId");
            CreateIndex("dbo.Employees", "DId");
            AddForeignKey("dbo.Employees", "Manager_EId", "dbo.Employees", "EId");
            AddForeignKey("dbo.Employees", "Department_DId", "dbo.Departments", "DId");
            AddForeignKey("dbo.Employees", "DId", "dbo.Departments", "DId");
        }
    }
}
