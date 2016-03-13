using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MenufyServer.Data;
using Newtonsoft.Json;

namespace MenufyServer.Services
{
    public class RecipeImporter
    {
        public void Import()
        {
            var context = ApplicationDbContext.Create();
            var filePaths = Directory.EnumerateFiles(@"C:\Projects\scraper\recipes");
            foreach (var filePath in filePaths)
            {
                var json = File.ReadAllText(filePath);
                var recipe = JsonConvert.DeserializeObject<AllRecipe>(json);
                try
                {
                    context.Recipes.Add(new Recipe
                    {
                        CaloricValue = recipe.Nutrition.Calories.Amount,
                        DefaultServings = 1,
                        Type = (RecipeType) (new Random().Next()%3),
                        PhotoUrl = recipe.Photo.GetBigImage(),
                        Title = recipe.Title,
                        Ingredients = recipe.Ingredients.Select(i => new RecipeIngredient
                        {
                            Ingredient = GetOrCreateIngredient(context, i.DisplayValue),
                            Quantity = i.Grams
                        }).ToList(),
                        Steps = recipe.Directions.Select(d => new RecipeStep
                        {
                            Ordinal = d.Ordinal,
                            Description = d.DisplayValue
                        }).ToList()
                    });

                    context.SaveChanges();
                }
                catch (Exception)
                {
                    
                }
                

            }
        }

        private Ingredient GetOrCreateIngredient(ApplicationDbContext context, string displayValue)
        {
            var ingredientName = string.Join(" ", displayValue.Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(2));
            var ingredient = context.Ingredients.FirstOrDefault(i => i.Name == ingredientName);
            if (ingredient == null)
            {
                ingredient = new Ingredient
                {
                    Name = ingredientName
                };
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            return ingredient;
        }
    }

    public class AllRecipe
    {
        public string Title { get; set; }

        public List<AllDirection> Directions { get; set; }

        public List<AllIngredient> Ingredients { get; set; }

        public AllNutrition Nutrition { get; set; }

        public AllPhoto Photo { get; set; }
    }

    public class AllPhoto
    {
        // http://images.media-allrecipes.com/userphotos/600x600/2440628.jpg
        public string photoID { get; set; }

        public string GetBigImage()
        {
            return $"http://images.media-allrecipes.com/userphotos/600x600/{photoID}.jpg";
        }
    }
    
    public class AllNutrition
    {
        public AllCallories Calories { get; set; }
    }

    public class AllCallories
    {
        public decimal Amount { get; set; }
    }

    public class AllIngredient
    {
        public string DisplayValue { get; set; }

        public decimal Grams { get; set; }
    }

    public class AllDirection
    {
        public int Ordinal { get; set; }

        public string DisplayValue { get; set; }
    }
}