using System.Collections.Generic;
using System.Data.SqlClient;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.DAL.GATEWAY
{
    public class TestTypeGateway:GateWay
    {
        public int SaveTestType(TestType aTestType)
        {
            Query = "INSERT INTO TestType VALUES ('" + aTestType.TypeName +
            "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsTestTypeExist(TestType aTestType)
        {
            Query = "SELECT * FROM TestType WHERE TypeName = '" + aTestType.TypeName + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;
        }

        public List<TestType> GetAllTestTypes()
        {

            Query = "SELECT * FROM TestType";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<TestType> testTypes = new List<TestType>();

            while (Reader.Read())
            {
                TestType aTestType = new TestType();
                aTestType.Id = (int)Reader["TypeId"];
                aTestType.TypeName = Reader["TypeName"].ToString();
                testTypes.Add(aTestType);
            }
            Reader.Close();
            Connection.Close();
            return testTypes;
        }
    }
}