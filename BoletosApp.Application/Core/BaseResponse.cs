

namespace BoletosApp.Application.Core
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
