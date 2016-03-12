using System.Collections.Generic;
using System.Linq;
using MenufyServer.Data;

namespace MenufyServer.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            CreateIngredients(context);
            CreateRecipeTypes(context);
            CreateNutritionTypes(context);
            CreateRecipes(context);
            
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private static void CreateRecipes(ApplicationDbContext context)
        {
            for (var index = 0; index < 20; index++)
            {
                context.Recipes.Add(new Recipe
                {
                    RecipeType = context.RecipeTypes.First(),
                    Ingredients = context.Ingredients.Take(3).Select(i => new RecipeIngredient
                    {
                        Ingredient = i,
                        Quantity = 4.2m
                    }).ToList(),
                    DefaultServings = 42,
                    NutritionData = context.NutritionType.ToList().Select(type => new RecipeNutritionData
                    {
                        NutritionType = context.NutritionType.ToList()[index],
                        Amount = 42m,
                        PercentOfDailyValue = 10
                    }).ToList(),
                    PhotoUrl = "http://www.healthyfoodteam.com/wp-content/uploads/2014/02/Healthy-Foodd.jpg",
                    Steps = new List<RecipeStep>
                    {
                        new RecipeStep
                        {
                            Ordinal = 1,
                            Description =
                                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                        },
                        new RecipeStep
                        {
                            Ordinal = 2,
                            Description =
                                "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature"
                        },
                        new RecipeStep
                        {
                            Ordinal = 3,
                            Description =
                                "discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32."
                        }
                    }
                });
            }
        }

        private static void CreateNutritionTypes(ApplicationDbContext context)
        {
            for (var index = 0; index < 20; index++)
            {
                context.NutritionType.AddOrUpdate(new NutritionType
                {
                    Name = $"Fat{index}",
                    Unit = "kcal"
                });
            }
        }

        private static void CreateRecipeTypes(ApplicationDbContext context)
        {
            for (var index = 0; index < 20; index++)
            {
                context.RecipeTypes.AddOrUpdate(new RecipeType
                {
                    Name = $"Main/Desert{index}"
                });
            }
        }

        private static void CreateIngredients(ApplicationDbContext context)
        {
            for (var index = 0; index < 20; index++)
            {
                context.Ingredients.AddOrUpdate(new Ingredient
                {
                    Name = $"Ingredient{index}"
                });
            }
        }
    }
}
