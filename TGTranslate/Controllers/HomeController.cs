using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TGTranslate.Models;

namespace TGTranslate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly List<string> mostUsedLanguages = new List<string>()
        {
            "English",
            "Spanish",
            "French",
            "German",
            "Chinese",
            "Japanese",
            "Russian",
            "Portuguese",
            "Italian",
            "Arabic",
            "Indonesian",
            "Vietnamese",
            "Korean",
            "Turkish",
            "Hindi"
        };

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, HttpClient httpClient)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetGPTResponse(string query, string selectedLanguage)
        {
            var openAPIkey = _configuration["OpenAI:ApiKey"];

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAPIkey}");
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
