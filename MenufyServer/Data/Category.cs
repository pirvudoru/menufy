using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class Category : Identifiable
    {
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}