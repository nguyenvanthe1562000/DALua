using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class DonDatHangDTO
    {

        public string? MaKh { get; set; }
        public string DiaChiNhan { get; set; }
        public string Sdtnhan { get; set; }
        public double? ThanhTien { get; set; }
        public DateTime? NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }


        public virtual ICollection<DonDatHangChiTietDTO> HoaDonChiTietDTO { get; set; }
    }
}
