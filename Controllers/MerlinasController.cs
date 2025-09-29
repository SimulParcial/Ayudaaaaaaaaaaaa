using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeriesAPI.Data;
using SeriesAPI.Models;

namespace SeriesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MerlinasController : ControllerBase
{
    private readonly AppDbContext _context;

    public MerlinasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/merlinas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Merlina>>> GetMerlinas()
    {
        return await _context.Merlinas.AsNoTracking().ToListAsync();
    }

    // GET: api/merlinas/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Merlina>> GetMerlina(int id)
    {
        var item = await _context.Merlinas.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    // POST: api/merlinas
    [HttpPost]
    public async Task<ActionResult<Merlina>> PostMerlina(Merlina merlina)
    {
        _context.Merlinas.Add(merlina);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMerlina), new { id = merlina.Id }, merlina);
    }

    // PUT: api/merlinas/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutMerlina(int id, Merlina merlina)
    {
        if (id != merlina.Id) return BadRequest();

        _context.Entry(merlina).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MerlinaExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/merlinas/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMerlina(int id)
    {
        var item = await _context.Merlinas.FindAsync(id);
        if (item == null) return NotFound();

        _context.Merlinas.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool MerlinaExists(int id) =>
        _context.Merlinas.Any(e => e.Id == id);
}
