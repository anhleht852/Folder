using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class DanhGia_TinTuc
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public string TinTuc { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public bool TrangThai { get; set; }

        /*object data = (from cmt in db.DanhGias
                       join tt in db.TinTucs on cmt.IdTinTuc equals tt.Id
                       join tk in db.TaiKhoans on cmt.IdTaiKhoan equals tk.Id
                       select new DanhGia_TinTuc
                       {
                           Id = cmt.Id,
                           NoiDung = cmt.NoiDung,
                           TinTuc = tt.TieuDe,
                           TaiKhoan = tk.HoTen,
                           NgayTao = cmt.NgayTao,
                           NgaySua = cmt.NgaySua,
                           TrangThai = cmt.TrangThai
                       }).ToList();*/
    }
}