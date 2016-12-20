using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ReservationModel
    {
        public int REID { get; set; }

        public int UID { get; set; }

        public int RID { get; set; }

        public string Total_sum { get; set; }

        public DateTime Check_In { get; set; }

        public DateTime Check_Out { get; set; }

        public bool Status { get; set; }
    }
}