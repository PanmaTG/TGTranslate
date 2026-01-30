using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TGTranslate.Models;
using System.Text;
using TGTranslate.DTO;
using Newtonsoft.Json;

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
            ViewBag.Languages = new SelectList(mostUsedLanguages);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OpenAIGPT(string query, string selectedLanguage)
        {
            var openAPIkey = _configuration["OpenAI:ApiKey"];
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAPIkey}");

            var payload = new
            {
                model = "gpt-5-nano",
                messages = new object[]
                {
                    new { role = "system", content = $"Translate to {selectedLanguage}"},
                    new { role = "user", content = query }
                },
                temperature = 0,
                max_tokens = 256
            };
            string jsonPayload = JsonConvert.SerializeObject(payload);
            HttpContent httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var responseMsg = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);

            var responseMsgJson = await responseMsg.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<OpenAIResponse>(responseMsgJson);

            ViewBag.Result = response.choices[0].message.content;
            ViewBag.Languages = new SelectList(mostUsedLanguages);

            return View("Index");
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
