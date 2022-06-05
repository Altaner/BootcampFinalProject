using Microsoft.AspNetCore.Mvc;
using SanCamp.Data;
using SanCamp.Domain.Users;
using System;
using System.Linq;
using System.Net;
using Microsoft.Extensions.Logging;
using Serilog;
using SanCamp.Controllers;

namespace SanCamp.Web.Controllers
{
    
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        private readonly UserDbContext _context;
        public UserController(UserDbContext context)
        {
            _context = context;
        }

      

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details()
        {
            _logger.LogInformation("User list has been shown");
            return View(_context.Users);
        }
        //This method check if user exists before changing of users's account statement
        public IActionResult Index(int? id)
        {
            _logger.LogInformation("Checking process if user exists");
            if (id == null)
                return BadRequest();
            User user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            return View(user);
        }
        //This method changes users's account statement
        [HttpPost, ActionName("Index")]
        public IActionResult IndexPost(User user)
        {
            _logger.LogInformation("An user account's statement has been changed.");
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Details");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //This method creates new users and check required fields
        public IActionResult Create(User user)
        {
            if (user.UserName == null && user.Password == null)
                ModelState.AddModelError("username/password", "Kullanıcı adını veya şifreyi boş bırakmayın.");
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Details");
            }
            _logger.LogInformation("An user has been created.");
            return View(user);
        }
        //This method check if user exists
        public IActionResult Delete(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
        //This method delete the user
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var user = _context.Users.FirstOrDefault(_context => _context.Id == id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            _logger.LogInformation("An user has been deleted.");
            return RedirectToAction("Details");
        }
    }
}
