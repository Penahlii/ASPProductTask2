using ASPProductTask2.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ASPProductTask2.Services
{
    public class DataService
    {
        public List<Product> Products;

        public DataService()
        {
            this.Products = new List<Product>
            {
                new Product(1, "Avocado Toast", "Whole grain toast topped with avocado", 6.5, 10, "/images/productImages/Avocado Toast.png"),
                new Product(2, "Bagel With Cream Cheese", "Fresh bagel topped with cream cheese", 2.99, 5, "/images/productImages/Bagel with Cream Cheese.png"),
                new Product(3, "Breakfast Buritto", "Burrito filled with eggs, cheese, and salsa", 8.0, 15, "/images/productImages/Breakfast Burrito.png"),
                new Product(4, "Chia Pudding", "Chia seeds soaked in almond milk", 7.0, 10, "/images/productImages/Chia Pudding.png"),
                new Product(5, "French Toast", "French toast with powdered sugar", 5.5, 20, "/images/productImages/French Toast.png"),
                new Product(6, "Fruit Salad", "Fresh seasonal fruit salad", 3.5, 5, "/images/productImages/Fruit Salad.png"),
                new Product(7, "Granola Bowl", "Granola served with yogurt and honey", 6.0, 10, "/images/productImages/Granola Bowl.png"),
                new Product(8, "Omelette", "Eggs with hollandaise sauce", 9.0, 15, "/images/productImages/Omelette.png"),
                new Product(9, "Pancakes", "Fluffy pancakes with maple syrup", 2.5, 10, "/images/productImages/Pancakes.png"),
                new Product(10, "Smoothie", "Mixed berry smoothie with yogurt", 4.0, 5, "/images/productImages/Smoothie.png")
            };
        }

        public List<Product> GetProducts()
        {
            return this.Products;
        }

        public void DeleteProductById(int id)
        {
            var product = this.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product != null)
                this.Products.Remove(product);
        }

        public void AddNewProduct(Product product)
        {
            if (product != null)
            {
                product.ImagePath = "/images/productImages/Smoothie.png"; // Add default picture
                this.Products.Add(product);
            }
        }
        public void UpdateProduct(Product updatedProduct)
        {
            var existingProduct = this.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Discount = updatedProduct.Discount;
            }
        }
    }
}
