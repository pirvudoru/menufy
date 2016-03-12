using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MenufyServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<NutritionType> NutritionType { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
        
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<RecipeNutritionData> RecipeNutritionDatas { get; set; }

        public DbSet<RecipeStep> RecipeSteps { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<RecipeType> RecipeTypes { get; set; }
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}