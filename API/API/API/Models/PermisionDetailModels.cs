using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class PermisionDetailModel 
     {
       	
	public int ID { set; get; }
	public string PermisionCode { set; get; }
	public string functionCode { set; get; }
	public bool CanCreate { set; get; }
	public bool CanRead { set; get; }
	public bool Canupdate { set; get; }
	public bool Candelete { set; get; }
	public bool CanReport { set; get; }
	public bool IsActive { set; get; }
	

     }
}



