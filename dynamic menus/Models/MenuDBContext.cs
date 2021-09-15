using System.Data.Entity;

namespace dynamic_menus.Models
{
    public class MenuDBContext : DbContext
    {

        #region BContext Configuration
        public MenuDBContext() : base("name=DynamicMenusContext")
        {

        }
        #endregion

        #region fluent api
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
           
            //use fluent api to ensure valid mapping of code first model to database table
           // self reference , every menu can refrer to a parent menu
           // and also every menu can have a sub menu
            
            modelBuilder.Entity<Menu>().
              HasOptional(e => e.Parent).
              WithMany(f=>f.SubMenus).
              HasForeignKey(m => m.ParentId);
           
        }

        #endregion
        public DbSet<Menu> Menus { get; set; }
    }
}