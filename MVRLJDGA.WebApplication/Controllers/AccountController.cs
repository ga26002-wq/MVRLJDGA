using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MVRLJDGA.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVRLJDGA.WebApplication.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly LibraryContext _context;

        public AccountController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string accountName, string accessKey)
        {
           
            var user = _context.Users.FirstOrDefault(u => u.AccountName == accountName && u.AccessKey == accessKey);

            if (user != null)
            {
                
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.AccountName) };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

              
                return RedirectToAction("Index", "Book");
            }

            
            ViewBag.Error = "Usuario o contraseña incorrectos. Verifique sus datos.";
            return View();
        }

     
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login", "Account");
        }
    }
}