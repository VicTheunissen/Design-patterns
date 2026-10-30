using System;
using ExternalWhatsAppLibrary;

namespace NotificationApp
{
    // Adapter: vertaalt onze INotificationService.Send(...) naar de methode
    // SendWhatsAppMessage(...) van de externe library.
    public class WhatsAppNotificationAdapter : INotificationService
    {
        private readonly WhatsAppClient client;
        private readonly bool urgent;

        public WhatsAppNotificationAdapter()
            : this(new WhatsAppClient(), false)
        {
        }

        public WhatsAppNotificationAdapter(WhatsAppClient client, bool urgent)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.client = client;
            this.urgent = urgent;
        }

        public void Send(string recipient, string message)
        {
            // recipient = telefoonnummer, message = tekst.
            // De extra parameter 'urgent' kent onze interface niet, dus die
            // vult de adapter zelf in.
            client.SendWhatsAppMessage(recipient, message, urgent);
        }
    }
}
