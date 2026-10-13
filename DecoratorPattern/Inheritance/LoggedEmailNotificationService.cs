namespace NotificationApp
{
    // Opdracht 2 - logging via inheritance.
    // Send() in EmailNotificationService is niet virtual en die class mogen we
    // niet aanpassen. Daarom implementeren we INotificationService opnieuw en
    // verbergen we Send() met 'new'. Een aanroep via INotificationService komt
    // dan in deze versie terecht.
    public class LoggedEmailNotificationService
        : EmailNotificationService, INotificationService
    {
        public new void Send(string recipient, string message)
        {
            Console.WriteLine("LOG: notificatie wordt verstuurd");
            base.Send(recipient, message);
        }
    }
}
