namespace NotificationApp
{
    // Basis Decorator:
    // IS-A  INotificationService -> kan overal gebruikt worden waar een notificatie verwacht wordt
    // HAS-A INotificationService -> het ingepakte object waar het werk naartoe gaat
    public abstract class NotificationDecorator
        : INotificationService
    {
        protected INotificationService notificationService;

        public NotificationDecorator(
            INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public abstract void Send(
            string recipient,
            string message);
    }
}
