
using BoletosApp.Domain.Base;


namespace BoletosApp.Domain.Entities.Configuration;

public partial class Ruta : BaseEntity
{
    
    public int IdRuta { get; set; }

    public string? Origen { get; set; }

    public string? Destino { get; set; }

}