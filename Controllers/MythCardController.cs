using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Data;
using WebProje.Models;

public class MythCardController : Controller
{
    private readonly AppDbContext _context;

    public MythCardController(AppDbContext context)
    {
        _context = context;
    }

    // Tüm kartları listele
    public async Task<IActionResult> Index()
    {
        return View(await _context.MythCards.ToListAsync());
    }



    // Kart oluştur (GET)
    public IActionResult Create()
    {
        return View();
    }

    // Kart oluştur (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MythCard kart)
    {
        if (ModelState.IsValid)
        {
            _context.Add(kart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(kart);
    }

    // Kart düzenle (GET)
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var kart = await _context.MythCards.FindAsync(id);
        if (kart == null) return NotFound();

        return View(kart);
    }

    // Kart düzenle (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MythCard kart)
    {
        if (id != kart.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(kart);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MythCards.Any(e => e.Id == kart.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(kart);
    }

    // Kart silme onay sayfası
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var kart = await _context.MythCards.FirstOrDefaultAsync(m => m.Id == id);
        if (kart == null) return NotFound();

        return View(kart);
    }

    // Kartı sil (POST)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var kart = await _context.MythCards.FindAsync(id);
        if (kart != null)
        {
            _context.MythCards.Remove(kart);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // türlere göre sayfaları ayırdım
    public async Task<IActionResult> Nordik()
    {
        var kartlar = await _context.MythCards
            .Where(m => m.MitolojiTuru == "Nordik")
            .ToListAsync();
        return View("nordik", kartlar);
    }

    public async Task<IActionResult> Greek()
    {
        var kartlar = await _context.MythCards
            .Where(m => m.MitolojiTuru == "Greek")
            .ToListAsync();
        return View("greek", kartlar);
    }

    public async Task<IActionResult> Egypt()
    {
        var kartlar = await _context.MythCards
            .Where(m => m.MitolojiTuru == "Egypt")
            .ToListAsync();
        return View("egypt", kartlar);
    }
}
