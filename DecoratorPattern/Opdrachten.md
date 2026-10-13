# Design Patterns – Decorator Pattern

## Doel van deze les

In deze les ga je onderzoeken hoe je bestaande software kunt uitbreiden met extra gedrag, zonder steeds classes aan te passen en zonder voor iedere combinatie een nieuwe subclass te maken.

Na deze les kun je:

- uitleggen welk probleem het Decorator Pattern oplost;
- herkennen wanneer inheritance leidt tot te veel subclasses;
- uitleggen hoe een Decorator is opgebouwd;
- zelf een Decorator maken in C#;
- meerdere Decorators combineren;
- het verschil uitleggen tussen Adapter, Facade en Decorator.

## 1. Beginsituatie

Gebruik de NotificationApp. Alle notificatieservices werken met dezelfde interface:

```csharp
namespace NotificationApp
{
    public interface INotificationService
    {
        void Send(string recipient, string message);
    }
}
```

Er zijn meerdere manieren om notificaties te versturen:

```csharp
namespace NotificationApp
{
    public class EmailNotificationService : INotificationService
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine("EMAIL");
            Console.WriteLine($"Aan: {recipient}");
            Console.WriteLine($"Bericht: {message}");
            Console.WriteLine();
        }
    }
}
```

Of bijvoorbeeld:

```csharp
namespace NotificationApp
{
    public class SmsNotificationService : INotificationService
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine("SMS");
            Console.WriteLine($"Aan: {recipient}");
            Console.WriteLine($"Bericht: {message}");
            Console.WriteLine();
        }
    }
}
```

In `Program.cs` kan bijvoorbeeld het volgende staan:

```csharp
namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INotificationService notification =
                new EmailNotificationService();

            notification.Send(
                "student@school.nl",
                "Je rooster is gewijzigd."
            );

            Console.ReadLine();
        }
    }
}
```

### Opdracht 1 – Onderzoeken

Voer de applicatie uit. Beantwoord daarna:

1. Waarom kan de variabele `notification` zowel een `EmailNotificationService` als een `SmsNotificationService` bevatten?
2. Welke interface gebruiken beide classes?
3. Welke methode moet iedere notificatieservice aanbieden?
4. Wat is het voordeel van programmeren tegen `INotificationService` in plaats van direct tegen één concrete class?

## 2. Nieuwe klantwens: Logging

De opdrachtgever wil dat sommige notificaties gelogd worden. Bijvoorbeeld:

```
LOG: notificatie wordt verstuurd
EMAIL
Aan: student@school.nl
Bericht: Je rooster is gewijzigd.
```

Een eerste oplossing zou kunnen zijn om een nieuwe class `LoggedEmailNotificationService` te maken. Deze class erft van `EmailNotificationService`.

### Opdracht 2 – Logging met inheritance

Maak `LoggedEmailNotificationService` als subclass van `EmailNotificationService`.

Zorg ervoor dat er vóór het versturen een logregel wordt getoond. Test je oplossing.

Maak daarna ook `LoggedSmsNotificationService`. Test ook deze class.

## 3. Nog een klantwens: Urgent

Sommige notificaties moeten urgent gemaakt kunnen worden. Een urgent bericht moet bijvoorbeeld worden:

```
[URGENT] Je rooster is gewijzigd.
```

Maak daarom `UrgentEmailNotificationService` en `UrgentSmsNotificationService`. Ook deze classes mogen voorlopig inheritance gebruiken.

### Opdracht 3 – Urgent notifications

Zorg ervoor dat `UrgentEmailNotificationService` en `UrgentSmsNotificationService` `[URGENT]` voor het oorspronkelijke bericht plaatsen. Test beide classes.

## 4. Logging én Urgent

Volgende wens: een notificatie moet soms zowel gelogd als urgent zijn. Met inheritance kun je nu bijvoorbeeld maken:

```
LoggedUrgentEmailNotificationService
LoggedUrgentSmsNotificationService
```

### Opdracht 4 – Denk eerst na

Schrijf nog geen code. Je hebt nu ongeveer deze structuur:

```
EmailNotificationService
LoggedEmailNotificationService
UrgentEmailNotificationService
LoggedUrgentEmailNotificationService

SmsNotificationService
LoggedSmsNotificationService
UrgentSmsNotificationService
LoggedUrgentSmsNotificationService
```

Beantwoord:

1. Hoeveel classes hebben we nu nodig?
2. Wat gebeurt er als er een derde uitbreiding bijkomt, bijvoorbeeld Timestamp?
3. Welke nieuwe combinaties zouden dan mogelijk worden?
4. Vind je inheritance hiervoor nog steeds een handige oplossing?
5. Wat is volgens jou het belangrijkste probleem van deze aanpak?

## 5. Nieuwe eis: Timestamp

