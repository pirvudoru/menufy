using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class RecipeType : Identifiable
    {
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}