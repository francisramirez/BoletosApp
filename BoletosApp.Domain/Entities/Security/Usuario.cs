﻿
namespace BoletosApp.Domain.Entities.Security
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}