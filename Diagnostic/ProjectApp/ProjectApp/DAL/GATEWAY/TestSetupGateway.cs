using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjectApp.DAL.MODEL;
using WebApplication10.DAL.Model;

namespace ProjectApp.DAL.GATEWAY
{
    public class TestSetupGateway:GateWay
    {
        public int SaveTest(TestSetup aTestSetup)
        {
            Query = "INSERT INTO TestSetup (TestName, Fee,TypeId) VALUES (@testName,@fee,@testTypeId)";
          //  Query = "INSERT INTO TestSetup (TestName, Fee,TypeId) VALUES ('" + aTestSetup.TestName + "','" + aTestSetup.Fee + "','" + aTestSetup.TypeId + "')";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("testName", SqlDbType.VarChar);
            Command.Parameters["testName"].Value = aTestSetup.TestName;
            Command.Parameters.Add("fee", SqlDbType.VarChar);
            Command.Parameters["fee"].Value = aTestSetup.Fee;
            Command.Parameters.Add("testTypeId", SqlDbType.VarChar);
            Command.Parameters["testTypeId"].Value = aTestSetup.TypeId;




            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsTestNameExist(TestSetup aTestSetup)
        {

            Query = "SELECT * FROM TestSetup WHERE TestName =LTRIM(RTRIM('"+aTestSetup.TestName+"'))";
            //Query = "SELECT * FROM TestSetup WHERE TestName =@testName";

            Connection.Open();
            Command = new SqlCommand(Query, Connection);

            //Command.Parameters.Clear();
            //Command.Parameters.Add("testName", SqlDbType.VarChar);
            //Command.Parameters["testName"].Value = "aTestSetup.TestName";
        
          

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;
        }

        public List<TestSetupVM> GetAllTestDetails()
        {
            Query = "SELECT TestSetup.TestName,TestSetup.Fee,TestType.TypeName FROM TestType INNER JOIN TestSetup ON TestType.TypeId=TestSetup.TypeId ORDER BY TestName";

          
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            List<TestSetupVM> tests = new List<TestSetupVM>();

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TestSetupVM test = new TestSetupVM();
                test.TestName = Reader["TestName"].ToString();
                test.Fee = (double)Reader["Fee"];
                test.TypeName = Reader["TypeName"].ToString();

                tests.Add(test);

            }
            Reader.Close();
            Connection.Close();

            return tests;

        }
    }
}