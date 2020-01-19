using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Services;
using Services.Models.ProductModels;
using Webshop.Web.Models;

namespace Webshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private IUnitofWork _unitofWork;
        public HomeController(ILogger<HomeController> logger, IProductService productService, IUnitofWork unitofWork)
        {
            _logger = logger;
            _productService = productService;
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Productos()
        {
            var result = await _productService.MostrasProductosAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]ProductModel Model)
        {
            if (Model == null)
                return StatusCode(500, new { Message = "Error input data is null" });

            if (string.IsNullOrEmpty(Model?.Category))
                return StatusCode(500, new { Message = "Category null" });

            await _productService.CrearProductoAsync(Model);

            return Ok();
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
