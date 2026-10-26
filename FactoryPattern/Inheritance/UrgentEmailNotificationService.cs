namespace FactoryPattern
{
    // Opdracht 3 - urgent via inheritance.
    public class UrgentEmailNotificationService
        : EmailNotificationService, INotificationService
    {
        public new void Send(string recipient, string message)
        {
            base.Send(recipient, $"[URGENT] {message}");
        }
    }
}
