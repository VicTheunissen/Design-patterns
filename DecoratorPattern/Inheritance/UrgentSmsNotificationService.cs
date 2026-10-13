namespace NotificationApp
{
    // Opdracht 3 - urgent via inheritance.
    public class UrgentSmsNotificationService
        : SmsNotificationService, INotificationService
    {
        public new void Send(string recipient, string message)
        {
            base.Send(recipient, $"[URGENT] {message}");
        }
    }
}
