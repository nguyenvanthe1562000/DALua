using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonDatHangs = new HashSet<DonDatHang>();
        }

        public string MaKh { get; set; }
        public string TenKh { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
    }
}
