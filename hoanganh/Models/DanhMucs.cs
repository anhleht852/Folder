namespace WebTinTuc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DanhMucs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucs()
        {
            TinTucs = new HashSet<TinTucs>();
        }


        [Key]
        [DisplayName("Mã danh mục")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không bỏ trống")]
        [DisplayName("Tên danh mục")]
        [StringLength(50)]
        public string TenDanhMuc { get; set; }

        [DisplayName("Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime NgayTao { get; set; }

        [DisplayName("Ngày sửa")]
        [DataType(DataType.DateTime)]
        public DateTime NgaySua { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TinTucs> TinTucs { get; set; }
    }
}
