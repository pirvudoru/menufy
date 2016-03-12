using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class Recipe : Identifiable
    {
        public RecipeType Type { get; set; }

        public string Title { get; set; }

        public string PhotoUrl { get; set; }

        public int DefaultServings { get; set; }

        public decimal CaloricValue { get; set; }
        
        public ICollection<RecipeStep> Steps { get; set; } 

        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}