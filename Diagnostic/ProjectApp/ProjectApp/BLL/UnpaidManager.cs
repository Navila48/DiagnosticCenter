using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.GATEWAY;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.BLL
{
    public class UnpaidManager
    {
        public List<Patient> GetUnPaidBiilInfo(UnPaidBill aBill)
        {
            UnpaidGateWay aGateWay = new UnpaidGateWay();


            return aGateWay.GetUnPaidBiilInfo( aBill);
           
           
        }

       
    }
}