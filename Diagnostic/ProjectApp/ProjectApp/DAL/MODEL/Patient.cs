using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.DAL.MODEL
{
    [Serializable]
    public class Patient
    {
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNo { get; set; }
        public string BillNo { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }

    }
}