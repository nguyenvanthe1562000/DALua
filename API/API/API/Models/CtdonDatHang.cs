using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class CtdonDatHang
    {
        public string MaCtdonDatHang { get; set; }
        public string MaDonHang     { get; set; }
        public string MaSp          { get; set; }
        public string TenSp         { get; set; }
        public string hinhAnh        { get; set; }
        public double? SoLuong      { get; set; }
        public double? DonGia       { get; set; }
        public double? GiamGia      { get; set; }

        public virtual DonDatHang MaDonHangNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
