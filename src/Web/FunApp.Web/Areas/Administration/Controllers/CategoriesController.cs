using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FunApp.Data.Common;
using FunApp.Data.Models;
using FunApp.Services.DataServices;
using FunApp.Web.Areas.Administration.Models.Categories;
using FunApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FunApp.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdministrationBaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRepository<Category> categories;

        public CategoriesController(
            ICategoriesService categoriesService, IRepository<Category> categories)
        {
            this.categoriesService = categoriesService;
            this.categories = categories;
        }

        public IActionResult Index()
        {
            var categories = categoriesService
                .GetAll()
                .ToList();

            return this.View(categories);
        }

        public IActionResult Create() => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            var newCategory = Mapper.Map<Category>(model);
            await this.categories.AddAsync(newCategory);
            await this.categories.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) => this.View();

        [HttpPost]
        public IActionResult Edit(EditCategoryInputModel model)
        {
            return null;
        }

        public IActionResult Delete(int id) => this.View();

        [HttpPost]
        public IActionResult Delete(DeleteCategoryInputModel model)
        {
            return null;
        }
    }
}
