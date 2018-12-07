using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Data.Models;
using FunApp.Services.DataServices;
using FunApp.Services.Models.Jokes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace FunApp.Web.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly IJokesService jokesService;

        public DetailsModel(IJokesService jokesService)
        {
            this.jokesService = jokesService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PageNumber { get; set; }

        public IPagedList<JokeSimpleViewModel> Jokes { get; set; }

        public void OnGet()
        {
            var jokesInCategory = this.jokesService.GetAllByCategory(this.Id).ToList();
            this.Jokes = jokesInCategory.ToPagedList(this.PageNumber ?? 1, 10);
        }
    }
}