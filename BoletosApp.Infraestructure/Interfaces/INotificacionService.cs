
using BoletosApp.Infraestructure.Models;
using BoletosApp.Infraestructure.Results;

namespace BoletosApp.Infraestructure.Interfaces
{
    public interface  INotificacionService
    {
        Task<NotificationResult> SendEmailAsync(EmailModel emailModel);
        Task<NotificationResult> SendSmsAsync(SmsModel smsModel);
        Task<NotificationResult> SendPushNotification(PushModel pushModel);
    }
}
