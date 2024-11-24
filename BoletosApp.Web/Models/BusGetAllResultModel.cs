using BoletosApp.Persistance.Models.Configuration;
 

namespace BoletosApp.Web.Models
{
    public class BusGetAllResultModel : BaseApiResponseModel
    {
        public List<BusModel>? data { get; set; }
      
    }
}
