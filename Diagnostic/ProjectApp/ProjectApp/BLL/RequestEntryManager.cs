using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.GATEWAY;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.BLL
{
    public class RequestEntryManager
    {
        DiagnosticCenterGateWay aCenterGateWay=new DiagnosticCenterGateWay();
        public List<TestSetup> GetTestNameList()
        {
           return aCenterGateWay.GetTestNameList();
        }

        public string SavePatient(Patient aPatient)
        {
            if (aPatient.MobileNo.Length == 11)
            {
                
                {
                    if (IsNumberExist(aPatient) == true)
                    {
                        int rowAffected = aCenterGateWay.SavePatient(aPatient);
                        if (rowAffected > 0)
                        {
                            return "successful";
                        }
                        else
                        {
                            return "error occured";
                        }

                    }
                    else
                    {
                        return " Mobile number already exist";
                    }
                }
               
            }
            return "Mobile no must be 11 digit";
        }

        public string SaveBillingInfo(TestData aData)
        {
           int testId = aCenterGateWay.FindTestId(aData);
            int patientId = aCenterGateWay.FindPatientId(aData);
            DateTime date = aData.Date;
            int rowAffected = aCenterGateWay.SaveBillingInfo(testId, patientId, date);
            if (rowAffected > 0)
            {
                return "successfully added";
            }
            else
            {
                return "error occured";
            }
        }

        public bool IsNumberExist(Patient aPatient)
        {
            return aCenterGateWay.IsNumberExist(aPatient);
        }

        public double GetFee(string test)
        {
            return aCenterGateWay.GetFee(test);
        }
    }
}