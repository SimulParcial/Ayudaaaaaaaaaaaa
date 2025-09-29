using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeriesAPI.Data;
using SeriesAPI.Models;

namespace SeriesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModernFamiliesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ModernFamiliesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/modernfamilies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ModernFamily>>> GetModernFamilies()
    {
        return await _context.ModernFamilies.AsNoTracking().ToListAsync();
    }

    // GET: api/modernfamilies/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ModernFamily>> GetModernFamily(int id)
    {
        var item = await _context.ModernFamilies.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    // POST: api/modernfamilies
    [HttpPost]
    public async Task<ActionResult<ModernFamily>> PostModernFamily(ModernFamily modernFamily)
    {
        _context.ModernFamilies.Add(modernFamily);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetModernFamily), new { id = modernFamily.Id }, modernFamily);
    }

    // PUT: api/modernfamilies/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutModernFamily(int id, ModernFamily modernFamily)
    {
        if (id != modernFamily.Id) return BadRequest();

        _context.Entry(modernFamily).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ModernFamilyExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/modernfamilies/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteModernFamily(int id)
    {
        var item = await _context.ModernFamilies.FindAsync(id);
        if (item == null) return NotFound();

        _context.ModernFamilies.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ModernFamilyExists(int id) =>
        _context.ModernFamilies.Any(e => e.Id == id);
}
