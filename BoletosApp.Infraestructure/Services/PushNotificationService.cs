

using BoletosApp.Infraestructure.Interfaces;
using BoletosApp.Infraestructure.Models;
using BoletosApp.Infraestructure.Results;

namespace BoletosApp.Infraestructure.Services
{
    public class PushNotificationService : INotificacionService
    {
        public Task<NotificationResult> SendEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationResult> SendPushNotification(PushModel pushModel)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationResult> SendSmsAsync(SmsModel smsModel)
        {
            throw new NotImplementedException();
        }
    }
}
