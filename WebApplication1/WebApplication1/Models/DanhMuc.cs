namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            BaiViets = new HashSet<BaiViet>();
            BaiViets1 = new HashSet<BaiViet>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDanhMuc { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime NgaySua { get; set; }

        public int? IdDanhMucCha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets1 { get; set; }

        public virtual DanhMucCha DanhMucCha { get; set; }
    }
}
