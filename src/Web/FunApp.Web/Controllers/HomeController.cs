using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Data.Common;
using Microsoft.AspNetCore.Mvc;
using FunApp.Web.Models;
using FunApp.Data.Models;
using FunApp.Web.Models.Home;

namespace FunApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FunAppContext context;
        private readonly IRepository<Joke> jokesRepository;

        public HomeController(IRepository<Joke> jokesRepository)
        {
            this.jokesRepository = jokesRepository;
        }

        public IActionResult Index()
        {
            var jokes = this.jokesRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(
                x => new IndexJokeViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name,
                }).Take(20);
            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
            };

            return this.View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"My application has {this.jokesRepository.All().Count()} jokes.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
