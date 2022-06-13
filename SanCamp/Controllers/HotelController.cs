using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SanCamp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SanCamp.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        public HotelController(ILogger<HotelController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Query(string id)
        {
            if (id != null)
            {
                var x = 10;
                RedirectToAction("PriceSearch", "Hotel", new { id });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Query(QuerySearchResultModel querySearch)
        {
            
            if (querySearch != null && querySearch.QueryModel != null)
            {

                if (ModelState.IsValid)
                {
                    var accessToken = HttpContext.Session.GetString("Token");
                    var url = "https://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete";
                    HttpClient client = new HttpClient();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(querySearch.QueryModel), Encoding.UTF8, "application/json");

                    using var queryResult = await client.PostAsync(url, stringContent);
                    if (queryResult.IsSuccessStatusCode)
                    {
                        string apiResult =await queryResult.Content.ReadAsStringAsync();
                        HotelDetailsModel result = JsonConvert.DeserializeObject<HotelDetailsModel>(apiResult);
                        QuerySearchResultModel hotelQueryResult = new QuerySearchResultModel();

                        hotelQueryResult.Cities = result.Body.Items.GroupBy(x => new { x.City.Id, x.City.Name }).Select(i => new City
                        {
                            Id = i.Key.Id,
                            Name = i.Key.Name
                        }).Distinct().ToList();


                        return View(hotelQueryResult);
                    }
                }
            }
            return View();
        }
    }
}
