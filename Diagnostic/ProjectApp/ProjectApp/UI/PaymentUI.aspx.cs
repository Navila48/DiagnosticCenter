using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.BLL;
using ProjectApp.DAL.MODEL;
using WebApplication10.BLL;
using WebApplication10.DAL.Model;
using Patient = ProjectApp.DAL.MODEL.Patient;

namespace WebApplication10.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        PaymentManager aPaymentManager = new PaymentManager();

        PatientForPayment patient = new PatientForPayment();
        protected void searchButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text=String.Empty;
            
            patient.BillNo = billNoTextBox.Text;
            patient.MobileNo = mobileNoTextBox.Text;
            double result;
            
            if (patient.BillNo != "" || patient.MobileNo != "")
            {
                if (patient.BillNo != "" && patient.MobileNo != "")
                {
                    ClearTextBoxes();
                    messageLabel.Text = "Please Enter only one input";
                    
                }
                else
                {
                    if (((double.TryParse(patient.MobileNo, out result)) && (patient.MobileNo.Length == 11)) == false && patient.BillNo == "")
                    {
                        ClearTextBoxes();
                        messageLabel.Text = "Plz enter a valid mobile number or bill number";
                    }
                    else
                    {
                        PatientForPayment aPatient = aPaymentManager.GetPaymentInfo(patient);
                        
                        if (Math.Abs(aPatient.Total) > 0)
                        {
                            amountTextBox.Text = aPatient.Total.ToString();
                            dueDateTextBox.Text = aPatient.DOB.ToString("dd-MM-yy");
                            payButton.Enabled = true;
                        }
                        else
                        {
                            ClearTextBoxes();
                            messageLabel.Text = "The patient does not exist ";
                        }
                    }
                   
                }
            }

            else
            {
                ClearTextBoxes();
                messageLabel.Text = "Plz enter the input";
            }
           
        }

        protected void payButton_Click(object sender, EventArgs e)
        {

            PatientForPayment patient=new PatientForPayment();
            patient.BillNo = billNoTextBox.Text;
            patient.MobileNo = mobileNoTextBox.Text;

            messageLabel.Text = aPaymentManager.PayAmmount(patient);
            payButton.Enabled = false;
            ClearTextBoxes();
        }

        public void ClearTextBoxes()
        {

            amountTextBox.Text = String.Empty;
            mobileNoTextBox.Text = String.Empty;
            dueDateTextBox.Text = String.Empty;
            billNoTextBox.Text = String.Empty;
        }
    }
}