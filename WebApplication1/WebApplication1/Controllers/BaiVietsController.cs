using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BaiVietsController : Controller
    {
        private reviewDB db = new reviewDB();

        // GET: BaiViets
        public ActionResult Index()
        {
            var baiViets = db.BaiViets.Include(b => b.DanhMuc).Include(b => b.DanhMuc1).Include(b => b.DanhMucCha).Include(b => b.TaiKhoan);
            return View(baiViets.ToList());
        }

        // GET: BaiViets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: BaiViets/Create
        public ActionResult Create()
        {
            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc");
            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc");
            ViewBag.IdDMCha = new SelectList(db.DanhMucChas, "MaDMCha", "TenDM");
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "HoTen");
            return View();
        }

        // POST: BaiViets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TieuDe,NoiDung,HinhAnh,IdDanhMuc,NgayTao,NgaySua,TrangThai,IdTaiKhoan,IdDMCha")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.BaiViets.Add(baiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc", baiViet.IdDanhMuc);
            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc", baiViet.IdDanhMuc);
            ViewBag.IdDMCha = new SelectList(db.DanhMucChas, "MaDMCha", "TenDM", baiViet.IdDMCha);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "HoTen", baiViet.IdTaiKhoan);

            return View(baiViet);
        }

        // GET: BaiViets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc", baiViet.IdDanhMuc);
            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc", baiViet.IdDanhMuc);
            ViewBag.IdDMCha = new SelectList(db.DanhMucChas, "MaDMCha", "TenDM", baiViet.IdDMCha);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "HoTen", baiViet.IdTaiKhoan);
            return View(baiViet);
        }

        // POST: BaiViets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TieuDe,NoiDung,HinhAnh,IdDanhMuc,NgayTao,NgaySua,TrangThai,IdTaiKhoan,IdDMCha")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc", baiViet.IdDanhMuc);
            ViewBag.IdDanhMuc = new SelectList(db.DanhMucs, "Id", "TenDanhMuc", baiViet.IdDanhMuc);
            ViewBag.IdDMCha = new SelectList(db.DanhMucChas, "MaDMCha", "TenDM", baiViet.IdDMCha);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "HoTen", baiViet.IdTaiKhoan);
            return View(baiViet);
        }

        // GET: BaiViets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: BaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiViet = db.BaiViets.Find(id);
            db.BaiViets.Remove(baiViet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
