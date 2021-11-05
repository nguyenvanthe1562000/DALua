using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class Function
    {
        public int Id { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string Code { set; get; }
        public int CategoryFunc { set; get; }
        public string Name { set; get; }
        public string Url { set; get; }
        public int DisplayOrder { set; get; }
        public bool IsActive { set; get; }


    }
}



