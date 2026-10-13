namespace NotificationApp
{
    public class TimestampNotificationDecorator
        : NotificationDecorator
    {
        public TimestampNotificationDecorator(
            INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(
            string recipient,
            string message)
        {
            // Extra gedrag: huidige tijd voor het bericht plaatsen
            string time = DateTime.Now.ToString("HH:mm");
            notificationService.Send(recipient, $"[{time}] {message}");
        }
    }
}
