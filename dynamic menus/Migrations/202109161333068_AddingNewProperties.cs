namespace DynamicMenus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNewProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "IsMenuVisible", c => c.Boolean());
            AlterColumn("dbo.Menus", "IsLinkBlankPage", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "IsLinkBlankPage", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Menus", "IsMenuVisible", c => c.Boolean(nullable: false));
        }
    }
}
