using System.Collections.Generic;
using DiagnosticCenterApp.DAL.Model;
using ProjectApp.DAL.GATEWAY;

namespace ProjectApp.BLL
{
    public class DiagnosticManager
    {
        DiagnosticGateWay aDiagnosticGateWay=new DiagnosticGateWay();
        
        public List<TestWise> findTest(string fromDate, string toDate)
        {
            return aDiagnosticGateWay.FindTest(fromDate, toDate);
        }
    }
}