using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GenericUnitOfWork.Models;
using GenericUnitOfWork.UoW;
using GenericUnitOfWork.BussinesLogic.Services;
using GenericUnitOfWork.Data;
using Microsoft.Extensions.Options;
using GenericUnitOfWork.UoW.Normal;

namespace GenericUnitOfWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericUnitOfWork<ITestOneService, ApplicationDbContext> _service;
        private readonly IGenericUnitOfWork<ITestTwoService, ApplicationDbContext> _twoService;
        private readonly IOptions<Test> _options;
        private readonly IUnitOfWork _allservices;

        public HomeController(IGenericUnitOfWork<ITestOneService, ApplicationDbContext> service,
            IGenericUnitOfWork<ITestTwoService, ApplicationDbContext> twoSevice,
            IOptions<Test> options,
            IUnitOfWork allservices)
        {
            _service = service;
            _options = options;
            _twoService = twoSevice;
            _allservices = allservices;
        }

        public async Task<IActionResult> Index()
        {
            //First example
            // ViewBag.Name = await _service.GetRepository<TestOneService>().GetUserName();
            //Second example
            ViewBag.Name = await _twoService.GetRepository<TestTwoService>(new List<object> { _options }).GetUserName();

            //ViewBag.Name = await _allservices.TestOneService.GetUserName();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
