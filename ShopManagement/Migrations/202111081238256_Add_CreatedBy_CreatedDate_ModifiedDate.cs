namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CreatedBy_CreatedDate_ModifiedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ModifiedDate");
            DropColumn("dbo.Products", "CreatedDate");
            DropColumn("dbo.Products", "CreatedBy");
            DropColumn("dbo.Categories", "ModifiedDate");
            DropColumn("dbo.Categories", "CreatedDate");
            DropColumn("dbo.Categories", "CreatedBy");
        }
    }
}
