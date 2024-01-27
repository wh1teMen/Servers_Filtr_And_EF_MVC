using Microsoft.AspNetCore.Mvc;
using MyprogectHW.Models;
using System.Diagnostics;

namespace MyprogectHW.Controllers
{
    public class ServerOperationSystemController : Controller
    {
        private readonly ILogger<ServerOperationSystemController> _logger;
        public static ApplicationContext db;

        public ServerOperationSystemController(ILogger<ServerOperationSystemController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }
        [HttpGet]
        public IActionResult CreateOS()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOS(ServerOperationSystem OS)
        {
            db.Operations.Add(OS);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateOS");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
