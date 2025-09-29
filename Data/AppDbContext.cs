using Microsoft.EntityFrameworkCore;
using SeriesAPI.Models;

namespace SeriesAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Flash> Flashs { get; set; }
    public DbSet<Suit> Suits { get; set; }
}