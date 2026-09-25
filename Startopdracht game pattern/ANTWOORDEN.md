# Startopdracht GameApp – Facade Pattern

## Deel 1 – Bestuderen en runnen

De originele `Program.cs` maakt vijf subsystemen aan en roept ze in een vaste volgorde aan
(graphics → audio → save → netwerk → engine). Het programma draait zonder problemen, maar
alleen omdat er precies **één** scenario is: normaal spel starten.

## Vervolgrequirements 1 en 2 – de "naïeve" uitbreiding

Als je NormalMode, DeveloperMode en stoppen direct in `Program.cs` toevoegt, krijg je zoiets:

```csharp
static void Main(string[] args)
{
    GraphicsSystem graphics = new GraphicsSystem();
    AudioSystem audio = new AudioSystem();
    SaveSystem saveSystem = new SaveSystem();
    NetworkService network = new NetworkService();
    GameEngine gameEngine = new GameEngine();
    DebugConsole debugConsole = new DebugConsole();

    bool developerMode = Console.ReadLine() == "2";

    if (developerMode)
    {
        graphics.Initialize();
        graphics.SetResolution(1280, 720);
        audio.Initialize();
        audio.SetVolume(0);
        saveSystem.LoadSettings();
        saveSystem.LoadTestPlayer();
        network.Connect();
        network.Login();
        debugConsole.Enable();
        debugConsole.ShowFps();
        gameEngine.LoadWorld();
        gameEngine.Start();
    }
    else
    {
        graphics.Initialize();
        graphics.SetResolution(1920, 1080);
        audio.Initialize();
        audio.SetVolume(70);
        saveSystem.LoadSettings();
        saveSystem.LoadPlayer();
        network.Connect();
        network.Login();
        gameEngine.LoadWorld();
        gameEngine.Start();
    }

    Console.ReadLine();

    if (developerMode)
    {
        gameEngine.Stop();
        debugConsole.Disable();
        saveSystem.SaveSettings();
        network.Logout();
        network.Disconnect();
        audio.Shutdown();
        graphics.Shutdown();
    }
    else
    {
        gameEngine.Stop();
        saveSystem.SavePlayer();
        saveSystem.SaveSettings();
        network.Logout();
        network.Disconnect();
        audio.Shutdown();
        graphics.Shutdown();
    }
}
```

Nieuwe/uitgebreide subsystemen voor het stoppen:

| Subsysteem       | Nieuwe methodes                                            |
|------------------|------------------------------------------------------------|
| `GameEngine`     | `Stop()`, `UnloadWorld()`                                  |
| `SaveSystem`     | `SavePlayer()`, `SaveSettings()`, `LoadTestPlayer()`       |
| `NetworkService` | `Logout()`, `Disconnect()`                                 |
| `AudioSystem`    | `Shutdown()`                                               |
| `GraphicsSystem` | `Shutdown()`                                               |
| `DebugConsole`   | nieuw subsysteem: `Enable()`, `ShowFps()`, `EnableCheats()`, `WriteLogFile()`, `Disable()` |

## Vraag 3 – Welke problemen ontstaan er?

1. **Dubbele code** – de start- en stopreeks staat meerdere keren bijna identiek in `Program.cs`.
   Een wijziging (bijv. een extra subsysteem) moet je op elke plek doorvoeren, en dat vergeet je.
2. **Sterke koppeling** – de client (`Program`) kent álle subsystemen, al hun methodes én de
   juiste volgorde. Elke verandering in een subsysteem raakt direct de client.
3. **Verkeerde verantwoordelijkheid** – `Program` hoort alleen te zeggen *wat* er moet gebeuren
   ("start een game"), niet *hoe* (welke resolutie, welk volume, welke volgorde).
4. **Combinatorische explosie** – elke nieuwe optie (modus, online/offline, …) verdubbelt het
   aantal `if/else`-takken. Met 2 × 2 opties heb je al 4 start- en 4 stopvarianten.
5. **Foutgevoelig** – de volgorde doet ertoe (eerst verbinden, dan inloggen; netwerk pas
   afsluiten nadat is opgeslagen). Niets dwingt die volgorde af.
6. **Geen toestand** – niets onthoudt in welke modus de game gestart is, dus bij stoppen moet
   de client dat zelf bijhouden en opnieuw beslissen.

## Vraag 4 – Hoe los je dit op?

