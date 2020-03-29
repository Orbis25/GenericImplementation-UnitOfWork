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

namespace GenericUnitOfWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<ITestOneService, ApplicationDbContext> _service;
        private readonly IUnitOfWork<ITestTwoService, ApplicationDbContext> _twoService;

        private readonly IOptions<Test> _options;
        public HomeController(IUnitOfWork<ITestOneService, ApplicationDbContext> service,
            IUnitOfWork<ITestTwoService, ApplicationDbContext> twoSevice, IOptions<Test> options)
        {
            _service = service;
            _options = options;
            _twoService = twoSevice;
        }

        public async Task<IActionResult> Index()
        {
            //First example
            //ViewBag.Name = await _service.GetRepository<TestOneService>().GetUserName();
            //Second example
            ViewBag.Name = await _twoService.GetRepository<TestTwoService>(new List<object> { _options }).GetUserName();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
