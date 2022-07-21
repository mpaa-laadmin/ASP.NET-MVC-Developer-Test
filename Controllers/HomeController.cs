using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVC_WebApp_MPA.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVC_WebApp_MPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _hostEnv;

        private readonly List<State> _states = new();

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnv)
        {
            _logger = logger;

            _hostEnv = hostEnv;

            string contentRootPath = _hostEnv.ContentRootPath;
            string statesFilePath = Path.Combine(contentRootPath, "wwwroot/data/usa_states.json");
            using (StreamReader sr = new StreamReader(statesFilePath))
            {
                _states = JsonConvert.DeserializeObject<List<State>>(sr.ReadToEnd()) ?? new();
            }
        }

        public IActionResult StatesList()
        {
            return View(_states);
        }

        public IActionResult Index()
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