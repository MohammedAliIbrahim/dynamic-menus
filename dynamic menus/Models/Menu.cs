using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dynamic_menus.Models
{
    public class Menu
    {

        public int MenuId { get; set; }
        [Required]
        public string MenuName { get; set; }
        [Required]
        public string MenuLink { get; set; } 
        // self reference
        public int? ParentId { get; set; }
        public  Menu Parent { get; set; }
        public  ICollection<Menu> SubMenus { get; set; }


    }
}