﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CatMash.Models;
using CatMash.Repository.Models;
using CatMash.Services;

namespace CatMash.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatmashService _catmashService;

        public HomeController(ILogger<HomeController> logger, ICatmashService catmashService)
        {
            _catmashService = catmashService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Cats firstCat = _catmashService.GetRandomCat();
            Cats secondCat = _catmashService.GetRandomCat();
            while (secondCat.Id == firstCat.Id)
            {
                secondCat = _catmashService.GetRandomCat();
            }
            ViewBag.firstCat = firstCat;
            ViewBag.secondCat = secondCat;
            return View();
        }
        public async Task<RedirectToActionResult> Vote(int id)
        {
            var cat = await _catmashService.GetByIdAsync(id);
            cat.Note += 1;
            _catmashService.Update(cat);
            return RedirectToAction("Index", "Cats");
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
