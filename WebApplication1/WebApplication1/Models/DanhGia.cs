namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DanhGia
    {
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NoiDung { get; set; }

        public int IdTinTuc { get; set; }

        public int IdTaiKhoan { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime NgaySua { get; set; }

        public bool TrangThai { get; set; }

        public virtual BaiViet BaiViet { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
