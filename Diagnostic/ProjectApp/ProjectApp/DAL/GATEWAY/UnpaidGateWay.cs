using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.DAL.GATEWAY
{
    public class UnpaidGateWay:GateWay
    {
       
        public List<Patient> GetUnPaidBiilInfo(UnPaidBill unPaidBill )
        {
            Query = "SELECT DISTINCT BillNo,NameOfPatient, MobileNo, Total FROM PatientRecord INNER JOIN BillingInfo ON PatientRecord.PatientId=BillingInfo.PatientId WHERE Status='unpaid' AND Date BETWEEN @fromdate AND @todate";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("fromdate", SqlDbType.DateTime);
            Command.Parameters["fromdate"].Value = unPaidBill.FromDate;
            Command.Parameters.Add("todate", SqlDbType.DateTime);
            Command.Parameters["todate"].Value = unPaidBill.ToDate;
            Reader = Command.ExecuteReader();
            List<Patient> aList = new List<Patient>();
           
            while (Reader.Read())
            {
              Patient aPatient = new Patient();
                aPatient.PatientName = Reader["NameOfPatient"].ToString();

                aPatient.BillNo = Reader["BillNo"].ToString();

                aPatient.MobileNo = Reader["MobileNo"].ToString();
                aPatient.Total = (double) Reader["Total"];
                
                aList.Add(aPatient);
            }
            Connection.Close();
            return aList;
        }

      
    }
}