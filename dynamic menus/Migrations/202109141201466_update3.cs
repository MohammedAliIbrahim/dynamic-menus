﻿namespace dynamic_menus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "MenuLink", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "MenuLink", c => c.String());
        }
    }
}