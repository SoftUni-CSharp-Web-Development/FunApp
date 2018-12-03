using System;
using System.Linq;
using FunApp.Services.DataServices;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FunApp.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IJokesService jokesService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IJokesService jokesService)
        {
            this.categoriesService = categoriesService;
            this.jokesService = jokesService;
        }

        public IActionResult Index()
        {
            var categories = categoriesService
                .GetAll()
                .ToList();

            return this.View(categories);
        }

        public IActionResult Details(int id, int? page)
        {
            var jokesInCategory = this.jokesService.GetAllByCategory(id).ToList();

            var nextPage = page ?? 1;

            var pagedJokes = jokesInCategory.ToPagedList(nextPage, 4);

            return this.View(pagedJokes);
        }
    }
}
