using PagedList;
using SHOP_PET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace SHOP_PET.Controllers
{
    public class HomeController : Controller
    {
        dbPetDataContext db = new dbPetDataContext();
        public ActionResult Home(int? size, int? page)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "3", Value = "3" });
            items.Add(new SelectListItem { Text = "6", Value = "6" });
            items.Add(new SelectListItem { Text = "12", Value = "12" });
            items.Add(new SelectListItem { Text = "24", Value = "24" });
            items.Add(new SelectListItem { Text = "48", Value = "48" });
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            ViewBag.size = items;
            ViewBag.currentSize = size;
            if (page == null) page = 1;
            var all_Pet = from Pet in db.Pets select Pet;
            int pageSize = (size ?? 3);
            int pageNum = page ?? 1;
            return View(all_Pet.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(int id)
        {
            var st = db.Pets.Where(s => s.mapet == id).First();
            return View(st);
        }
    }
}