using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace SHOP_PET.Models
{
    public class Giohang
    {
        dbPetDataContext data = new dbPetDataContext();
        public int mapet { get; set; }

        [Display(Name = "Tên pet")]
        public string tenpet { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string hinhpet { get; set; }

        [Display(Name = "Giá bán")]
        public Double giaban { get; set; }

        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }

        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get
            {
                return iSoluong * giaban;
            }
        }
        public Giohang(int id)
        {
            //mapet = id;
            //Pet pet = data.Pets.Single(n => n.mapet == mapet);
            //tenpet = pet.tenpet;
            //hinhpet = pet.hinhpet;
            //giaban = Double.Parse(pet.giaban.ToString());
            //iSoluong = 1;

            this.mapet= id;
            //Sach sach = data.Saches.Single(n => n.masach == masach);
            Pet p = data.Pets.Single(n => n.mapet == mapet);
            tenpet = p.tenpet;
            hinhpet= p.hinhpet;
            giaban = double.Parse(p.giaban.ToString());
            iSoluong = 1;

            //this.malich = malich;
            //LichChieu lc = data.LichChieus.Single(n => n.malich == malich);
            //ma = (int)lc.maphim;
            //gia = (int)lc.gia;
            //isoLuong = 1

            //tensach = sach.tensach;
            //hinh = sach.hinh;
            //giaban = double.Parse(sach.giaban.ToString());
            //iSoluong = 1;
        }
    }
}