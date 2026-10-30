namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // De manager start met e-mail als notificatiekanaal.
            NotificationManager manager =
                new NotificationManager(new EmailNotificationService());

            manager.Send(
                "student@school.nl",
                "Je nieuwe rooster staat klaar."
            );

            manager.SetService(new SmsNotificationService());
            manager.Send(
                "0612345678",
                "Je les begint over 15 minuten."
            );

            manager.SetService(new PushNotificationService());
            manager.Send(
                "student123",
                "Er staat nieuwe feedback voor je klaar."
            );

            // De externe WhatsApp-library gaat via de adapter naar binnen.
            // De manager merkt hier niets van.
            manager.SetService(new WhatsAppNotificationAdapter());
            manager.Send(
                "0687654321",
                "Je toets van morgen is verplaatst naar lokaal B1.12."
            );

            manager.SetService(new WhatsAppNotificationAdapter(
                new ExternalWhatsAppLibrary.WhatsAppClient(), true));
            manager.Send(
                "0687654321",
                "LET OP: je les van vandaag is geannuleerd."
            );

            Console.ReadLine();
        }
    }
}
