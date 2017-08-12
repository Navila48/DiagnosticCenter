using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProjectApp.DAL.GATEWAY
{
    public class GateWay
    {
        public string Query { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public GateWay()
        {
            Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        }
    }
}