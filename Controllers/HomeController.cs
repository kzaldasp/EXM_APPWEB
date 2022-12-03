using CosumoEXMAldasKevin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace CosumoEXMAldasKevin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult Index(Imagen image, string ruta)
        {
            var resp = DataImage("http://localhost:5263/api/Img", ruta);
            image.route = ruta;

            ViewBag.text = resp;
            ViewBag.imgRoute = ruta;
            return View();
        }
        
        public static string DataImage(string apiUrl, string ruta)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var qs = "ruta=" + ruta;
            var json = api.UploadFile(apiUrl + "?" + qs, "POST", ruta);

            return Encoding.UTF8.GetString(json);
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