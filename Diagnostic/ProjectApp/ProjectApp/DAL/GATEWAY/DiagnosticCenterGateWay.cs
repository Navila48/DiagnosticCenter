using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.DAL.GATEWAY
{
    public class DiagnosticCenterGateWay:GateWay
    {
        public List<TestSetup> GetTestNameList()
        {
            Query = "SELECT * FROM TestSetup ";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TestSetup> newList= new List<TestSetup>();
            while (Reader.Read())
            {
                TestSetup newTestSetup = new TestSetup();
                newTestSetup.TestId = (int)Reader["TestId"];
                newTestSetup.TestName = (string) Reader["TestName"];
                newTestSetup.Fee = (double) Reader["Fee"];
                newTestSetup.TypeId = (int) Reader["TypeId"];
                newList.Add(newTestSetup);
            }
            Connection.Close();
            return newList;
        }

        public int FindTestId(TestData aData)
        {
            Query = "SELECT TestId FROM TestSetup WHERE TestName=@name";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aData.TestName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                int testId =(int)Reader["TestId"];
                Connection.Close();
                return testId;
            }
            else
            {
                Connection.Close();
                return 0;
            }
        }

        public int FindPatientId(TestData aData)
        {
            Query = "SELECT PatientId FROM PatientRecord WHERE MobileNo=@mobile";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("mobile", SqlDbType.VarChar);
            Command.Parameters["mobile"].Value = aData.MobileNo;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                int patientId = (int)Reader["PatientId"];
                Connection.Close();
                return patientId;
            }
            else
            {
                Connection.Close();
                return 0;
            }
        }

        public int SavePatient(Patient aPatient)
        {
            Query = "INSERT INTO PatientRecord VALUES(@name,@dob,@mobileno,@billno,@status,@total)";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aPatient.PatientName;
            Command.Parameters.Add("dob", SqlDbType.DateTime);
            Command.Parameters["dob"].Value = aPatient.DOB;
            Command.Parameters.Add("mobileno", SqlDbType.VarChar);
            Command.Parameters["mobileno"].Value = aPatient.MobileNo; 
            Command.Parameters.Add("billno", SqlDbType.VarChar);
            Command.Parameters["billno"].Value = aPatient.BillNo;
            Command.Parameters.Add("status", SqlDbType.VarChar);
            Command.Parameters["status"].Value = "unpaid";
            Command.Parameters.Add("total", SqlDbType.VarChar);
            Command.Parameters["total"].Value = aPatient.Total;
            int rowAffected=Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int SaveBillingInfo(int testId, int patientId, DateTime date)
        {
            Query = "INSERT INTO BillingInfo VALUES(@testid,@patientid,@date)";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("testid",SqlDbType.Int);
            Command.Parameters["testid"].Value = testId;
            Command.Parameters.Add("patientid", SqlDbType.Int);
            Command.Parameters["patientid"].Value = patientId;
            Command.Parameters.Add("date",SqlDbType.VarChar);
            Command.Parameters["date"].Value = date;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsNumberExist(Patient aPatient)
        {
            Query = "SELECT MobileNo FROM PatientRecord WHERE MobileNo=@mobileno";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("mobileno", SqlDbType.VarChar);
            Command.Parameters["mobileno"].Value = aPatient.MobileNo;
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return false;
            }
            Connection.Close();
            return true;
        }

        public double GetFee(string test)
        {
            Query = "SELECT Fee FROM TestSetup WHERE TestName=@name";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = test;
            Reader = Command.ExecuteReader();
            double s=0;
            if (Reader.Read())
            {
                s = (double) Reader["Fee"];
            }
            Connection.Close();
            return s;
        }
    }
}