

namespace BoletosApp.Application.Dtos.Configuration.Bus
{
    public sealed class BusUpdateDto : BusDtoBase
    {
         
        public int IdBus { get; set; }
        public bool Estatus { get; set; }
        
    }
}
