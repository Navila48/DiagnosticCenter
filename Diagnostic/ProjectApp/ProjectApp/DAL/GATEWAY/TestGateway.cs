using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DiagnosticCentreWebApp.DAL.Model;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.DAL.GATEWAY
{
    public class TestGateway : GateWay
    {
        public int Save(string name)
        {


            Query = "INSERT INTO TestType VALUES(@TypeName)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("TypeName", SqlDbType.VarChar);
            Command.Parameters["TypeName"].Value = name;

            Connection.Open();

            int result = Command.ExecuteNonQuery();

            Connection.Close();
            return result;



        }



        public bool IsTestTypeExist(string typeName)
        {
            Query = "SELECT TypeName FROM TestType WHERE TypeName = LTRIM(RTRIM(@TypeName))";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("TypeName", SqlDbType.VarChar);
            Command.Parameters["TypeName"].Value = typeName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }


        public List<TestType> GetAllTestTypes()
        {
            Query = "SELECT * FROM TestType ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TestType> testTypes = new List<TestType>();
            while (Reader.Read())
            {
                TestType atype = new TestType();
                atype.TypeName = Reader["TypeName"].ToString();
                testTypes.Add(atype);
            }

            Reader.Close();
            Connection.Close();
            return testTypes;
        }

        public List<TypeWiseReportVM> FindType(string fromDate, string toDate)
        {
            Query =
                @"                
            SELECT tt.TypeId, tt.TypeName, isnull(test.totalNoOfTest,0) TotalTest, isnull(test.totalFee,0) Total FROM TestType tt
Left Outer JOIN (SELECT TypeId, COUNT(*) AS totalNoOfTest, SUM(fee) AS totalFee FROM TestSetup Inner Join BillingInfo B ON B.TestId=TestSetup.TestId
Where Date BETWEEN @fromDate AND @toDate GROUP BY TypeId) test
ON test.TypeId=tt.TypeId";
       
                

     
       Command=new SqlCommand(Query,Connection);

            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("fromDate", SqlDbType.Date);
            Command.Parameters["fromdate"].Value = fromDate;
            Command.Parameters.Add("toDate", SqlDbType.Date);
            Command.Parameters["toDate"].Value = toDate;
            Reader = Command.ExecuteReader();
            List<TypeWiseReportVM> types=new List<TypeWiseReportVM>();


            while (Reader.Read())
            {
                TypeWiseReportVM aTypeWiseReportVm = new TypeWiseReportVM();
                aTypeWiseReportVm.TestTypeName = Reader["TypeName"].ToString();
                aTypeWiseReportVm.TotalNoofTest =  (int) Reader["TotalTest"];
                aTypeWiseReportVm.TotalFee =  Convert.ToDecimal(Reader["total"]);
                types.Add(aTypeWiseReportVm);
            }
            Connection.Close();
            Reader.Close();
            return types;
        }
        }
    }
