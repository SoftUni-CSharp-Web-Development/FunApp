using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Services.DataServices;
using FunApp.Services.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunApp.Web.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoriesService categoriesService;

        public IndexModel(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IEnumerable<CategoryIdAndNameViewModel> Categories { get; set; }

        public void OnGet()
        {
            this.Categories = this.categoriesService.GetAll();
        }
    }
}