# Singleton Pattern - Opdrachten

## Opdracht 1 - Setting up

Project opgezet vanuit de SingletonPattern.zip.

## Opdracht 2 - Implementing

De `ChocolateBoiler` is omgezet naar een Singleton:
- Constructor is `private` gemaakt
- Statisch `_instance` veld toegevoegd
- Publieke `GetInstance()` methode geeft altijd dezelfde instance terug

## Opdracht 3 - Thread safe

| Solution | Omschrijving van toepasbaarheid |
|---|---|
| **Synchronized GetInstance (lock)** | De hele `GetInstance()` methode wordt afgeschermd met een `lock`. Elke aanroep moet wachten tot de lock vrij is, ook als de instance al bestaat. **Performance:** slecht bij veel aanroepen, want elke call blokkeert op de lock, ook na initialisatie. **Maintainability:** simpel en makkelijk te begrijpen — een `lock` om de hele methode. |
| **Eager instantiation** | De instance wordt aangemaakt bij het laden van de klasse via `private static readonly ChocolateBoiler _instance = new ChocolateBoiler()`. De CLR garandeert thread-safety bij static field initialization. **Performance:** het beste, want er is geen lock nodig bij `GetInstance()`. De instance wordt altijd aangemaakt, ook als deze nooit wordt gebruikt (minimale overhead). **Maintainability:** het simpelst — geen lock-logica nodig, minder code, minder foutgevoelig. |
| **Double-checked locking** | Er wordt eerst gecontroleerd of `_instance == null` *zonder* lock. Alleen als dat zo is wordt de lock genomen en opnieuw gecheckt. Dit voorkomt onnodige locks na de eerste initialisatie. **Performance:** goed — na de eerste initialisatie is er geen lock overhead meer, alleen een null-check. **Maintainability:** complexer dan de andere oplossingen door de dubbele null-check en het gebruik van `volatile` of `lock`. Meer kans op fouten als het niet correct wordt geimplementeerd. |

### Gekozen oplossing

**Double-checked locking** is geimplementeerd in de code. Dit biedt de beste balans: lazy initialization (de instance wordt pas aangemaakt wanneer nodig) met goede performance na de eerste aanroep. Voor de ChocolateBoiler is dit een goede keuze omdat de boiler niet altijd direct nodig is bij het starten van de applicatie.

Als de applicatie de boiler altijd nodig heeft, zou **eager instantiation** de beste keuze zijn vanwege de eenvoud.
