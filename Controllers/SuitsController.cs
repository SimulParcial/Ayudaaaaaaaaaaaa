using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeriesAPI.Models;
using SeriesAPI.Data; // Asegúrate que tu AppDbContext esté en este namespace

namespace SeriesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuitsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SuitsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/suits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Suit>>> Get(string? personaje, string? actor)
    {
        var query = _context.Suits.AsQueryable();

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

    // GET: api/suits/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Suit>> GetById(int id)
    {
        var suit = await _context.Suits.FindAsync(id);
        if (suit == null) return NotFound();
        return Ok(suit);
    }

    // POST: api/suits
    [HttpPost]
    public async Task<ActionResult<Suit>> Create(Suit suit)
    {
        _context.Suits.Add(suit);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = suit.Id }, suit);
    }

    // PUT: api/suits/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Replace(int id, Suit suit)
    {
        if (id != suit.Id)
        {
            return BadRequest("El ID de la URL no coincide con el del objeto enviado.");
        }

        var existing = await _context.Suits.FindAsync(id);
        if (existing == null) return NotFound();

        existing.Personaje = suit.Personaje;
        existing.Actor = suit.Actor;
        existing.Edad = suit.Edad;
        existing.EstadoCivil = suit.EstadoCivil;
        existing.NetWorth = suit.NetWorth;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/suits/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _context.Suits.FindAsync(id);
        if (existing == null) return NotFound();

        _context.Suits.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}