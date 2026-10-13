namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Opdracht 1 - beginsituatie
            Header("Opdracht 1 - Email via INotificationService");
            INotificationService notification =
                new EmailNotificationService();

            notification.Send(
                "student@school.nl",
                "Je rooster is gewijzigd."
            );

            // Opdracht 2 - logging met inheritance
            Header("Opdracht 2 - LoggedEmailNotificationService");
            notification = new LoggedEmailNotificationService();
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            Header("Opdracht 2 - LoggedSmsNotificationService");
            notification = new LoggedSmsNotificationService();
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Opdracht 3 - urgent met inheritance
            Header("Opdracht 3 - UrgentEmailNotificationService");
            notification = new UrgentEmailNotificationService();
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            Header("Opdracht 3 - UrgentSmsNotificationService");
            notification = new UrgentSmsNotificationService();
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Opdracht 6 - LoggingNotificationDecorator
            Header("Opdracht 6 - Logging + Email");
            notification = new EmailNotificationService();
            notification = new LoggingNotificationDecorator(notification);
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            Header("Opdracht 6 - Logging + SMS");
            notification = new SmsNotificationService();
            notification = new LoggingNotificationDecorator(notification);
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Opdracht 7 - UrgentNotificationDecorator
            Header("Opdracht 7 - Urgent + Email");
            notification =
                new UrgentNotificationDecorator(
                    new EmailNotificationService()
                );
            notification.Send("student@school.nl", "Je leslokaal is gewijzigd.");

            // Opdracht 8 + 9 - decorators combineren, volgorde
            Header("Opdracht 9 - Variant A: Logging -> Urgent -> Email");
            notification =
                new LoggingNotificationDecorator(
                    new UrgentNotificationDecorator(
                        new EmailNotificationService()
                    )
                );
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            Header("Opdracht 9 - Variant B: Urgent -> Logging -> Email");
            notification =
                new UrgentNotificationDecorator(
                    new LoggingNotificationDecorator(
                        new EmailNotificationService()
                    )
                );
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            // Opdracht 10 - TimestampNotificationDecorator
            Header("Opdracht 10 - Logging -> Timestamp -> Urgent -> Email");
            notification =
                new LoggingNotificationDecorator(
                    new TimestampNotificationDecorator(
                        new UrgentNotificationDecorator(
                            new EmailNotificationService()
                        )
                    )
                );
            notification.Send("student@school.nl", "Je rooster is gewijzigd.");

            Header("Opdracht 10 - Logging -> Timestamp -> Urgent -> SMS");
            notification =
                new LoggingNotificationDecorator(
                    new TimestampNotificationDecorator(
                        new UrgentNotificationDecorator(
                            new SmsNotificationService()
                        )
                    )
                );
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // Eindopdracht - SMS, urgent, timestamp en gelogd.
            // Bestaande notificatieclasses zijn niet aangepast; alles is
            // opgebouwd uit losse objecten die INotificationService zijn.
            Header("Eindopdracht - Logging -> Urgent -> Timestamp -> SMS");
            INotificationService finalNotification =
                new LoggingNotificationDecorator(
                    new UrgentNotificationDecorator(
                        new TimestampNotificationDecorator(
                            new SmsNotificationService()
                        )
                    )
                );
            finalNotification.Send(
                "0612345678",
                "Je toets van morgen is verplaatst naar lokaal B1.12."
            );

            Console.ReadLine();
        }

        private static void Header(string title)
        {
            Console.WriteLine($"===== {title} =====");
        }
    }
}