De opdrachtgever kondigt aan: binnenkort willen we ook een timestamp aan berichten kunnen toevoegen. Bijvoorbeeld:

```
[14:32] Je rooster is gewijzigd.
```

Denk na over mogelijke combinaties:

```
Email
LoggedEmail
UrgentEmail
TimestampEmail
LoggedUrgentEmail
LoggedTimestampEmail
UrgentTimestampEmail
LoggedUrgentTimestampEmail
```

En hetzelfde geldt voor SMS.

### Conclusie

Inheritance werkt technisch, maar we krijgen steeds meer subclasses. Dit probleem noemen we vaak een **class explosion**.

We willen extra gedrag daarom liever los toevoegen en combineren. Daarvoor kunnen we het Decorator Pattern gebruiken.

## 6. Decorator Pattern

De kern van Decorator is: een bestaand object inpakken om extra gedrag toe te voegen.

Een Decorator:

- gebruikt dezelfde interface als het oorspronkelijke object;
- bevat zelf een ander object met diezelfde interface;
- voegt extra gedrag toe;
- geeft daarna het werk door aan het ingepakte object.

De globale structuur is:

```
                INotificationService
                         ▲
              ┌──────────┼──────────┐
              │          │          │
            Email       SMS     Decorator
                                   ▲
                             ┌─────┴─────┐
                             │           │
                          Logging      Urgent
```

Belangrijk:

```
Decorator IS-A INotificationService
```

maar ook:

```
Decorator HAS-A INotificationService
```

## 7. Basis Decorator

Maak de volgende abstracte class:

```csharp
namespace NotificationApp
{
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
```

### Opdracht 5 – Begrijpen

Beantwoord:

1. Waarom implementeert `NotificationDecorator` zelf `INotificationService`?
2. Waarom bevat `NotificationDecorator` een field van het type `INotificationService`?
3. Waarom gebruiken we hier niet `EmailNotificationService notificationService;` maar `INotificationService notificationService;`?
4. Wat is hier het verschil tussen IS-A en HAS-A?

## 8. Logging Decorator

Maak `LoggingNotificationDecorator`. Deze erft van `NotificationDecorator`. Gebruik daarvoor deze structuur:

```csharp
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
            // Voeg hier logging toe

            // Geef daarna het versturen door
            // aan notificationService
        }
    }
}
```

### Opdracht 6 – Maak LoggingDecorator af

De uitvoer moet ongeveer worden:

```
LOG: notificatie naar student@school.nl

EMAIL
Aan: student@school.nl
Bericht: Je rooster is gewijzigd.
```

Test daarna:

```csharp
INotificationService notification =
    new EmailNotificationService();

notification =
    new LoggingNotificationDecorator(notification);

notification.Send(
    "student@school.nl",
    "Je rooster is gewijzigd."
);
```

Test vervolgens dezelfde Decorator met `SmsNotificationService`.

**Vraag:** Moest je `LoggingNotificationDecorator` aanpassen om hem voor SMS te gebruiken? Leg uit waarom wel of niet.

## 9. Zelf maken: Urgent Decorator

### Opdracht 7 – UrgentNotificationDecorator

Maak `UrgentNotificationDecorator`. Eisen:

- de class erft van `NotificationDecorator`;
- het originele notificatie-object wordt via de constructor meegegeven;
- vóór het versturen wordt `[URGENT]` voor het bericht geplaatst;
- daarna wordt het bericht doorgestuurd naar het ingepakte notificatie-object.

Je mag de volgende classes NIET aanpassen:

```
INotificationService
EmailNotificationService
SmsNotificationService
```

Test bijvoorbeeld:

```csharp
INotificationService notification =
    new UrgentNotificationDecorator(
        new EmailNotificationService()
    );

notification.Send(
    "student@school.nl",
    "Je leslokaal is gewijzigd."
);
```

Verwachte uitvoer:

```
EMAIL
Aan: student@school.nl
Bericht: [URGENT] Je leslokaal is gewijzigd.
```

## 10. Decorators combineren

Een Decorator is zelf ook een `INotificationService`. Daarom kun je een Decorator ook weer in een andere Decorator stoppen. Bijvoorbeeld:

```csharp
INotificationService notification =
    new LoggingNotificationDecorator(
        new UrgentNotificationDecorator(
            new EmailNotificationService()
        )
    );
```

### Opdracht 8 – Volg de keten

Teken welke objecten elkaar aanroepen. Gebruik bijvoorbeeld:

```
Program
   ↓
...
   ↓
...
   ↓
EmailNotificationService
```

Beantwoord daarna:

1. Welke `Send()` wordt als eerste uitgevoerd?
2. Welke `Send()` wordt daarna uitgevoerd?
3. Welke class verstuurt uiteindelijk de echte e-mail?
4. Waarom kan iedere Decorator een andere Decorator bevatten?

