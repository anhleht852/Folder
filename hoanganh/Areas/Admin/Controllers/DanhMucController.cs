using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Areas.Admin.Controllers
{
    public class DanhMucController : BaseController
    {
        WebTinTucModel db = new WebTinTucModel();
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            //if (TempData["Done"] != null || TempData["Error"] != null)
            //{
            //    ViewBag.Done = TempData["Done"];
            //    ViewBag.Error = TempData["Error"];
            //    TempData.Remove("Done");
            //    TempData.Remove("Error");
            //}
            return View(db.DanhMucs.ToList());
        }

        // GET: Admin/DanhMuc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DanhMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMuc/Create
        [HttpPost]
        public ActionResult Create(DanhMucs danhMuc)
        {
            try
            {
                danhMuc.NgayTao = DateTime.Now;
                danhMuc.NgaySua = DateTime.Now;
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                ViewBag.Done = "Thêm danh mục thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(danhMuc);
        }

        // GET: Admin/DanhMuc/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.DanhMucs.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index", "DanhMuc");
            }
            return View(data);
        }

        // POST: Admin/DanhMuc/Edit/5
        [HttpPost]
        public ActionResult Edit(DanhMucs danhMuc)
        {
            try
            {
                //var danhMuc = db.DanhMucs.Find(data.Id);
                //danhMuc = data;
                var query = (from dm in db.DanhMucs
                             where dm.Id == danhMuc.Id
                             select dm).Take(1);
                foreach (DanhMucs dm in query)
                {
                    dm.TenDanhMuc = danhMuc.TenDanhMuc;
                    dm.NgaySua = DateTime.Now;
                };
                db.SaveChanges();
                ViewBag.Done = "Sửa danh mục thành công";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(danhMuc);
        }




        // GET: Admin/DanhMuc/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.DanhMucs.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index", "DanhMuc");
            }
            return View(data);
        }

        // POST: Admin/DanhMuc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DanhMucs data)
        {
            try
            {
                DanhMucs dbEntity = db.DanhMucs.Find(id);
                db.DanhMucs.Remove(dbEntity);
                db.SaveChanges();
                TempData["Done"] = "Xóa danh mục thành công";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index", "DanhMuc");
        }
    }
}
