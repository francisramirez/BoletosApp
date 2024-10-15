using BoletosApp.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace BoletosApp.Domain.Entities.Configuration
{
    public sealed class Bus : BaseEntity
    {
        [Key]
        public int IdBus { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public bool Disponible { get; set; }

    }
}
