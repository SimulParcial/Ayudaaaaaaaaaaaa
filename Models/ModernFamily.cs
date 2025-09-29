using System.ComponentModel.DataAnnotations;

namespace SeriesAPI.Models;

public class ModernFamily
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Personaje { get; set; } = null!;

    [Required, StringLength(80)]
    public string Actor { get; set; } = null!;

    [Range(0, 120)]
    public int Edad { get; set; }

    [Required, StringLength(30)]
    public string SignoZodiacal { get; set; } = null!;

    [Required, StringLength(30)]
    public string EstadoCivil { get; set; } = null!;
}