namespace Lab_5_ASP_NET.Models
{
    public class RecipeComponent
    {
        public int Id { get; set; }
        public Product Product { get; set; } 
        public double Quantity { get; set; } 

        public RecipeComponent()
        {
        }

        public RecipeComponent(Product product, double quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
