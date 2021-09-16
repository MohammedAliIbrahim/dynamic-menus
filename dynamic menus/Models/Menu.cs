using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DynamicMenus.Models
{
    public class Menu
    {

        public int MenuId { get; set; }
        [Required]
        [Display(Name ="Menu Name")]
        public string MenuName { get; set; }
        [Required]
        [Display(Name = "Menu Link")]
        public string MenuLink { get; set; }
        [Display(Name = "Show The Menu ?")]
        public bool? IsMenuVisible { get; set; }
        [Display(Name = "Open Link In A New Tab ?")]
        public bool? IsLinkBlankPage { get; set; }
        // self reference
        [Display(Name = "Parent Menu")]
        public int? ParentId { get; set; }
        public  Menu Parent { get; set; }
        public  ICollection<Menu> SubMenus { get; set; }


    }
}