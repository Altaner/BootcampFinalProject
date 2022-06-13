using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SanCamp.Data;
using SanCamp.Data.Repositories.Interfaces;
using SanCamp.Domain.Users;
using System.Linq;

namespace SanCamp.Web.Controllers
{

    public class UserController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(UserDbContext context, ILogger<UserController> logger, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _logger = logger;
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
        

        [ValidateAntiForgeryToken]
        public IActionResult AccountActivation(int? id)
        {
            var user = _context.Users.FirstOrDefault(_context => _context.Id == id);

            if (user.IsActive == true)
            {
                _context.Users.Find(user.Id).IsActive = false;
                _context.SaveChanges();
            }
            else
            {
                _context.Users.Find(user.Id).IsActive = true;
                _context.SaveChanges();
            }
            _logger.LogInformation("An user account's activation statement has been changed.");
            return RedirectToAction("Details");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
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


        public IActionResult Delete(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }


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
