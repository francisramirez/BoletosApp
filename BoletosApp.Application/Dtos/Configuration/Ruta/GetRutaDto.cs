 

namespace BoletosApp.Application.Dtos.Configuration.Ruta
{
    public class GetRutaDto
    {
        public int Id { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public DateTime Fecha { get; set; }
    }
}
