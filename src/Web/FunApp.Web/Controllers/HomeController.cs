using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Data.Common;
using Microsoft.AspNetCore.Mvc;
using FunApp.Web.Models;
using FunApp.Data.Models;
using FunApp.Services.DataServices;
using FunApp.Services.Models;
using FunApp.Services.Models.Home;

namespace FunApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IJokesService jokesService;

        public HomeController(IJokesService jokesService)
        {
            this.jokesService = jokesService;
        }

        public IActionResult Index()
        {
            var jokes = this.jokesService.GetRandomJokes(20);
            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
            };

            return this.View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"My application has {this.jokesService.GetCount()} jokes.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
