using CatMash.Repository.Models;
using CatMash.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Controllers
{
    public class CatsController : Controller
    {
        private readonly ICatmashService _catmashService;
        private readonly ILogger<CatsController> _logger;
        public CatsController(ICatmashService catmashService,ILogger<CatsController> logger)
        {
            _catmashService = catmashService;
            _logger = logger;
        }
        // GET: Cats
        public async Task<ActionResult> Index()
        {
            IEnumerable<Cats> cats = await  _catmashService.GetAllAsync();
            _logger.LogDebug(cats.ToList().Count.ToString());
            return View(cats.OrderByDescending(x=>x.Note));
        }

        // GET: Cats/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cats/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cats/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cats/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}