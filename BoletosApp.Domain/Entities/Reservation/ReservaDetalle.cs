

using System.ComponentModel.DataAnnotations;

namespace BoletosApp.Domain.Entities.Reservation;

public partial class ReservaDetalle
{
    [Key]
    public int IdReservaDetalle { get; set; }

    public int? IdReserva { get; set; }

    public int? IdAsiento { get; set; }

    public DateTime? FechaCreacion { get; set; }
}