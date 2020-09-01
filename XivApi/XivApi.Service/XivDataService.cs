namespace XivApi.Service
{
    using Flurl.Http;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;
    using XivApi.Models;
    using System.Data;

    public class XivDataService
    {
        public async Task<XivWeapon> GetXivWeapon()
        {
            // Makes asynchronous call to the API, response is then deserialized into JSON.
            HttpResponseMessage req = await "https://xivapi.com/Item/1675".GetAsync();
            dynamic item = JsonConvert.DeserializeObject(
                req.Content.ReadAsStringAsync().Result
            );

            // Gets the name and description from the response, and our model consumes it
            var xivWeapon = new XivWeapon
            {
                Name = item.Name_en,
                Description = item.Description
            };

            // If name of the objekt isn't null, the objekt is returned
            if (xivWeapon.Name != null) return xivWeapon;
            else { throw new NoNullAllowedException(); }
        }
    }
}
