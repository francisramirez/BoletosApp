

namespace BoletosApp.Application.Dtos.Configuration.Ruta
{
    public class RutaBaseDto
    {
        public string? Origen { get; set; }

        public string? Destino { get; set; }

        public DateTime FechaCambio { get; set; }
        public int UsuarioCambio { get; set;}


    }
}
