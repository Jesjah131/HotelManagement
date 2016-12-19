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

        public string Total_sum { get; set; }

        [DataType(DataType.Date)]
        public DateTime Check_In { get; set; }

        [DataType(DataType.Date)]
        public DateTime Check_Out { get; set; }

        public int UID { get; set; }

        public int RID { get; set; }

        public bool Status { get; set; }
    }
}