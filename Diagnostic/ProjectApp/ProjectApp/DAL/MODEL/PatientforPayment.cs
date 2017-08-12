using System;

namespace ProjectApp.DAL.MODEL
{
    public class PatientForPayment
    {
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNo { get; set; }
        public string BillNo { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}