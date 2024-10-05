

namespace BoletosApp.Persistance.Models
{
    public class AsientoBusModel
    {
        public int AsientoId { get; set; }
        public int BusId { get; set; }
        public string? Bus { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacion { get; set; }
    }
}
