using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenufyServer.Data;

namespace MenufyServer.Controllers
{
    [Route("/[controller]")]
    public class RecipeController : Controller
    {
        // GET: Recipe
        [System.Web.Mvc.HttpGet]
        [Route("/Details/{id}")]
        public ActionResult Details(int id)
        {
            var context = ApplicationDbContext.Create();
            Recipe recipe = (context.Recipes.Take(id).ToList()).First(r => r.Id == id);
            return View(recipe);
        }
    }
}