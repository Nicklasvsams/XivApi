namespace XivApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using XivApi.Service;

    public class XivController : Controller
    {
        public XivDataService Service { get; }

        public XivController(XivDataService service)
        {
            Service = service;
        }

        public IActionResult Index()
        {
            var xivWeapon = Service.GetXivWeapon().Result;

            return View(xivWeapon);
        }
    }
}