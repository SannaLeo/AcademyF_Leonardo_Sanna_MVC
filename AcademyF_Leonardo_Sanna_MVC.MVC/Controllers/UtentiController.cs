using AcademyF_Leonardo_Sanna_MVC.Core.Business;
using AcademyF_Leonardo_Sanna_MVC.MVC.Helper;
using AcademyF_Leonardo_Sanna_MVC.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AcademyF_Leonardo_Sanna_MVC.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public UtentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        // GET: UtentiController
        public ActionResult Login(string url = "/")
        {
            return View(new UtenteViewModel() { ReturnUrl = url });
        }
        [HttpPost]
        public async Task<ActionResult> Login(UtenteViewModel utenteVM)
        {
            if (utenteVM == null)
            {
                return View();
            }

            var utente = BL.GetAccount(utenteVM.Username);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteVM.Password)
                {
                    //l'utente è "autenticato"
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utente.Username),
                        new Claim(ClaimTypes.Role, utente.Ruolo.ToString()),
                    };

                    var properties = new AuthenticationProperties
                    {
                        RedirectUri = utenteVM.ReturnUrl,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) // logout dopo un'ora di inattività
                    };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );
                    return Redirect("/");

                }
                else
                {
                    ModelState.AddModelError(nameof(utenteVM.Password), "Password Errata");
                    return View(utenteVM);
                }
            }
            else
            {
                return View(utenteVM);
            }
            return View();
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UtenteViewModel utente)
        {
            if (utente == null)
            {
                ViewBag.MessaggioErrore = "Utente data invalid";
                return View("ErroriDiBusiness");
            }
            if (ModelState.IsValid)
            {
                BL.AddUtente(utente.ToUtente());
                return await Login(utente);
            }
            else
                return View(utente);
        }
    }
}
