using PagedList;
using SHOP_PET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP_PET.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        dbPetDataContext db = new dbPetDataContext();
        // GET: Admin/NguoiDung
        public ActionResult Index()
        {
            var all_KH = from r in db.KhachHangs select r;
            return View(all_KH);
        }
       
        public ActionResult Edit(int id)
        {
            var E_KH = db.KhachHangs.First(m => m.makh == id);
            return View(E_KH);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_makh = Convert.ToInt32(collection["makh"]);
            var E_KH = db.KhachHangs.First(m => m.makh == id);
            var E_hoten = collection["hoten"];
            var E_tendangnhap = collection["tendangnhap"];
            var E_matkhau = collection["matkhau"];
            var E_email = collection["email"];
            var E_diachi = collection["diachi"];
            var E_dienthoai = collection["dienthoai"];
            var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
            E_KH.makh = id;
            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                E_KH.hoten = E_hoten;
                E_KH.tendangnhap = E_tendangnhap;
                E_KH.matkhau = E_matkhau;
                E_KH.email = E_email;
                E_KH.diachi = E_diachi;
                E_KH.dienthoai = E_dienthoai;
                E_KH.ngaysinh = E_ngaysinh;
                UpdateModel(E_KH);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var D_KH = db.KhachHangs.First(m => m.makh == id);
            return View(D_KH);

        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_KH = db.KhachHangs.First(m => m.makh == id);
            db.KhachHangs.DeleteOnSubmit(D_KH);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}