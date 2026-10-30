using System;

namespace NotificationApp
{
    // De manager (client) kent alleen de interface INotificationService.
    // Hij weet dus niet OF en HOE er een e-mail, sms, push of WhatsApp verstuurd wordt.
    public class NotificationManager
    {
        private INotificationService service;

        public NotificationManager(INotificationService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this.service = service;
        }

        // Hiermee kan de app tijdens het draaien van kanaal wisselen.
        public void SetService(INotificationService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this.service = service;
        }

        public void Send(string recipient, string message)
        {
            service.Send(recipient, message);
        }
    }
}
