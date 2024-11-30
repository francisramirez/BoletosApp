﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Conductor
{
    public int ConductorId { get; set; }

    public string Telefono { get; set; }

    public string NumeroLicencia { get; set; }

    public DateOnly? FechaContratacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }

    public bool Estatus { get; set; }

    public virtual ICollection<ConductorBu> ConductorBus { get; set; } = new List<ConductorBu>();

    public virtual Usuario ConductorNavigation { get; set; }
}