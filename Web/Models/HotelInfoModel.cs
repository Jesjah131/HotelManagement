using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace Web.Models
{
    public class HotelInfoModel
    {
        public int HID { get; set; }
        public string Hotelname { get; set; }
        public string Hotelchain { get; set; }
        public string City { get; set; }
        public string Streetname { get; set; }
        public string Country { get; set; }
        public int? Stars { get; set; }
        public string Description { get; set; }
        public int? HAID { get; set; }
        public List<Room>  rooms { get; set; }  
        public string Img_path { get; set; }   
        public int loggedInAdmin { get; set; }
    }
}