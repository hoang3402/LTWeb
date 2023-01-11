using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Models
{
    public class ProductModel
    {
        private static EShopEntities db = new EShopEntities();
        //Lấy danh sách Product
        public static List<Product> GetList_Product()
        {
            return db.Products.ToList();
        }
        //Lấy danh sách Product theo id category
        public static List<Product> GetList_Product(int id)
        {
            return db.Products
                     .Where(item => item.CategoryId == id)
                     .ToList();
        }
        //Lấy Product cuối cùng
        public static Product GetProductLast()
        {
            return db.Products.OrderByDescending(item => item.CategoryId).FirstOrDefault();
        }
        //Lấy ProductID mới
        public static int GetNewProductId()
        {
            int newID;
            EShopEntities context = new EShopEntities();
            if (context.Products.Count() == 0)
            {
                newID = 1;
            }
            else
            {
                var query = (from pro in context.Products
                             orderby pro.Id descending
                             select pro).First();
                newID = query.Id + 1;
            }
            return newID;
        }
        // Lấy chi tiết Product
        public static Product GetProducDetail(int id)
        {
            return db.Products.Find(id);
        }

        //Add Product
        public static void AddProduct(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
        }
    }
}