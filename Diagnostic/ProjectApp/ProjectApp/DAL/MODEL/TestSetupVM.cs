using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.DAL.Model
{
    public class TestSetupVM
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public double Fee { get; set; }
        public string TypeName { get; set; }
    }
}