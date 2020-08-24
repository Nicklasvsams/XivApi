using Flurl.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using XivApi.Models;
using Microsoft.CSharp;
using System.Data;

namespace XivApi.Service
{
    public class XivDataService
    {
        public async Task<XivWeapon> GetXivWeapon()
        {
            HttpResponseMessage req = await "https://xivapi.com/Item/1675".GetAsync();
            dynamic item = JsonConvert.DeserializeObject(
                req.Content.ReadAsStringAsync().Result
            );


            var xivWeapon = new XivWeapon
            {
                Name = item.Name_en,
                Description = item.Description
            };


            if (xivWeapon.Name != null) return xivWeapon;
            else { throw new NoNullAllowedException(); }
        }
    }
}
