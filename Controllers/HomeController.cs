using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PG_Management_MongoDB.Models;
using PG_Management_MongoDB.Services;

namespace PG_Management_MongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TenantServices _tenantServices;
        public HomeController(ILogger<HomeController> logger,TenantServices _tenantServices)
        {
            _logger = logger;
            this._tenantServices = _tenantServices;
        }

        public IActionResult Index()
        {
            return View(_tenantServices.GetUnpaid());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}