namespace SeriesAPI.Models;

public class Suit
{
    public int Id { get; set; }
    public string Personaje { get; set; } = null!;
    public string Actor { get; set; } = null!;
    public int Edad { get; set; }
    public string EstadoCivil { get; set; } = null!; // e.g. Soltero, Casado
    public decimal NetWorth { get; set; } // Valor en millones o moneda definida
}