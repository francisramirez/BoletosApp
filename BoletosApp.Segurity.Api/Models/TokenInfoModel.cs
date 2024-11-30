namespace BoletosApp.Segurity.Api.Models
{
    public record TokenInfoModel
    {
        public string? Token { get; set; }
        public DateTime? Expires { get; set; }
    }
}
