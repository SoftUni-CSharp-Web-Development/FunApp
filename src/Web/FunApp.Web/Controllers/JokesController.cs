using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Services.DataServices;
using FunApp.Services.MachineLearning;
using FunApp.Services.Models.Jokes;
using FunApp.Web.Model.Jokes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FunApp.Web.Controllers
{
    public class JokesController : BaseController
    {
        private readonly IJokesService jokesService;
        private readonly ICategoriesService categoriesService;
        private readonly IJokesCategorizer jokesCategorizer;

        public JokesController(
            IJokesService jokesService,
            ICategoriesService categoriesService,
            IJokesCategorizer jokesCategorizer)
        {
            this.jokesService = jokesService;
            this.categoriesService = categoriesService;
            this.jokesCategorizer = jokesCategorizer;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameAndCount,
                });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJokeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.jokesService.Create(input.CategoryId, input.Content);
            return this.RedirectToAction("Details", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var joke = this.jokesService.GetJokeById<JokeDetailsViewModel>(id);
            return this.View(joke);
        }

        [HttpPost]
        public SuggestCategoryResult SuggestCategory(string joke)
        {
            var category = this.jokesCategorizer.Categorize("MlModels/JokesCategoryModel.zip", joke);
            var categoryId = this.categoriesService.GetCategoryId(category);
            return new SuggestCategoryResult { CategoryId = categoryId ?? 0, CategoryName = category };
        }

        [HttpPost]
        public object RateJoke(int jokeId, int rating)
        {
            var rateJoke = this.jokesService.AddRatingToJoke(jokeId, rating);
            if (!rateJoke)
            {
                return Json($"An error occurred while processing your vote");
            }
            var successMessage = $"You successfully rated the joke with rating of {rating}";
            return Json(successMessage);
        }
    }

    public class SuggestCategoryResult
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
