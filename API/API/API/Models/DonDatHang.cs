using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class DonDatHang
    {
        public DonDatHang()
        {
            CtdonDatHangs = new HashSet<CtdonDatHang>();
        }

        public string MaDonHang { get; set; }
        public string MaKh { get; set; }
        public string DiaChiNhan { get; set; }
        public string Sdtnhan { get; set; }
        public bool? TinhTrang { get; set; }
        public double? ThanhTien { get; set; }
        public DateTime? NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual ICollection<CtdonDatHang> CtdonDatHangs { get; set; }
    }
}
