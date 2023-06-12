using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class reviewDB : DbContext
    {
        public reviewDB()
            : base("name=reviewDB")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DanhMucCha> DanhMucChas { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .HasMany(e => e.DanhGias)
                .WithRequired(e => e.BaiViet)
                .HasForeignKey(e => e.IdTinTuc);

            modelBuilder.Entity<DanhMucCha>()
                .HasMany(e => e.BaiViets)
                .WithOptional(e => e.DanhMucCha)
                .HasForeignKey(e => e.IdDMCha);

            modelBuilder.Entity<DanhMucCha>()
                .HasMany(e => e.DanhMucs)
                .WithOptional(e => e.DanhMucCha)
                .HasForeignKey(e => e.IdDanhMucCha);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.DanhMuc)
                .HasForeignKey(e => e.IdDanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.BaiViets1)
                .WithRequired(e => e.DanhMuc1)
                .HasForeignKey(e => e.IdDanhMuc);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.BaiViets)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DanhGias)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan);
        }
    }
}
