using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VjencanjeIzSnova_WebApp.Data;
using VjencanjeIzSnova_WebApp.Models;

namespace VjencanjeIzSnova_WebApp.Controllers
{
    public class PartnerController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;
        private readonly UserManager<Korisnik> _userManager;

        public PartnerController(VjencanjeIzSnovaDbContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Partner/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new PartnerViewModel
            {
                KategorijeList = await _context.Kategorije.ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Partner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new user
                var korisnik = new Korisnik
                {
                    Email = model.Email,
                    UserName = model.Email,
                    UserType = model.UserType,
                };

                // Use UserManager to create the user (this will handle password hashing)
                var result = await _userManager.CreateAsync(korisnik, model.Password);

                if (result.Succeeded)
                {
                    // Create a new partner
                    var partner = new Partner
                    {
                        UserId = korisnik.Id,
                        Ime = model.Ime,
                        Mobitel = model.Mobitel,
                        KategorijaId = model.KategorijaId
                    };

                    _context.Partneri.Add(partner);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index)); // Redirect to a different action/view
                }

                // If user creation failed, add errors to ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If model state is invalid, reload categories and return view with the model
            model.KategorijeList = await _context.Kategorije.ToListAsync();
            return View(model);
        }
    }
}
