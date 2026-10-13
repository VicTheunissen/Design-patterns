namespace NotificationApp
{
    public class LoggingNotificationDecorator
        : NotificationDecorator
    {
        public LoggingNotificationDecorator(
            INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(
            string recipient,
            string message)
        {
            // Extra gedrag: logging
            Console.WriteLine($"LOG: notificatie naar {recipient}");
            Console.WriteLine();

            // Daarna het versturen doorgeven aan het ingepakte object
            notificationService.Send(recipient, message);
        }
    }
}
