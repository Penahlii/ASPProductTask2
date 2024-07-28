using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPProductTask2.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Product Name: ")]
        [Required(ErrorMessage = "Product Name is required !")]
        public string Name { get; set; }
        [DisplayName("Product Description:")]
        [Required(ErrorMessage = "Product Description Is Required !")]
        public string Description { get; set; }
        [DisplayName("Product Original Price: ")]
        [Required(ErrorMessage = "Price required !")]
        public double Price { get; set; }
        [DisplayName("Product Discount: ")]
        [Required(ErrorMessage = "Product Discount Is Required !")]
        [Range(1, 100, ErrorMessage = "Product Discount must be between 1 and 100 !")]
        public double Discount { get; set; }
        public string ImagePath { get; set; }

        public Product() { }
        public Product (int id, string name, string description, double price, double discount, string imagePath)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Discount = discount;
            ImagePath = imagePath;
        }

        public double GetDiscountedPrice(double discount, double price) => price - ((price * discount) / 100);

    }
}
