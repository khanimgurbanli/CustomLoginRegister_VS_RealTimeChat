using LoginRegister.Data;
using LoginRegister.Models;
using LoginRegister.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.RegularExpressions;

namespace LoginRegister.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db) => this._db = db;


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            var dbUser = _db.Users.FirstOrDefault(x => x.Password == user.Password && ( x.Email == user.EmailorUserName || x.Username==user.EmailorUserName));
            if (dbUser == null) return View("NotFoundAccount");

            HttpContext.Session.SetString("username", dbUser.Username);
            if (HttpContext.Session.GetString("username") != null)
            {
                TempData["Username"] = dbUser.Username;
                return RedirectToAction("Welcame", "Account");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registration() => View();

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel user)
        {
            if (user.Username == null || user.Password == null || user.Email == null)
                return View();

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var dbUser = _db.Users.FirstOrDefault(x => x.Username == user.Username || x.Email == user.Email);
            if (dbUser == null)
            {
                User userMap = new User();
                userMap.Username = user.Username;
                userMap.Email = user.Email;
                userMap.Password = user.Password;

                _db.Users.Add(userMap);
                _db.SaveChanges();

                _db.UserRole.Add(
                    new UserRole
                    {
                        UserId = userMap.Id,
                        RoleId = 1
                    });
                _db.SaveChanges();
            }
            else
            {
                return View("AlreadyExciting");
            }

            return View("CompletedRegistration");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Welcame()
        {
            if (HttpContext.Session.GetString("username") == null) return RedirectToAction("Login");
            return View();
        }

        public IActionResult Chat()
        {
            if (HttpContext.Session.GetString("username") == null) return RedirectToAction("Login");
            return View();
        }
    }
}


