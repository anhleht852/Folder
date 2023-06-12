using SHOP_PET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP_PET.Controllers
{
    public class UsersController : Controller
    {
        dbPetDataContext db = new dbPetDataContext();
        // GET: Users
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["hoten"];
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var dienthoai = collection["dienthoai"];
            var ngaysinh = String.Format("{0:dd/MM/yyyy}", collection["ngaysinh"]);
            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Phải nhập mật khẩu xác nhận!";
            }
            else
            {
                if (!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau!";
                }
                else
                {
                    kh.hoten = hoten;
                    kh.tendangnhap = tendangnhap;
                    kh.matkhau = matkhau;
                    kh.email = email;
                    kh.diachi = diachi;
                    kh.dienthoai = dienthoai;
                    kh.ngaysinh = DateTime.Parse(ngaysinh);

                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();

                    return RedirectToAction("DangNhap");


                }
            }
            return this.DangKy();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult DangNhap(FormCollection collection)
        //{
        //    var tendangnhap = collection["tendangnhap"];
        //    var matkhau = collection["matkhau"];
        //    KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.tendangnhap == tendangnhap && n.matkhau == matkhau);
        //    if (kh != null)
        //    {
        //        ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
        //        Session["TaiKhoan"] = kh;
        //    }
        //    else
        //    {
        //        //ModelState.AddModelError(string.Empty, "Không đăng nhập được.");
        //        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng!";
        //        return RedirectToAction("DangNhap", "Users");
        //    }
        //    return RedirectToAction("Home", "Home");

        //}
        public ActionResult DangNhap(FormCollection userlog)
        {
            string tendangnhap = userlog["tendangnhap"].ToString();
            string matkhau = userlog["matkhau"].ToString();
            var islogin = db.KhachHangs.SingleOrDefault(x => x.tendangnhap.Equals(tendangnhap) && x.matkhau.Equals(matkhau));

            if (islogin != null)
            {
                if (tendangnhap == "admin")
                {
                    Session["TaiKhoan"] = islogin;
                    return RedirectToAction("Index", "Admin/Home");
                }
                else
                {
                    Session["TaiKhoan"] = islogin;
                    return RedirectToAction("Home", "Shop");

                }
            }
            else
            {
                ViewBag.Fail = "Tài khoản hoặc mật khẩu không chính xác.";
                return View("DangNhap");
            }

        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("DangNhap");
        }
    }
}