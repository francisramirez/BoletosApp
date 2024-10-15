

using System.ComponentModel.DataAnnotations;

namespace BoletosApp.Domain.Entities.Reservation;

public partial class Viaje
{

    [Key]
    public int IdViaje { get; set; }

    public int? IdBus { get; set; }

    public int? IdRuta { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public DateOnly? FechaLlegada { get; set; }

    public TimeOnly? HoraLlegada { get; set; }

    public decimal? Precio { get; set; }

    public int? TotalAsientos { get; set; }

    public int? AsientosReservados { get; set; }

    public int? AsientoDisponibles { get; set; }

    public int Completo { get; set; }

    public DateTime? FechaCreacion { get; set; }
}