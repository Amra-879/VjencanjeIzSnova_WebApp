using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VjencanjeIzSnova_WebApp.Data;
using VjencanjeIzSnova_WebApp.Models;

namespace VjencanjeIzSnova_WebApp.Controllers.Admin_Kontroleri

{
    [Route("Admin/Partner")]
    public class PartnerController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;
        private readonly UserManager<Korisnik> _userManager;

        public PartnerController(VjencanjeIzSnovaDbContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var vjencanjeIzSnovaDbContext = _context.Partneri
              .Include(u => u.Kategorija);
            return View(await _context.Kategorije.ToListAsync());

        }

        // GET: Partner/Create
        [HttpGet]
        [Route("dodaj")]
        public IActionResult Dodaj()
        {
            ViewBag.Kategorija = new SelectList(_context.Kategorije, "KategorijaId", "Naziv");
            return View();
            //return View("~/Views/Admin/Partner/Dodaj.cshtml");
        }

        // POST: Partner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("dodaj")]
        public async Task<IActionResult> Dodaj(Partner partner, string password)
        {
            if (ModelState.IsValid)
            {
                // Kreiraj novog korisnika
                var korisnik = new Korisnik
                {
                    Email = partner.User.Email,
                    UserName = partner.User.Email,
                    UserType = "Partner"
                };

                
                var result = await _userManager.CreateAsync(korisnik, password);

                if (result.Succeeded)
                {
                    // povezivanje tabela
                    partner.UserId = korisnik.Id;

                    // dodaj novog Partnera u bazu
                    _context.Partneri.Add(partner);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index)); 
                }

               
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //ViewBag.KategorijeList = await _context.Kategorije.ToListAsync();
            return View();
        }
    }
}
