using BoletosApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletosApp.Domain.Entities.Configuration
{
    [Table("Asiento", Schema ="dbo")]
    public sealed class Asiento : BaseEntity
    {
        [Key]
        public int IdAsiento { get; set; }
        public int IdBus { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }


    }
}
