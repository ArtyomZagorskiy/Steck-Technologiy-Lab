namespace Lab_5_ASP_NET.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public string Unit { get; set; } 
        public int Calories { get; set; }

        public Product(string name, decimal price, string unit, int calories)
        {
            Name = name;
            Price = price;
            Unit = unit;
            Calories = calories;
        }
    }
}
