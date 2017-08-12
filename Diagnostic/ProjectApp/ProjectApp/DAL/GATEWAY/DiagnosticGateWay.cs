using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DiagnosticCenterApp.DAL.Model;

namespace ProjectApp.DAL.GATEWAY
{
    public class DiagnosticGateWay:GateWay
    {
        public List<TestWise> FindTest(string fromDate, string toDate)
        {
            Query = @"SELECT TestSetup.TestName, COUNT(BillingInfo.TestId)
             AS TotalTest, Fee, TotalAmount = Fee*COUNT(BillingInfo.TestId)
            FROM TestSetup LEFT JOIN (select TestId from BillingInfo
            where Date between @fromDate and @toDate 
            )BillingInfo ON TestSetup.TestId = BillingInfo.TestId group by TestName,Fee

";
                

     
       Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("fromDate", SqlDbType.Date);
            Command.Parameters["fromdate"].Value = fromDate;
            Command.Parameters.Add("toDate", SqlDbType.Date);
            Command.Parameters["toDate"].Value = toDate;
            Reader = Command.ExecuteReader();
            List<TestWise>tests=new List<TestWise>();


            while (Reader.Read())
            {
                TestWise aTestWise = new TestWise();
                aTestWise.Name = Reader["TestName"].ToString();
                aTestWise.TotalTest =  (int) Reader["TotalTest"];
                aTestWise.TotalAmount = (double) Reader["Totalamount"];
                tests.Add(aTestWise);
            }
            Connection.Close();
            Reader.Close();
            return tests;
        }
    }
}