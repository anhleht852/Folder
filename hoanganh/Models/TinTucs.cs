namespace WebTinTuc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TinTucs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TinTucs()
        {
            DanhGias = new HashSet<DanhGias>();
        }

        [Key]
        [DisplayName("Mã tin tức")]
        public int Id { get; set; }

        [DisplayName("Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không bỏ trống")]
        [StringLength(500)]
        public string TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Nội dung không bỏ trống")]
        public string NoiDung { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Hình ảnh")]
        [Required(ErrorMessage = "Chưa có hình ảnh")]
        public string HinhAnh { get; set; }

        public int IdDanhMuc { get; set; }

        [DisplayName("Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime NgayTao { get; set; }

        [DisplayName("Ngày sửa")]
        [DataType(DataType.DateTime)]
        public DateTime NgaySua { get; set; }

        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGias> DanhGias { get; set; }

        public virtual DanhMucs DanhMucs { get; set; }
    }
}
