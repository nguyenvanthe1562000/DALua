using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class DangNhapAdmin
    {
        public string Id { get; set; }
        public string Tenad { get; set; }

        public string username { set; get; }
        public string PassWord { set; get; }
        public bool IsActive { set; get; }
        public string Code { set; get; }
    }
}
