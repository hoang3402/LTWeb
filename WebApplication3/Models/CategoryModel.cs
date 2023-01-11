using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebApplication3.Models
{
    public class CategoryModel
    {
        private static EShopEntities db = new EShopEntities();
        //Lấy danh sách các Category
        public static List<Category> GetList()
        {
            return db.Categories.ToList();
        }

        //Lấy ID Category
        public static int GetNewCategoryId()
        {
            int newID;
            EShopEntities context = new EShopEntities();
            if (context.Categories.Count() == 0)
            {
                newID = 1;
            }
            else
            {
                var query = (from ct in context.Categories
                             orderby ct.Id descending
                             select ct).First();
                newID = query.Id + 1;
            }
            return newID;
        }
        //Lấy Chi tiết Category theo id
        public static Category GetCategoryById(int id)
        {
            return db.Categories.Find(id);
        }

        //Thêm mới Category
        public static void AddCategory(Category ct)
        {
            db.Categories.Add(ct);
            db.SaveChanges();
        }

        // Cập nhật Category
        public static void UpdateCategory(Category ct)
        {
            db.Entry(ct).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}