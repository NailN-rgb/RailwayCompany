using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayCompany.Data;
using RailwayCompany.Models;

namespace RailwayCompany.Controllers
{
    public class HomeController : Controller
    {
        RailwayRoutesContext db;

        public HomeController(RailwayRoutesContext context) {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.People.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            db.People.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
