using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SanCamp.Data;
using SanCamp.Domain.Models;
using SanCamp.Domain.Users;
using SanCamp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SanCamp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoginUser()
        {
            var details = _unitOfWork.LoginUsers.GetUserById(1);
            LoginUserModel loginInfo = new LoginUserModel
            {
                Agency = details.Agency,
                Password = details.Password,
                User = details.User
            };

            using (var httpClient = new HttpClient())
            {
                StringContent StringContent = new StringContent(JsonConvert.SerializeObject(loginInfo), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://service.stage.paximum.com/v2//api/authenticationservice/login", StringContent))
                {
                    TokenModel token = await response.Content.ReadAsAsync<TokenModel>();
                    if (!response.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Incorrect Token";
                        return Redirect("Home/Index");
                    }
                    HttpContext.Session.SetString("Token", token.Body.Token);
                }
                TempData["message"] = "Login Succsess";
                return  Redirect("Index");
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
