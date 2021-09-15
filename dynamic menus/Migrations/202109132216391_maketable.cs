namespace dynamic_menus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maketable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuName = c.String(nullable: false),
                        MenuLink = c.String(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.Menus", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropTable("dbo.Menus");
        }
    }
}
