using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Models
{
    public class CustomerModel
    {
        static EShopEntities db = new EShopEntities();

        public static int GetID()
        {
            List<Customer> list = db.Customers.ToList();
            for (int i = 0; i < list.Count() - 1; i++)
            {
                if (list[i].Id++ != list[i++].Id)
                {
                    return list[i].Id++;
                }
            }
            return list.Count + 1;
        }
    }
}