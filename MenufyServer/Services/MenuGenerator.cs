using System.Linq;
using MenufyServer.Data;
using MenufyServer.Extensions;

namespace MenufyServer.Services
{
    public class MenuGenerator
    {
        public const int WeekDaysCount = 7;

        public Menu Generate(ApplicationUser user)
        {
            var context = ApplicationDbContext.Create();
            var availableRecipes = context.Recipes.WithoutPreviousRecipes(user);
            
            var breakfasts = availableRecipes.WithType(RecipeType.Breakfast).Take(WeekDaysCount).ToList();
            var lunches = availableRecipes.WithType(RecipeType.Lunch).Take(WeekDaysCount).ToList();
            var dinners = availableRecipes.WithType(RecipeType.Dinner).Take(WeekDaysCount).ToList();
            
            var menu = new Menu();

            for (var index = 0; index < WeekDaysCount; index++)
            {
                var dailyMenu = new DailyMenu();

                dailyMenu.Meals.Add(new Meal
                {
                    Servings = 1,
                    Recipe = breakfasts[index]
                });

                dailyMenu.Meals.Add(new Meal
                {
                    Servings = 1,
                    Recipe = lunches[index]
                });
                dailyMenu.Meals.Add(new Meal
                {
                    Servings = 1,
                    Recipe = dinners[index]
                });

                menu.DailyMenus.Add(dailyMenu);
            }
            
            return menu;
        }

    }
}