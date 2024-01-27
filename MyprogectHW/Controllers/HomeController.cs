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
       
        public IActionResult Index(string title,string sort="asc",string change="comp")
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

                switch (sort)
                    {
                        case "asc": servers = servers.OrderBy(x => x.TitleCompany).ToList(); break;
                        case "desc": servers = servers.OrderByDescending(x => x.TitleCompany).ToList(); break;
                        default: break;
                    }

                switch (change)
                {
                    case "comp": if (sort == "asc")
                        {servers = servers.OrderBy(x => x.TitleCompany).ToList();}
                        if (sort == "desc") { servers = servers.OrderByDescending(x => x.TitleCompany).ToList();}
                        break;
                    case "model":
                        if (sort == "asc")
                        { component = component.OrderBy(x => x.TitleModel).ToList();}
                        if (sort == "desc") { component = component.OrderByDescending(x => x.TitleModel).ToList(); }
                        break;
                    case "term":
                        if (sort == "asc")
                        { servers = servers.OrderBy(x => x.Expiration_date).ToList(); }
                        if (sort == "desc") { servers = servers.OrderByDescending(x => x.Expiration_date).ToList(); }
                        break;
                    case "osy":
                        if (sort == "asc")
                        { os = os.OrderBy(x => x.TitleOS).ToList(); }
                        if (sort == "desc") { os = os.OrderByDescending(x => x.TitleOS).ToList(); }
                        break;
                }
                
               
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
