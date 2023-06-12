using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Controllers
{
    public class HomeController : Controller
    {
        WebTinTucModel db = new WebTinTucModel();
        public ActionResult Index()
        {
            var featured = (from tt in db.TinTucs
                            join dm in db.DanhMucs on tt.IdDanhMuc equals dm.Id
                            orderby tt.Id descending
                            select new TinTuc_DanhMuc
                            {
                                DanhMuc = dm.TenDanhMuc,
                                MaDanhMuc = dm.Id,
                                MaTinTuc = tt.Id,
                                TieuDe = tt.TieuDe,
                                NgayTao = tt.NgayTao,
                                HinhAnh = tt.HinhAnh
                            }).Take(3);
            ViewBag.Featured = featured;

            ViewBag.TopTen = (from tt in db.TinTucs
                              join dm in db.DanhMucs on tt.IdDanhMuc equals dm.Id
                              orderby tt.Id descending
                              select new TinTuc_DanhMuc
                              {
                                  DanhMuc = dm.TenDanhMuc,
                                  MaDanhMuc = dm.Id,
                                  MaTinTuc = tt.Id,
                                  TieuDe = tt.TieuDe,
                                  NgayTao = tt.NgayTao,
                                  HinhAnh = tt.HinhAnh
                              }).Take(10);
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

        [ChildActionOnly]
        public ActionResult MenuView()
        {
            var menu = db.DanhMucs.ToList();
            return PartialView(menu);
        }
    }
}