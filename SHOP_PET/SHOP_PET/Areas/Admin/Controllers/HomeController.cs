using SHOP_PET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SHOP_PET.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        dbPetDataContext db = new dbPetDataContext();
        // GET: Admin/Home
        public ActionResult Index(int? page, string searchString)
        {
            ViewBag.Keyword = searchString;
            if (page == null) page = 1;
            var all_Pet = (from Pet in db.Pets select Pet).OrderBy(m => m.mapet);
            if (!string.IsNullOrEmpty(searchString)) all_Pet = (IOrderedQueryable<Pet>)all_Pet.Where(a => a.tenpet.Contains(searchString));
            int pageSize = 5;
            int pageNUM = page ?? 1;
            return View(all_Pet.ToPagedList(pageNUM, pageSize));
        }




        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Pet s)
        {
            var E_maloai = Convert.ToInt32(collection["maloai"]);
            var E_tenpet = collection["tenpet"];
            var E_hinh = collection["hinhpet"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongtong = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_tenpet))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.maloai = E_maloai;
                s.tenpet = E_tenpet.ToString();
                s.hinhpet = E_hinh.ToString();
                s.giaban = E_giaban;
                s.ngaycapnhat = E_ngaycapnhat;
                s.soluongtong = E_soluongtong;
                db.Pets.InsertOnSubmit(s);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "Content/images/" + file.FileName;
        }
        public ActionResult Edit(int id)
        {
            var E_pet = db.Pets.First(m => m.mapet == id);
            return View(E_pet);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_maloai = Convert.ToInt32(collection["maloai"]);
            var E_pet = db.Pets.First(m => m.mapet == id);
            var E_tenpet = collection["tenpet"];
            var E_hinh = collection["hinhpet"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongtong = Convert.ToInt32(collection["soluongtong"]);
            E_pet.mapet = id;
            if (string.IsNullOrEmpty(E_tenpet))
            {
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                E_pet.maloai = E_maloai;
                E_pet.tenpet = E_tenpet;
                E_pet.hinhpet = E_hinh;
                E_pet.giaban = E_giaban;
                E_pet.ngaycapnhat = E_ngaycapnhat;
                E_pet.soluongtong = E_soluongtong;
                UpdateModel(E_pet);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var D_pet = db.Pets.First(m => m.mapet == id);
            return View(D_pet);

        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = db.Pets.First(m => m.mapet == id);
            db.Pets.DeleteOnSubmit(D_sach);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var st = db.Pets.Where(s => s.mapet == id).First();
            return View(st);
        }
    }
}