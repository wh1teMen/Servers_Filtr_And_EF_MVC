using Microsoft.AspNetCore.Mvc;
using MyprogectHW.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace MyprogectHW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static ApplicationContext? db_;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context_)
        {
            _logger = logger;
            db_ = context_;        
        }
       
        public IActionResult Index(string title)
        {
            if(title != null)
            {
                var servers1 = db_.Servers.Where(x=>x.TitleCompany == title).ToList();  
                
                var component1 = db_.Components.ToList();
                var os1 = db_.Operations.ToList();
                CollectionElement collection1 = new CollectionElement { servers = servers1, components = component1, operations = os1 };
                return View(collection1);

            }
            else
            {
                var servers = db_.Servers.ToList();
                var component = db_.Components.ToList();
                var os = db_.Operations.ToList();
                CollectionElement collection = new CollectionElement { servers = servers, components = component, operations = os };
                return View(collection);

            }

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
