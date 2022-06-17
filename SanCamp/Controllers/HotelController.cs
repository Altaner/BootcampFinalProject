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

        //Token checked by API and city search made 
        [HttpGet]
        public async Task<IActionResult> Query(QuerySearchResultModel querySearch)
        {

            if (querySearch == null || querySearch.QueryModel == null)
            {
                return View();
            }

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
                    string apiResult = await queryResult.Content.ReadAsStringAsync();
                    HotelDetailsModel result = JsonConvert.DeserializeObject<HotelDetailsModel>(apiResult);
                    QuerySearchResultModel hotelQueryResult = new QuerySearchResultModel();

                    hotelQueryResult.Cities = result.Body.Items.GroupBy(x => new { x.City.Id, x.City.Name }).Select(i => new City
                    {
                        Id = i.Key.Id,
                        Name = i.Key.Name
                    }).Distinct().ToList();

                    _logger.LogInformation("City list has returned");
                    return View(hotelQueryResult);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Query(string id)
        {
            if (id != null)
            {
                return RedirectToAction("PriceSearch", "Hotel", new { id });
            }
            return View();
        }



        // Token checked and searching hotels and prices by given city
        [HttpGet]
        public async Task<IActionResult> PriceSearch(string id)
        {
            PriceSearchModel priceSearchModel = new PriceSearchModel
            {
                ArrivalLocations = new List<ArrivalLocation>()
                {
                    new ArrivalLocation
                    {
                        Id = id.ToString()
                    }
                },
                RoomCriteria = new List<RoomCriterion>()
                {
                     new RoomCriterion()
                }
            };

            var accessToken = HttpContext.Session.GetString("Token");
            var url = "https://service.stage.paximum.com/v2/api/productservice/pricesearch";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(priceSearchModel), Encoding.UTF8, "application/json");
            using var queryResult = await client.PostAsync(url, stringContent);

            if (queryResult.IsSuccessStatusCode)
            {
                string apiResult = await queryResult.Content.ReadAsStringAsync();
                PriceSearchResultModel.Root result = JsonConvert.DeserializeObject<PriceSearchResultModel.Root>(apiResult);
                _logger.LogInformation("Hotel info and prices have returned");
                return View(result);
            }

            return View();
        }


        [HttpPost]
        public IActionResult PriceSearch(PriceSearchResultModel.Root response)
        {
            if (response != null && response.Body != null && response.Body.Hotels != null)
            {
                return View(response);
            }

            return View();
        }

    }
}
