using System;
using System.Collections.Generic;
using System.Text;
using ExternalWhatsAppLibrary;


namespace ExternalWhatsAppLibrary
{
    public class WhatsAppClient
    {
        public void SendWhatsAppMessage(
            string phoneNumber,
            string text,
            bool urgent)
        {
            Console.WriteLine("EXTERNE WHATSAPP SERVICE");
            Console.WriteLine($"Telefoonnummer: {phoneNumber}");
            Console.WriteLine($"Tekst: {text}");
            Console.WriteLine($"Urgent: {urgent}");
            Console.WriteLine();
        }
    }
}

namespace NotificationApp
{
    public class NotificationManager
    {
        private readonly INotificationService _notificationService;

        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void SendNotification(string recipient, string message)
        {
            _notificationService.Send(recipient, message);
        }
    }

    public class WhatsAppNotificationAdapter : INotificationService
    {
        private readonly WhatsAppClient _whatsAppClient;
        private readonly bool _urgent;

        public WhatsAppNotificationAdapter(WhatsAppClient whatsAppClient, bool urgent)
        {
            _whatsAppClient = whatsAppClient;
            _urgent = urgent;
        }

        public void Send(string recipient, string message)
        {
            _whatsAppClient.SendWhatsAppMessage(recipient, message, _urgent);
        }
    }
}
