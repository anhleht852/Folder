namespace WebTinTuc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DanhGias
    {
        [Key]
        [DisplayName("Mã đánh giá")]
        public int Id { get; set; }

        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Nội dung không bỏ trống")]
        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public int IdTinTuc { get; set; }

        public int IdTaiKhoan { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [DisplayName("Ngày sửa")]
        public DateTime NgaySua { get; set; }

        public bool TrangThai { get; set; }

        public virtual TaiKhoans TaiKhoans { get; set; }

        public virtual TinTucs TinTucs { get; set; }
    }
}
