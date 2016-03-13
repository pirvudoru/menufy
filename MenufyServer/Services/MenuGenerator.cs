using System;
using System.Linq;
using MenufyServer.Data;
using MenufyServer.Extensions;

namespace MenufyServer.Services
{
    public class MenuGenerator
    {
        public const decimal CalloryIncrement = 100;
        public const decimal CalloryEpsilon = 50;
        public const int WeekDaysCount = 7;

        private readonly CalloryCalculator _calloryCalculator;

        public MenuGenerator()
        {
            _calloryCalculator = new CalloryCalculator();
        }

        public Menu Generate(UserProfile user)
        {
            var context = ApplicationDbContext.Create();
            var availableRecipes = context.Recipes.WithoutPreviousRecipes(user);

            var recommendedCalloriesPerDay = GetRecommendedCallories(user);
            var breakfastRecommendedCallories = 50 * recommendedCalloriesPerDay / 100;
            var lunchRecommendedCallories = 35 * recommendedCalloriesPerDay / 100;
            var dinnerRecommendedCallories = 15 * recommendedCalloriesPerDay / 100;

            var breakfasts = availableRecipes.OfType(RecipeType.Breakfast)
                .InCalloryRange(breakfastRecommendedCallories, CalloryEpsilon)
                .Take(WeekDaysCount)
                .ToList();
            var lunches = availableRecipes.OfType(RecipeType.Lunch)
                .InCalloryRange(lunchRecommendedCallories, CalloryEpsilon)
                .Take(WeekDaysCount)
                .ToList();
            var dinners = availableRecipes.OfType(RecipeType.Dinner)
                .InCalloryRange(dinnerRecommendedCallories, CalloryEpsilon)
                .Take(WeekDaysCount)
                .ToList();

            var menu = new Menu();

            for (var index = 0; index < WeekDaysCount; index++)
            {
                var dailyMenu = new DailyMenu();

                if (breakfasts.Count > index)
                {
                    dailyMenu.Meals.Add(CreateMeal(breakfasts[index]));
                }
                if (lunches.Count > index)
                {
                    dailyMenu.Meals.Add(CreateMeal(lunches[index]));
                }
                if (dinners.Count > index)
                {
                    dailyMenu.Meals.Add(CreateMeal(dinners[index]));
                }

                menu.DailyMenus.Add(dailyMenu);
            }

            return menu;
        }

        private static Meal CreateMeal(Recipe recipe)
        {
            return new Meal
            {
                Servings = 1,
                Recipe = recipe
            };
        }

        private decimal GetRecommendedCallories(UserProfile user)
        {
            var current = _calloryCalculator.CalculateCurrentFor(user);
            var ideal = _calloryCalculator.CalculateNormalFor(user);

            var recommended = current > ideal
                ? Math.Max(ideal, current - CalloryIncrement)
                : Math.Min(ideal, current + CalloryIncrement);

            return recommended;
        }
    }
}