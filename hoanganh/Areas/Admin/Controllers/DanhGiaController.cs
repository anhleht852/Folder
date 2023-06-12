using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Areas.Admin.Controllers
{
    public class DanhGiaController : BaseController
    {
        WebTinTucModel db = new WebTinTucModel();
        // GET: Admin/DanhGia
        public ActionResult Index(int id)
        {
            object data = (from cmt in db.DanhGias
                           join tt in db.TinTucs on cmt.IdTinTuc equals tt.Id
                           join tk in db.TaiKhoans on cmt.IdTaiKhoan equals tk.Id
                           where cmt.IdTinTuc == id
                           select new DanhGia_TinTuc
                           {
                               Id = cmt.Id,
                               NoiDung = cmt.NoiDung,
                               TinTuc = tt.TieuDe,
                               TaiKhoan = tk.HoTen,
                               NgayTao = cmt.NgayTao,
                               NgaySua = cmt.NgaySua,
                               TrangThai = cmt.TrangThai
                           }).ToList();
            ViewBag.Data = data;
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(db.DanhGias.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, DanhGias danhGias)
        {
            var data = db.DanhMucs.Find(id);
            if (data == null)
            {
                return RedirectToAction("/Admin/Index/" + id);
            }
            return View(data);
        }

        public ActionResult Change(int id)
        {
            var data = db.DanhGias.Find(id);
            data.TrangThai = !data.TrangThai;
            data.NgaySua = DateTime.Now;
            db.SaveChanges();
            ViewBag.Done = "Thay đổi thành công";
            return RedirectToAction("/Index/" + data.IdTinTuc);
        }
    }
}