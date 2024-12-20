﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Viaje
{
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

    public virtual Bus IdBusNavigation { get; set; }

    public virtual Rutum IdRutaNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}