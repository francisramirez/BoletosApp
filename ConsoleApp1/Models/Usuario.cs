﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombres { get; set; }

    public string Apellidos { get; set; }

    public string Correo { get; set; }

    public string Clave { get; set; }

    public string TipoUsuario { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }

    public bool Estatus { get; set; }

    public virtual Conductor Conductor { get; set; }
}