using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            CthoaDonNhaps = new HashSet<CthoaDonNhap>();
        }

        public string MaHoaDonNhap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string MaNcc { get; set; }
        public double? TongTien { get; set; }

        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual ICollection<CthoaDonNhap> CthoaDonNhaps { get; set; }
    }
}
