namespace WebApplication3.Models
{
    public class Cart
    {
        private readonly EShopEntities db = new EShopEntities();
        public Product product;
        public int Amount;
        public double Total
        {
            get => (double)product.UnitPrice * Amount;
        }

        public Cart(int ProductId)
        {
            product = db.Products.Find(ProductId);
            Amount = 1;
        }

        public bool Find(int ProductId)
        {
            if (product.Id == ProductId)
            {
                return true;
            }
            return false;
        }
    }
}