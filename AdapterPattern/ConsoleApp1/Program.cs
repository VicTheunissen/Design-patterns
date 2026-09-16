using ExternalWhatsAppLibrary;

namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationManager emailManager =
                new NotificationManager(new EmailNotificationService());

            NotificationManager smsManager =
                new NotificationManager(new SmsNotificationService());

            NotificationManager pushManager =
                new NotificationManager(new PushNotificationService());

            NotificationManager whatsAppManager =
                new NotificationManager(
                    new WhatsAppNotificationAdapter(new WhatsAppClient(), true));


            emailManager.SendNotification(
                "student@school.nl",
                "Je nieuwe rooster staat klaar."
            );

            smsManager.SendNotification(
                "0612345678",
                "Je les begint over 15 minuten."
            );

            pushManager.SendNotification(
                "student123",
                "Er staat nieuwe feedback voor je klaar."
            );

            whatsAppManager.SendNotification(
                "0612345678",
                "Je les van morgen is verplaatst."
            );


            Console.ReadLine();
        }
    }
}
