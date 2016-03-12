using System;
using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class Menu : Identifiable
    {
        public DateTime FromDate { get; set; }

        public int Servings { get; set; }

        public int TotalMeals { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}