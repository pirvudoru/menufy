using System.Linq;
using MenufyServer.Data;

namespace MenufyServer.Extensions
{
    public static class RecipeExtensionMethods
    {
        public static IQueryable<Recipe> OfType(this IQueryable<Recipe> availableRecipes, RecipeType recipeType)
        {
            return availableRecipes.Where(r => r.Type == recipeType);
        }

        public static IQueryable<Recipe> InCalloryRange(this IQueryable<Recipe> availableRecipes, decimal calloryCount, decimal eps)
        {
            var minLimit = calloryCount - eps;
            var maxLimit = calloryCount - eps;

            return availableRecipes.Where(r => r.CaloricValue > minLimit && r.CaloricValue < maxLimit);
        }

        public static IQueryable<Recipe> WithoutPreviousRecipes(this IQueryable<Recipe> availableRecipes, UserProfile user)
        {
            var previousRecipeIds =
                user.Menus.SelectMany(m => m.DailyMenus)
                    .SelectMany(dm => dm.Meals)
                    .Select(m => m.Recipe.Id);

            return availableRecipes.Where(r => !previousRecipeIds.Contains(r.Id));
        }
    }
}