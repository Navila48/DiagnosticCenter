using System.Collections.Generic;
using System.Text.RegularExpressions;
using DiagnosticCentreWebApp.DAL.Model;
using ProjectApp.DAL.GATEWAY;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.BLL
{
    public class TestManager
    {
        TestGateway aTestGateway = new TestGateway();
        public string Save(string name)
        {

            int n;
            bool a = int.TryParse(name,out n);
            if (name != " ")
            {
                if (a == false)
                {
                    if (aTestGateway.IsTestTypeExist(name) == false)
                    {
                        int rowAffected = aTestGateway.Save(name);
                        if (rowAffected >= 0)
                        {
                            return "Save Successfull";
                        }

                        return "Save Unsuccessfull";
                    }

                    return "Type Name already exist ";
                }

                return "Type Name is invalid";
            }
            return "Type Name is empty";
        }


        public List<TestType> GetAllTestTypes()
        {
           return aTestGateway.GetAllTestTypes();
        }

        public List<TypeWiseReportVM> FindType(string fromDate, string toDate)
        {
            return aTestGateway.FindType(fromDate, toDate);
        }
    }
}