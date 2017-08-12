using System.Collections.Generic;
using ProjectApp.DAL.GATEWAY;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway aTestTypeGateway = new TestTypeGateway();
        public string SaveTestType(TestType aTestType)
        {



            bool isTypeExist = aTestTypeGateway.IsTestTypeExist(aTestType);

            if (isTypeExist)
            {
                return "Test Type already exists";
            }

            else
            {
                int rowAffected = aTestTypeGateway.SaveTestType(aTestType);
                if (rowAffected > 0)
                {
                    return "Test type successfully saved.";
                }
                else
                {
                    return "Saving failed";
                }
            }

        }

        public List<TestType> GetAllTestTypes()
        {
            return aTestTypeGateway.GetAllTestTypes();
        }
    }
}