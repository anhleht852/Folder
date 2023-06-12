namespace WebTinTuc.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebTinTucModel : DbContext
    {
        public WebTinTucModel()
            : base("name=connect")
        {
        }

        public virtual DbSet<DanhGias> DanhGias { get; set; }
        public virtual DbSet<DanhMucs> DanhMucs { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoans> TaiKhoans { get; set; }
        public virtual DbSet<TinTucs> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucs>()
                .HasMany(e => e.TinTucs)
                .WithRequired(e => e.DanhMucs)
                .HasForeignKey(e => e.IdDanhMuc);

            modelBuilder.Entity<TaiKhoans>()
                .HasMany(e => e.DanhGias)
                .WithRequired(e => e.TaiKhoans)
                .HasForeignKey(e => e.IdTaiKhoan);

            modelBuilder.Entity<TinTucs>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<TinTucs>()
                .HasMany(e => e.DanhGias)
                .WithRequired(e => e.TinTucs)
                .HasForeignKey(e => e.IdTinTuc);
        }
    }
}
