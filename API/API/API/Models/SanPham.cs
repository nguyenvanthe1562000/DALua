using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CtdonDatHangs = new HashSet<CtdonDatHang>();
            CthoaDonNhaps = new HashSet<CthoaDonNhap>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string MaLoaiSp { get; set; }
        public string DonVi { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public int? SoLuongTon { get; set; }
        public int? LuotXem { get; set; }
        public int? LuotBinhLuan { get; set; }
        public int? SoLanMua { get; set; }
        public double? Dongia { get; set; }

        public virtual LoaiSanPham MaLoaiSpNavigation { get; set; }
        public virtual ICollection<CtdonDatHang> CtdonDatHangs { get; set; }
        public virtual ICollection<CthoaDonNhap> CthoaDonNhaps { get; set; }
    }
}
