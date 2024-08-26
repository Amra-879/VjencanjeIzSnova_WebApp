using Microsoft.AspNetCore.Mvc;
using VjencanjeIzSnova_WebApp.ViewModels;
using VjencanjeIzSnova_WebApp.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VjencanjeIzSnova_WebApp.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace VjencanjeIzSnova_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;

        public AccountController(UserManager<Korisnik> userManager, SignInManager<Korisnik> signInManager, VjencanjeIzSnovaDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //login
                var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError("", "Neuspješan pokušaj prijave!");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        //[Route("registracija")]
        public IActionResult Registracija()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registracija(RegistracijaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Korisnik
                {
                    UserName = model.Email,
                    Email = model.Email,
                    UserType = model.UserType
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var klijent = new Klijent
                    {
                        Ime = model.Ime,
                        Prezime = model.Prezime,
                        Grad = model.Grad,
                        DatumVjenčanja = model.DatumVjencanja,
                        UserId = user.Id
                    };

                    _context.Klijenti.Add(klijent);
                    await _context.SaveChangesAsync();

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error.ErrorMessage);
                }
            }

                return View(model);
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
                ? Redirect(returnUrl)
                : RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }
    }
}


