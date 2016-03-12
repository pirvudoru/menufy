using System.Linq;
using MenufyServer.Data;

namespace MenufyServer.Extensions
{
    public static class RecipeExtensionMethods
    {
        public static IQueryable<Recipe> WithType(this IQueryable<Recipe> availableRecipes, RecipeType recipeType)
        {
            return availableRecipes.Where(r => r.Type == recipeType);
        }

        public static IQueryable<Recipe> WithoutPreviousRecipes(this IQueryable<Recipe> availableRecipes, ApplicationUser user)
        {
            var previousRecipeIds =
                user.Menus.SelectMany(m => m.DailyMenus)
                    .SelectMany(dm => dm.Meals)
                    .Select(m => m.Recipe.Id);

            return availableRecipes.Where(r => !previousRecipeIds.Contains(r.Id));
        }
    }
}