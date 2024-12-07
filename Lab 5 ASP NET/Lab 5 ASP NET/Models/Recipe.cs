namespace Lab_5_ASP_NET.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Type { get; set; } 
        public TimeSpan PreparationTime { get; set; } 

        public List<RecipeComponent> Components { get; set; } = new List<RecipeComponent>();
    }
}
