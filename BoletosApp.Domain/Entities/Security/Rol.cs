using System.ComponentModel.DataAnnotations;

namespace BoletosApp.Domain.Entities.Security
{
    public class Rol
    {
        [Key]
        public int Id { get; set; } 
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
