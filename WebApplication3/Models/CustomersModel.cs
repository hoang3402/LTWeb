using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CPT.Models
{
    public class CustomersModel
    {
        static ShopElectricEntities db = new ShopElectricEntities();
        static public int GetID()
        {
            
            return db.Customers.Count()+1;
        }
    }
}