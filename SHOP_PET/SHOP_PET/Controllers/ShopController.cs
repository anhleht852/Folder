using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SHOP_PET.Models;

namespace SHOP_PET.Controllers
{
    public class ShopController : Controller
    {
        dbPetDataContext db = new dbPetDataContext();
        // GET: Shop
        private IQueryable<Pet> FilterItemsByPrice(IQueryable<Pet> items, string price)
        {
            switch (price)
            {
                case "Chó":
                    return items.Where(it => it.maloai==1);
                case "Mèo":
                    return items.Where(it => it.maloai==2);
                case "Cá":
                    return items.Where(it => it.maloai==3);
                default:
                    return items;
            }
        }
        private List<string> GetPriceList()
        {
            return new List<string> { "Mèo", "Chó", "Cá" };
        }

        //private IQueryable<Pet> FilterItemsByPrice1(IQueryable<Pet> items, string price)
        //{
        //    switch (price)
        //    {
        //        case "Chó":
        //            return items.Where(it => it.giaban == 100);
        //        case "Mèo":
        //            return items.Where(it => it.giaban == 2000);
        //        case "Cá":
        //            return items.Where(it => it.giaban == 300);
        //        default:
        //            return items;
        //    }
        //}
        //private List<string> GetPriceList1()
        //{
        //    return new List<string> { "Mèo", "Chó", "Cá" };
        //}

        public ActionResult Home(int? size, int? page, string price, string searchString)
        {
            ViewBag.Keyword = searchString;
            
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
            ViewBag.PriceList = new SelectList(GetPriceList());
            if (page == null) page = 1;
            var all_Pet = from Pet in db.Pets select Pet;
            if (!string.IsNullOrEmpty(price))
            {
                all_Pet = FilterItemsByPrice(all_Pet, price);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                all_Pet = all_Pet.Where(s => s.tenpet.Contains(searchString));
            }
            int pageSize = (size ?? 3);
            int pageNum = page ?? 1;
            return View(all_Pet.ToPagedList(pageNum, pageSize));
            
        }
        public ActionResult Details(int id)
        {
            var st = db.Pets.Where(s => s.mapet == id).First();
            return View(st);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}