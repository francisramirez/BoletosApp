namespace BoletosApp.Application.Dtos.Configuration.Ruta
{
    public class RutaUpdateDto : RutaBaseDto
    {
        public int Id { get; set; }
        public bool Estatus { get; set; }
        public int IdRuta 
        {
            get { return this.Id; }
             
        }


    }
}
