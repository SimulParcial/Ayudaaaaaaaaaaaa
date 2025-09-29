using Microsoft.EntityFrameworkCore;
using SeriesAPI.Models;

namespace SeriesAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
     
    public DbSet<Merlina> Merlinas { get; set; }
    public DbSet<ModernFamily> ModernFamilies { get; set; }
}