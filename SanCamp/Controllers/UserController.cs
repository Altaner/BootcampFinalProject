using Microsoft.AspNetCore.Mvc;
using SanCamp.Data;
using SanCamp.Domain.Users;
using System;
using System.Linq;
using System.Net;

namespace SanCamp.Web.Controllers
{
    public class UserController : Controller
    {
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
            return View(_context.Users);
        }
        //This method check if user exists before changing of users's account statement
        public IActionResult Index(int? id)
        {
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

            return RedirectToAction("Details");
        }
    }
}
