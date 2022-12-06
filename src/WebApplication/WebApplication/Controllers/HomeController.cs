using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    public class WebAPI : Controller
    {
        [HttpGet("WebApi")]        
        public IActionResult Get()
        {
            
            return Ok("Hello");
        }
    }





    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClock clock;

        public HomeController(ILogger<HomeController> logger, IClock clock)
        {
            _logger = logger;
            this.clock = clock;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Hello"] = clock.GetTime().ToString("T");

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
