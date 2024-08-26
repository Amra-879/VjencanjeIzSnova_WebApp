using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VjencanjeIzSnova_WebApp.Data;
using VjencanjeIzSnova_WebApp.Models;

namespace VjencanjeIzSnova_WebApp.Controllers
{
    public class UslugaController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UslugaController(VjencanjeIzSnovaDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Usluga
        public async Task<IActionResult> Index()
        {
            var vjencanjeIzSnovaDbContext = _context.Usluge
                .Include(u => u.Kategorija)
                .Include(u => u.Partner)
                .Include(u => u.Slike);
            return View(await vjencanjeIzSnovaDbContext.ToListAsync());
        }

        // GET: Usluga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.Usluge
                .Include(u => u.Kategorija)
                .Include(u => u.Partner)
                .Include(u => u.Slike)
                .FirstOrDefaultAsync(m => m.UslugaId == id);
            if (usluga == null)
            {
                return NotFound();
            }

            return View(usluga);
        }

        // GET: Usluga/Create
        public IActionResult Create()
        {
            ViewBag.Kategorija = new SelectList(_context.Kategorije, "KategorijaId", "Naziv");
            ViewBag.Partner=new SelectList(_context.Partneri, "PartnerId", "PartnerId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UslugaId,KategorijaId,KontaktMail,CjenovniRang,Detalji,InfoOKompaniji,Naziv,Opis,PartnerId")] Usluga usluga, List<IFormFile> SlikeFiles)
        {
            if (ModelState.IsValid)
            {
                // Concatenate Detalji inputs with semicolons
                usluga.Detalji = string.Join(";", Request.Form["Detalji[]"]);

                _context.Add(usluga);
                await _context.SaveChangesAsync();

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
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Kategorija = new SelectList(_context.Kategorije, "KategorijaId", "Naziv", usluga.KategorijaId);
            ViewBag.Partner = new SelectList(_context.Partneri, "PartnerId", "PartnerId", usluga.PartnerId);
            return View(usluga);
        }



        // GET: Usluga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.Usluge.FindAsync(id);
            if (usluga == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "KategorijaId", usluga.KategorijaId);
            ViewData["PartnerId"] = new SelectList(_context.Partneri, "PartnerId", "PartnerId", usluga.PartnerId);
            return View(usluga);
        }

        // POST: Usluga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UslugaId,KategorijaId,KontaktMail,CjenovniRang,Detalji,InfoOkompaniji,Naziv,Opis,PartnerId")] Usluga usluga)
        {
            if (id != usluga.UslugaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usluga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugaExists(usluga.UslugaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "KategorijaId", usluga.KategorijaId);
            ViewData["PartnerId"] = new SelectList(_context.Partneri, "PartnerId", "PartnerId", usluga.PartnerId);
            return View(usluga);
        }

        // GET: Usluga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.Usluge
                .Include(u => u.Kategorija)
                .Include(u => u.Partner)
                .FirstOrDefaultAsync(m => m.UslugaId == id);
            if (usluga == null)
            {
                return NotFound();
            }

            return View(usluga);
        }

        // POST: Usluga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usluga = await _context.Usluge.FindAsync(id);
            if (usluga != null)
            {
                _context.Usluge.Remove(usluga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugaExists(int id)
        {
            return _context.Usluge.Any(e => e.UslugaId == id);
        }
    }
}
