
using BoletosApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoletosApp.Domain.Entities.Configuration;

[Table("Ruta")]
public partial class Ruta : BaseEntity
{
    [Key]
    public int IdRuta { get; set; }

    public string? Origen { get; set; }

    public string? Destino { get; set; }

}