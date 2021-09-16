namespace DynamicMenus.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "MenuLink", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "MenuLink", c => c.String(nullable: false));
        }
    }
}
