
using System;
using System.Collections.Generic;

namespace BoletosApp.Domain.Entities.Reservation;

public partial class ReservaDetalle
{
    public int IdReservaDetalle { get; set; }

    public int? IdReserva { get; set; }

    public int? IdAsiento { get; set; }

    public DateTime? FechaCreacion { get; set; }
}