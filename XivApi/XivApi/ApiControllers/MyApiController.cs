using Microsoft.AspNetCore.Mvc;
using XivApi.Models;
using XivApi.Service;

namespace XivApi.Website.ApiControllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MyApiController : ControllerBase
    {
        public XivDataService Service { get; }

        public MyApiController(XivDataService service)
        {
            Service = service;
        }


        [HttpGet]
        public IActionResult GetMyApi()
        {
            var myApiWeapon = Service.GetXivWeapon();

            return this.Ok(myApiWeapon);
        }
    }
}