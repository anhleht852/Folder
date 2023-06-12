using SHOP_PET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SHOP_PET.Areas.Admin.Controllers
{
    public class ThongkeController : Controller
    {
        dbPetDataContext db = new dbPetDataContext();
        // GET: Admin/Thongke
        public ActionResult Thongke()
        {
            var result = from c in db.ChiTietDonHangs
                         join p in db.Pets on c.mapet equals p.mapet
                         join d in db.DonHangs on c.madon equals d.madon
                         join k in db.KhachHangs on d.makh equals k.makh
                         group new { c, p } by new { d.madon, k.hoten, k.dienthoai, c.soluong } into g
                         select new ThongKe
                         {
                             mahd = g.Key.madon,
                             hoten = g.Key.hoten,
                             sdt = g.Key.dienthoai,
                             soluong = g.Key.soluong,
                             tongtien =(int) g.Sum(x => x.c.soluong * x.p.giaban)
                         };


            return View(result);

        }
    }
}