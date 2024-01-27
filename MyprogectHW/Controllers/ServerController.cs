using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyprogectHW.Models;
using System.Diagnostics;

namespace MyprogectHW.Controllers
{
    public class ServerController : Controller
    {
        private readonly ILogger<ServerController> _logger;
        public static ApplicationContext db;
        public ServerController(ILogger<ServerController> logger,ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet]
        public IActionResult CreateServer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateServer(Server server)
        {
            db.Servers.Add(server);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateServer");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                
                var serv = await db.Servers.FirstOrDefaultAsync(s => s.Id == id);
                if (serv != null)
                {
                    return View(serv);
                }
            }
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Server server)
        {
            db.Servers.Update(server);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit");
        }




        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var serv = await db.Servers.FirstOrDefaultAsync(s => s.Id == id);
                if (serv != null)
                {
                    db.Servers.Remove(serv);
                    await db.SaveChangesAsync();
                    return RedirectToAction("index","home");
                }
            }
            return RedirectToAction("Edit");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
