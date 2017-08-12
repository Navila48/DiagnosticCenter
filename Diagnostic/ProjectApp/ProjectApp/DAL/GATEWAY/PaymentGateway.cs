using System;
using System.Data;
using System.Data.SqlClient;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.DAL.GATEWAY
{
    public class PaymentGateway:GateWay
    {
        public PatientForPayment GetPaymentInfo(PatientForPayment patient)
        {
            Query = "SELECT Total,Date FROM PatientRecord INNER JOIN BillingInfo ON PatientRecord.PatientId=BillingInfo.PatientId WHERE (Status='unpaid' AND MobileNo=@mobileNo) OR (Status='unpaid' AND BillNo=@billNo)";
           // Query = "SELECT Total,Date FROM PatientRecord INNER JOIN BillingInfo ON PatientRecord.PatientId=BillingInfo.PatientId WHERE (Status='unpaid' AND MobileNo='" + patient.MobileNo + "') OR (Status='unpaid' AND BillNo='" + patient.BillNo + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("mobileNo", SqlDbType.VarChar);
            Command.Parameters["mobileNo"].Value = patient.MobileNo;
            Command.Parameters.Add("billNo", SqlDbType.VarChar);
            Command.Parameters["billNo"].Value = patient.BillNo;

            Reader = Command.ExecuteReader();
            PatientForPayment aPatient = new PatientForPayment();
            while (Reader.Read())
            {


                aPatient.Total = (double)Reader["Total"];
                aPatient.DOB = (DateTime)Reader["Date"];
            }
            Reader.Close();
            Connection.Close();
            return aPatient;
        }

        public int PayAmmount(PatientForPayment patient)
        {

            Query = "UPDATE PatientRecord SET Status='paid' WHERE MobileNo='" + patient.MobileNo + "' OR BillNo='" + patient.BillNo + "'";
         //   Query = "UPDATE PatientRecord SET Status=@paid WHERE MobileNo=@mobileNo OR BillNo=@billNo";
           
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            //Command.Parameters.Clear();
            //Command.Parameters.Add("paid", SqlDbType.VarChar);
            //Command.Parameters["paid"].Value = "paid";
            //Command.Parameters.Add("mobileNo", SqlDbType.VarChar);
            //Command.Parameters["mobileNo"].Value = patient.MobileNo;
            //Command.Parameters.Add("billNo", SqlDbType.VarChar);
            //Command.Parameters["billNo"].Value = patient.BillNo;



            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}