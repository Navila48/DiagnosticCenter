using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCentreWebApp.DAL.Model
{
    public class TypeWiseReportVM
    {
        public string TestTypeName { get; set; }
        public double TotalNoofTest { get; set; }
        public decimal TotalFee { get; set; }

    }
}