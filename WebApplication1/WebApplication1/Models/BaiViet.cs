namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            DanhGias = new HashSet<DanhGia>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NoiDung { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string HinhAnh { get; set; }

        public int IdDanhMuc { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime NgaySua { get; set; }

        public bool TrangThai { get; set; }

        public int? IdTaiKhoan { get; set; }

        public int? IdDMCha { get; set; }

        public virtual DanhMucCha DanhMucCha { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        public virtual DanhMuc DanhMuc1 { get; set; }
    }
}
