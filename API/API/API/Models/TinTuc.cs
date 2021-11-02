using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TinTuc
    {
        public string Id { get; set; }
        public string TieuDe { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public bool? TrangThai { get; set; }
    }
}
