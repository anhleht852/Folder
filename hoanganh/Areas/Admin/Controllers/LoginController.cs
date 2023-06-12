using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        WebTinTucModel db = new WebTinTucModel();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string TenDangNhap, string MatKhau)
        {
            var data = db.TaiKhoans.Where(a => a.TenDangNhap == TenDangNhap && a.MatKhau == MatKhau && a.Quyen == true).FirstOrDefault();
            if (data != null)
            {
                string data_account = data.TenDangNhap + "," + data.HoTen + "," + data.Id;
                //Session["TaiKhoan"] = data;
                Session.Add("TaiKhoan", data_account);
            }
            else
            {
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng";
                ViewBag.TenDangNhap = TenDangNhap;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Remove("TaiKhoan");
            return RedirectToAction("Index", "Login");
        }
    }
}