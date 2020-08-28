using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCoreProduct.Data;
using NetCoreProduct.Models;

namespace NetCoreProduct.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductRepository _productRepository;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IConfiguration configuration)
        {
            _logger = logger;
            _productRepository = productRepository;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["Host"] = _configuration["HOSTNAME"];
            return View(_productRepository.Products);
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
