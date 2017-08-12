using ProjectApp.DAL.GATEWAY;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.BLL
{
    public class PaymentManager
    {
        PaymentGateway aPaymentGateway = new PaymentGateway();

        public PatientForPayment GetPaymentInfo(PatientForPayment patient)
        {
          

            PatientForPayment aPatient = aPaymentGateway.GetPaymentInfo(patient);
            return aPatient;

        }

        public string PayAmmount(PatientForPayment patient)
        {
            int rowAffected = aPaymentGateway.PayAmmount(patient);

            if (rowAffected > 0)
            {
                return "Successfully paid";
            }
            else
            {
                return "failed";
            }
        }
    }
}