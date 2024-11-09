﻿

using BoletosApp.Infraestructure.Interfaces;
using BoletosApp.Infraestructure.Models;
using BoletosApp.Infraestructure.Results;
using Newtonsoft.Json;
using System.Text;

namespace BoletosApp.Infraestructure.Services
{
    public class SmsService : INotificacionService
    {
       
        public Task<NotificationResult> SendEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationResult> SendPushNotification(PushModel pushModel)
        {
            throw new NotImplementedException();
        }

        public async Task<NotificationResult> SendSmsAsync(SmsModel smsModel)
        {
            NotificationResult result = new NotificationResult();
            try
            {
                var httpClient = new HttpClient();

                var contect = new StringContent(JsonConvert.SerializeObject(smsModel),Encoding.UTF8,"application/json");

                await httpClient.PostAsync("miurl",contect);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
