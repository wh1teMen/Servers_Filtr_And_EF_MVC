using Microsoft.AspNetCore.Mvc;
using MyprogectHW.Models;
using System.Diagnostics;

namespace MyprogectHW.Controllers
{
    public class ComponentController : Controller
    {
        private readonly ILogger<ComponentController> _logger;
        public static ApplicationContext db;
        public ComponentController(ILogger<ComponentController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet]
        public IActionResult CreateComponent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComponent(ServerComponents components)
        {
            db.Components.Add(components);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateComponent");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
