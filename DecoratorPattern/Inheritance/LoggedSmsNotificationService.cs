namespace NotificationApp
{
    // Opdracht 2 - logging via inheritance (zie LoggedEmailNotificationService
    // voor uitleg over 'new').
    public class LoggedSmsNotificationService
        : SmsNotificationService, INotificationService
    {
        public new void Send(string recipient, string message)
        {
            Console.WriteLine("LOG: notificatie wordt verstuurd");
            base.Send(recipient, message);
        }
    }
}
