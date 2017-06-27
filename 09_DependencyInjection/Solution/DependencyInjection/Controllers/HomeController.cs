using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Services;
using Microsoft.Extensions.Logging;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISampleInterface _sampleService;
        private readonly ILogger _logger;

        public HomeController(ISampleInterface sampleService, ILoggerFactory loggerFactory)
        {
            _sampleService = sampleService;
            _logger = loggerFactory.CreateLogger<ManageController>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public int Number()
        {
            return _sampleService.GetNumber();
        }
    }
}
