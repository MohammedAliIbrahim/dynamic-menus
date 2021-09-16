using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DynamicMenus.Models;

namespace DynamicMenus.Controllers
{
    public class MenusController : Controller
    {
        private MenuDBContext DB = new MenuDBContext();




        #region Menus List
        // GET: Menus
        public ActionResult Index()
        {
            var Menus = DB.Menus.Include(m => m.Parent);
            return View(Menus.ToList());
        }




        #endregion

        #region Header Menu
        public ActionResult MenuPages()
        {
            //show only the visible menus
            var Menus = DB.Menus.Where(x=>x.IsMenuVisible==true).Include(m => m.Parent);
            return View(Menus.ToList());
        }
        #endregion

        #region Internal Pages 
        // internal links

      
       
        public ActionResult OurProducts()
        {
            try
            {
                return View();
            }
            catch
            {
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");
            }
        }

        public ActionResult OurVision()
        {
            try
            {
                return View();
            }
            catch
            {
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");
            }
        }

        public ActionResult SalesJobs()
        {
            try
            {
                return View();
            }
            catch
            {
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");
            }
        }


        #endregion

        #region Error Page
        // this action renders a page that is used to handle exception in productoin environment

        public ActionResult ErrorPage()
        {
            return View();
        }
        #endregion

        #region Add New Menu
        public ActionResult Create()
        {
            try
            {
                ViewBag.ParentId = new SelectList(DB.Menus.Where(x => x.Parent == null), "MenuId", "MenuName");
                return View();
            }
            catch
            {
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");
            }
        }

        
        // POST: Menus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuId,MenuName,MenuLink,ParentId,IsMenuVisible,IsLinkBlankPage")] Menu MenuModel)
        {

            try { 

            if (ModelState.IsValid)
            {
                DB.Menus.Add(MenuModel);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            // this viewbag is filled with selectlist data of parent menu
            ViewBag.ParentId = new SelectList(DB.Menus.Where(x => x.Parent == null), "MenuId", "MenuName", MenuModel.ParentId);
            return View(MenuModel);

            }

            catch
            {
                // redirect to error page
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");

            }
        }
        #endregion

        #region Edit Menu  Information
        // GET: Menus/Edit/5
        public ActionResult Edit(int? Id)
        {
            try
            {

                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Menu MenuModel = DB.Menus.Find(Id);
                if (MenuModel == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ParentId = new SelectList(DB.Menus.Where(x => x.Parent == null), "MenuId", "MenuName", MenuModel.ParentId);
                return View(MenuModel);
            }

            catch
            {
                // redirect to error page
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");

            }
        }

        // POST: Menus/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuId,MenuName,MenuLink,ParentId,IsMenuVisible,IsLinkBlankPage")] Menu MenuModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    DB.Entry(MenuModel).State = EntityState.Modified;
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ParentId = new SelectList(DB.Menus.Where(x => x.Parent == null), "MenuId", "MenuName", MenuModel.ParentId);
                return View(MenuModel);
            }
            catch
            {
                // redirect to error page
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");

            }
        }

        #endregion

        #region Delete Menu
        
        // GET: Menus/Delete/5
        public ActionResult Delete(int? Id)
        {

            // attention ! you must delete the parent menu before deleting its children
            try
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Menu MenuModel = DB.Menus.Find(Id);
                if (MenuModel == null)
                {
                    return HttpNotFound();
                }
                return View(MenuModel);
            }

            catch
            {
                // redirect to error page
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");

            }
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {

            // attention ! you must delete the parent menu before deleting its children
            try
            {
                Menu MenuModel = DB.Menus.Include(m => m.SubMenus).Where(x=>x.MenuId==Id).FirstOrDefault();
                if (MenuModel.SubMenus.Any())
                {

                    ViewBag.ErrorDeleteParent = "You Can Not Delete A Menu That Has Children , Please Delete Its Children First";
                    return View(MenuModel);

                }
                DB.Menus.Remove(MenuModel);
                DB.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                // redirect to error page
                // you can also log the exception if you want that
                return RedirectToAction("ErrorPage");

            }
        }

        #endregion

    }
}
