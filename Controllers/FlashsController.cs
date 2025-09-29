using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeriesAPI.Models;
using SeriesAPI.Data;

namespace SeriesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlashsController : ControllerBase
{
    private readonly AppDbContext _context;

    public FlashsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/flashs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flash>>> Get(string? personaje, string? actor)
    {
        var query = _context.Flashs.AsQueryable();

        if (!string.IsNullOrWhiteSpace(personaje))
        {
            query = query.Where(s => s.Personaje.Contains(personaje));
        }

        if (!string.IsNullOrWhiteSpace(actor))
        {
            query = query.Where(s => s.Actor.Contains(actor));
        }

        return Ok(await query.ToListAsync());
    }

    // GET: api/flashs/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Flash>> GetById(int id)
    {
        var flash = await _context.Flashs.FindAsync(id);
        if (flash == null) return NotFound();
        return Ok(flash);
    }

    // POST: api/flashs
    [HttpPost]
    public async Task<ActionResult<Flash>> Create(Flash flash)
    {
        _context.Flashs.Add(flash);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = flash.Id }, flash);
    }

    // PUT: api/flashs/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Replace(int id, Flash flash)
    {
        if (id != flash.Id)
        {
            return BadRequest("El ID de la URL no coincide con el del objeto enviado.");
        }

        var existing = await _context.Flashs.FindAsync(id);
        if (existing == null) return NotFound();

        existing.Personaje = flash.Personaje;
        existing.Actor = flash.Actor;
        existing.Edad = flash.Edad;
        existing.EstadoCivil = flash.EstadoCivil;
        existing.NetWorth = flash.NetWorth;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/flashs/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _context.Flashs.FindAsync(id);
        if (existing == null) return NotFound();

        _context.Flashs.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}