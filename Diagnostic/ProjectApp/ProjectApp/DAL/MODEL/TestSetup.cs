using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.DAL.MODEL
{
    [Serializable]
    public class TestSetup
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public double Fee { get; set; }
        public int TypeId { get; set; }
    }
}