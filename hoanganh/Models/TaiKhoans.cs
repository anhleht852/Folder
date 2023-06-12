namespace WebTinTuc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaiKhoans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoans()
        {
            DanhGias = new HashSet<DanhGias>();
        }

        [Key]
        [DisplayName("Mã tài khoản")]
        public int Id { get; set; }

        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Tên tài khoản không bỏ trống")]
        [StringLength(20)]
        public string HoTen { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Chưa chọn giới tính")]
        public bool? GioiTinh { get; set; }

        [StringLength(20)]
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Chưa điền tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Chưa điền mậy khẩu")]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(20)]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Chưa điền email")]
        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Chưa điền địa chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Trạng thái")]
        [Required(ErrorMessage = "Chưa điền trạng thái")]
        public bool? TrangThai { get; set; }

        [DisplayName("Quyền")]
        [Required(ErrorMessage = "Chưa điền quyền")]
        public bool Quyen { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Chưa điền ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGias> DanhGias { get; set; }
    }
}
