namespace MenufyServer.Data
{
    public class RecipeIngredient : Identifiable
    {
        public Ingredient Ingredient { get; set; }

        public decimal Quantity { get; set; } // grams
    }
}