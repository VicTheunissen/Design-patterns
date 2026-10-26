namespace FactoryPattern
{
    public class UrgentNotificationDecorator
        : NotificationDecorator
    {
        public UrgentNotificationDecorator(
            INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(
            string recipient,
            string message)
        {
            // Extra gedrag: [URGENT] voor het bericht plaatsen,
            // daarna doorsturen met het aangepaste bericht
            notificationService.Send(recipient, $"[URGENT] {message}");
        }
    }
}
