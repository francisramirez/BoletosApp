﻿

using System.ComponentModel.DataAnnotations;

namespace BoletosApp.Domain.Entities.Reservation;

public partial class Reserva
{
    [Key]
    public int IdReserva { get; set; }

    public int? IdViaje { get; set; }

    public int? IdPasajero { get; set; }

    public int? AsientosReservados { get; set; }

    public decimal? MontoTotal { get; set; }

    public DateTime? FechaCreacion { get; set; }
}