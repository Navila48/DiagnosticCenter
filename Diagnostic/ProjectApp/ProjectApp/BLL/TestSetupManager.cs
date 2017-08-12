using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.GATEWAY;
using ProjectApp.DAL.MODEL;
using WebApplication10.DAL.Model;

namespace WebApplication10.BLL
{
    public class TestSetupManager
    {
        TestSetupGateway aTestSetupGateway = new TestSetupGateway();
        public string SaveTest(TestSetup aTestSetup)
        {
            bool isTestExist = aTestSetupGateway.IsTestNameExist(aTestSetup);

            if (aTestSetup.TestName != null)
            {
                if (isTestExist)
                {
                    return "Test Name already exists.";
                }
                else
                {
                    int rowAffected = aTestSetupGateway.SaveTest(aTestSetup);

                    if (rowAffected > 0)
                    {
                        return "Successfully Saved";
                    }
                    else
                    {
                        return "Saving failed";
                    }
                }

            }
            else
            {
                return "Plz Enter the textfield correctly ";
            }


        }
        public List<TestSetupVM> GetAllTestDetails()
        {
            return aTestSetupGateway.GetAllTestDetails();
        }
    }
}