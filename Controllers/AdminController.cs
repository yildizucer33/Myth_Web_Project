using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Data;
using WebProje.Models;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var kartlar = await _context.MythCards.ToListAsync();
        return View(kartlar);
    }

    public IActionResult Create()
    {
        return View();
    }

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

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var kart = await _context.MythCards.FindAsync(id);
        if (kart == null) return NotFound();

        return View(kart);
    }

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
}