- Verplaats de kennis over het opstarten en afsluiten naar **één aparte class** die de
  subsystemen beheert: de `GameFacade`.
- Die class biedt een **eenvoudige interface** aan: `StartGame(mode, connection)` en `StopGame()`.
- De gemeenschappelijke stappen staan er **één keer** in; alleen wat echt verschilt per modus
  staat in een kleine `if`. Zo verdwijnt de dubbele code.
- De facade **onthoudt** met welke modus gestart is, zodat `StopGame()` zelf weet wat er
  afgesloten moet worden.
- `Program` wordt een dunne client die alleen nog de gebruiker iets laat kiezen.

## Vraag 5 / Facade 2 – Herschreven versie

Structuur van het project:

```
ConsoleApp1/
├── Program.cs              ← client: praat alleen met GameFacade
├── Facade/
│   ├── GameFacade.cs       ← StartGame(...) / StopGame()
│   ├── GameMode.cs         ← Normal | Developer
│   └── ConnectionMode.cs   ← Online | Offline
└── Subsystems/
    ├── GraphicsSystem.cs
    ├── AudioSystem.cs
    ├── SaveSystem.cs
    ├── NetworkService.cs
    ├── GameEngine.cs
    └── DebugConsole.cs
```

**Online/offline-modus**: in `StartGame` wordt `NetworkService.Connect()`/`Login()` alleen
aangeroepen bij `ConnectionMode.Online`; in `StopGame` idem voor `Logout()`/`Disconnect()`.
Bij offline wordt het netwerksubsysteem helemaal niet aangesproken. Omdat dit binnen de facade
zit, hoefde `Program` hiervoor alleen één extra keuze aan de gebruiker voor te leggen.

## Facade 3 – Controle: voldoet GameApp aan het Facade Pattern?

| Kenmerk van het Facade Pattern                                                   | In GameApp |
|----------------------------------------------------------------------------------|------------|
| Eén vereenvoudigde, hogere-niveau interface voor een complex subsysteem          | ✔ `GameFacade.StartGame()` / `StopGame()` |
| Facade *delegeert* naar de subsystemen, bevat zelf geen subsysteem-logica        | ✔ facade roept alleen methodes van subsystemen aan in de juiste volgorde |
| Subsystemen kennen de facade niet                                                | ✔ geen enkel subsysteem verwijst naar `GameFacade` |
| Subsystemen blijven los bruikbaar (facade verbergt ze niet, maar vereenvoudigt)  | ✔ alle subsystemen zijn nog `public` |
| Client is losgekoppeld van de subsystemen                                        | ✔ `Program` roept geen enkele subsysteemmethode aan; alleen de constructor krijgt ze mee (compositie, zoals in het boek met `HomeTheaterFacade`) |
| Principle of Least Knowledge ("talk only to your immediate friends")             | ✔ `Program` praat alleen met `GameFacade`; de facade alleen met zijn eigen velden |

## Facade 4 – Facade vs. Adapter

**Overeenkomsten**

- Beide zijn *structurele* patterns en werken als **wrapper**: ze stoppen bestaande classes
  "in" een nieuwe class en gebruiken compositie/delegatie.
- Beide ontkoppelen de client van de concrete classes erachter.
- Bij beide blijven de ingepakte classes zelf ongewijzigd.
- Beide kunnen meerdere classes inpakken (een adapter kán ook meer dan één adaptee hebben).

**Verschillen**

| | Adapter | Facade |
|---|---|---|
| **Doel (intent)** | Een interface **omzetten** naar een interface die de client verwacht | Een interface **vereenvoudigen** |
| **Doelinterface** | Bestaat al (`Duck`); adapter moet die implementeren | Wordt nieuw ontworpen (`StartGame`/`StopGame`) |
| **Aantal ingepakte objecten** | Meestal één (`Turkey` → `Duck`) | Meestal een heel subsysteem (6 classes) |
| **Waarom nodig** | Interfaces passen niet op elkaar | Interfaces passen wél, maar het gebruik is te complex |
| **Functionaliteit** | Vertaalt 1-op-1 (evt. `Fly()` 5×) | Combineert veel aanroepen tot één hoog-niveau actie |
| **Voorbeeld in deze repo** | `TurkeyAdapter`, `GooseAdapter` | `GameFacade` |

Kort: *een Adapter verandert een interface zodat hij past, een Facade maakt een interface
eenvoudiger.* (Een decorator voegt daarentegen gedrag toe zonder de interface te veranderen.)
