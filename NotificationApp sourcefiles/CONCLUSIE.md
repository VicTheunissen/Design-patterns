# NotificationApp - conclusie

## Structuur

```
                 <<interface>>
              INotificationService
                        |
     +-----------+------+------+----------------------------+
     |           |             |                            |
 Email...    Sms...        Push...        WhatsAppNotificationAdapter
                                                       |
                                                       | gebruikt
                                                       v
                                          ExternalWhatsAppLibrary.
                                                 WhatsAppClient

 NotificationManager ----> INotificationService
```

## Wat is er gebeurd?

De oude `Program.cs` maakte zelf alle services aan en riep ze een voor een aan.
Nu praat `Program` alleen nog met `NotificationManager`, en die praat alleen met
`INotificationService`. Welk kanaal er gebruikt wordt, bepaalt de aanroeper met
`SetService(...)`.

## De externe WhatsAppClient

`WhatsAppClient` past niet op `INotificationService`:

| INotificationService | WhatsAppClient |
| --- | --- |
| `Send(string recipient, string message)` | `SendWhatsAppMessage(string phoneNumber, string text, bool urgent)` |

Andere methodenaam, en een extra parameter `urgent`. De manager kan hem dus niet
rechtstreeks gebruiken.

Oplossing: het **Adapter pattern**. `WhatsAppNotificationAdapter` implementeert
`INotificationService` en vertaalt binnenin `Send(recipient, message)` naar
`SendWhatsAppMessage(recipient, message, urgent)`. De `urgent`-waarde die onze
interface niet kent, vult de adapter zelf in (via de constructor).

## Conclusie: mogen we de bestaande code aanpassen?

**Kunnen we `WhatsAppClient` aanpassen?** Nee. Die code is ingekocht en is eigendom
van een externe partij; we hebben de broncode niet in beheer. Zelfs als we hem
zouden kunnen wijzigen, zijn we onze aanpassing kwijt zodra de leverancier een
nieuwe versie uitbrengt.

**Kunnen we `INotificationService` aanpassen?** Technisch wel, maar dat moet je niet
doen. Zodra je `Send` uitbreidt met bijvoorbeeld `bool urgent`, moeten
`EmailNotificationService`, `SmsNotificationService` en `PushNotificationService`
alle drie mee veranderen, terwijl die niets met "urgent" doen. Dat is een schending
van het **Open/Closed Principle**: de code hoort open te staan voor uitbreiding,
maar gesloten voor wijziging. Bovendien zou de interface zich dan aanpassen aan de
grillen van een externe library - de afhankelijkheid staat dan de verkeerde kant op.

**Dus:** we laten beide kanten met rust en zetten er een adapter tussen. Een nieuwe
klasse toevoegen (uitbreiden) in plaats van bestaande klassen wijzigen. Wil de
opdrachtgever morgen ook Telegram? Dan komt er simpelweg een tweede adapter bij en
verandert er niets aan de manager of aan de bestaande services.
