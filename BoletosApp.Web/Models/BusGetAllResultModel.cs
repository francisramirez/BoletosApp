using BoletosApp.Persistance.Models.Configuration;
 

namespace BoletosApp.Web.Models
{
    public class BusGetAllResultModel
    {
        public List<BusModel> data { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}
