using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        WebTinTucModel db = new WebTinTucModel();
        public ActionResult Index()
        {
            int TongDanhMuc = db.DanhMucs.Count();
            int TongTinTuc = db.TinTucs.Count();
            int TongTaiKhoan = db.TaiKhoans.Count();
            int[] data = new int[] { TongDanhMuc, TongTinTuc, TongTaiKhoan };
            ViewBag.Data = data;
            return View();
        }
    }
}