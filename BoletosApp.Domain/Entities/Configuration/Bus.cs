using BoletosApp.Domain.Base;

namespace BoletosApp.Domain.Entities.Configuration
{
    public sealed class Bus : BaseEntity
    {
        public int IdBus { get; set; }
        public int NumeroPlaca { get; set; }
        public string Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public bool Disponible { get; set; }

    }
}
