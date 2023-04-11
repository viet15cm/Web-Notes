﻿using Microsoft.AspNetCore.Mvc;
using ProjectWebNotes.DbContextLayer;
using ProjectWebNotes.Models;
using Services.Abstractions;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProjectWebNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbcontext _context;
        private readonly IServiceManager _serviceManager;
       
        public HomeController(IServiceManager serviceManager, AppDbcontext context)
        {
            _serviceManager = serviceManager;
           
            _context = context;
        }

        public  IActionResult Index()
        {
           
            

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