## 11. Maakt de volgorde uit?

Onderzoek deze twee varianten.

Variant A:

```csharp
INotificationService notification =
    new LoggingNotificationDecorator(
        new UrgentNotificationDecorator(
            new EmailNotificationService()
        )
    );
```

Variant B:

```csharp
INotificationService notification =
    new UrgentNotificationDecorator(
        new LoggingNotificationDecorator(
            new EmailNotificationService()
        )
    );
```

### Opdracht 9 – Onderzoeken

1. Voer beide varianten uit.
2. Teken voor beide varianten de volgorde van aanroepen.
3. Is de volgorde hetzelfde?
4. Kan de volgorde invloed hebben op de uitvoer?
5. Leg uit waarom.

## 12. Zelfstandig: Timestamp Decorator

### Opdracht 10 – TimestampNotificationDecorator

Maak `TimestampNotificationDecorator`. Deze voegt de huidige tijd toe aan het bericht. Bijvoorbeeld:

```
[14:32] Je rooster is gewijzigd.
```

Je kunt hiervoor gebruiken:

```csharp
DateTime.Now.ToString("HH:mm")
```

Test daarna minstens deze combinatie:

```
Logging
↓
Timestamp
↓
Urgent
↓
Email
```

Maak de code waarmee je deze combinatie opbouwt. Test daarna dezelfde Decorators met SMS.

## 13. Ontwerpvraag

Je zou ook één grote methode kunnen maken:

```csharp
Send(
    recipient,
    message,
    urgent,
    logging,
    timestamp
);
```

Bijvoorbeeld:

```csharp
notification.Send(
    "student@school.nl",
    "Je rooster is gewijzigd.",
    true,
    true,
    false
);
```

### Opdracht 11 – Vergelijken

Beantwoord:

1. Wat betekent `true, true, false` als je alleen de methode-aanroep ziet?
2. Wat gebeurt er als later ook Encryption, Retry en AuditLogging bijkomen?
3. Welke class krijgt dan steeds meer verantwoordelijkheden?
4. Wat is volgens jou overzichtelijker:
   - a. veel boolean parameters;
   - b. Decorators;
   - c. of hangt dat af van de situatie?
5. Leg je antwoord uit.

## 14. Pattern Detective

Bepaal welk Design Pattern het beste past. Kies uit: Adapter, Facade, Decorator.

**Situatie A** – Een externe betaalservice heeft `MakePayment(int cents)` maar jouw applicatie verwacht `Pay(decimal euros)`.
Pattern: ............................

**Situatie B** – Voor het starten van een game moeten `GraphicsSystem`, `AudioSystem`, `SaveSystem`, `NetworkService` en `GameEngine` in de juiste volgorde worden aangeroepen. De client wil alleen `StartGame()`.
Pattern: ............................

**Situatie C** – Je wilt logging optioneel kunnen toevoegen aan verschillende bestaande services zonder die services aan te passen.
Pattern: ............................

**Situatie D** – Een bestaande externe WhatsApp-library past niet bij `INotificationService`.
Pattern: ............................

**Situatie E** – Je wilt een notificatie kunnen combineren met Urgent, Logging en Timestamp zonder voor iedere combinatie een nieuwe subclass te maken.
Pattern: ............................

## 15. Adapter, Facade en Decorator

Vul de tabel aan.

| Pattern | Welk probleem lost het op? | Korte onthoudzin |
| --- | --- | --- |
| Adapter | | |
| Facade | | |
| Decorator | | |

Gebruik daarbij deze drie begrippen:

- passend maken
- makkelijker maken
- uitbreiden

## 16. Eindopdracht

Bouw een notificatie die:

1. via SMS verstuurd wordt;
2. urgent is;
3. een timestamp bevat;
4. gelogd wordt.

Je mag bestaande notificatieclasses niet aanpassen. Je oplossing moet opgebouwd zijn uit verschillende objecten die allemaal werken via `INotificationService`.

Laat je uiteindelijke objectstructuur ook als schema zien. Bijvoorbeeld:

```
Decorator
   ↓
Decorator
   ↓
Decorator
   ↓
ConcreteNotificationService
```

Gebruik de echte classnamen uit jouw oplossing.

## Samenvatting

Onthoud:

- Adapter = passend maken
- Facade = makkelijker maken
- Decorator = gedrag toevoegen / inpakken

Bij Decorator:

```
zelfde interface
      +
object bevat ander object met dezelfde interface
      +
extra gedrag
      +
doorsturen
```

De kracht van Decorator zit vooral hierin: je kunt gedrag toevoegen en combineren zonder steeds de oorspronkelijke class aan te passen en zonder voor iedere combinatie een nieuwe subclass te maken.
