using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VjencanjeIzSnova_WebApp.Data;
using VjencanjeIzSnova_WebApp.Models;

namespace VjencanjeIzSnova_WebApp.Controllers.Partner_Kontroleri
{
    //[Authorize(Roles = "Partner")]
    //[Authorize(Policy = "Partner")] 
    [Route("Partner/Usluga")]
    public class PartnerUslugaController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;
        private readonly UserManager<Korisnik> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

         public PartnerUslugaController(VjencanjeIzSnovaDbContext context,UserManager<Korisnik> userManager, IWebHostEnvironment hostingEnvironment)
         {
                _context = context;
                _userManager = userManager;
                _hostingEnvironment = hostingEnvironment;
         }

         // GET: Partner/Usluga
         [HttpGet]
         [Route("index")]
         public async Task<IActionResult> Index()
         {
            var partner = await GetLoggedInPartnerAsync();
            if (partner == null) return NotFound("Partner not found");

            var vjencanjeIzSnovaDbContext = _context.Usluge
              .Include(u => u.Kategorija)
              .Include(u => u.Partner)
              .Include(u => u.Slike);
              return View(await vjencanjeIzSnovaDbContext.ToListAsync()); 

            }

            // GET: Partner/Usluga/Kreiraj
            [HttpGet]
            [Route("kreiraj")]
            public IActionResult Kreiraj()
            {
                ViewBag.Kategorija = new SelectList(_context.Kategorije, "KategorijaId", "Naziv");
                return View();
            }

            // POST: Partner/Usluga/Kreiraj
            [HttpPost]
            [Route("kreiraj")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Kreiraj([Bind("UslugaId,KategorijaId,KontaktMail,CjenovniRang,Detalji,InfoOKompaniji,Naziv,Opis")] Usluga usluga, List<IFormFile> SlikeFiles)
            {
                var partner = await GetLoggedInPartnerAsync();
                if (partner == null) return NotFound("Partner not found");

                if (ModelState.IsValid)
                {
                    usluga.PartnerId = partner.PartnerId;

                    // Spoji Detalji inpute s tačka-zarezima radi lakšeg pohranjivanja
                    usluga.Detalji = string.Join(";", Request.Form["Detalji[]"]);

                    _context.Add(usluga);
                    await _context.SaveChangesAsync();

                    // slike uploads
                    if (SlikeFiles != null && SlikeFiles.Count > 0)
                    {
                        foreach (var file in SlikeFiles)
                        {
                            if (file != null && file.Length > 0)
                            {
                                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "slikeUsluge", fileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                                var slika = new Slike
                                {
                                    Url = fileName,
                                    UslugaId = usluga.UslugaId
                                };
                                _context.Slike.Add(slika);
                            }
                        }

                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Kategorija = new SelectList(_context.Kategorije, "KategorijaId", "Naziv", usluga.KategorijaId);
                return View(usluga);
            }

            private async Task<Partner?> GetLoggedInPartnerAsync()
            {
                var user = await _userManager.GetUserAsync(User);
                return await _context.Partneri.FirstOrDefaultAsync(p => p.UserId == user.Id);
            }
        }
    }

   
