# Opdracht #3 – Principle of Least Knowledge

Volgens het principe mag een methode alleen methodes aanroepen op:
1. het object zelf,
2. objecten die als parameter worden meegegeven,
3. objecten die de methode zelf aanmaakt,
4. componenten van het object (HAS-A).

Niet toegestaan: methodes aanroepen op een object dat is **teruggegeven** door een andere methode-aanroep ("talk to strangers").

## Code 1

```csharp
public float getTemp()
{
    return station.getThermometer().getTemperature();
}
```

| Does this code violate the Principle of Least Knowledge? | **Yes** |
|---|---|
| Uitleg | `station` is een component van `House`, dus `station.getThermometer()` mag. Maar daarna wordt `getTemperature()` aangeroepen op de `Thermometer` die *teruggegeven* wordt door die aanroep. `House` praat dan met een "vreemde" en wordt afhankelijk van de interne structuur van `WeatherStation`. Beter: `WeatherStation` een eigen `getTemperature()` geven die het doorgeeft. |

## Code 2

```csharp
public float getTemp()
{
    Thermometer thermometer = station.getThermometer();
    return GetTempHelper(thermometer);
}
public float GetTempHelper(Thermometer thermometer)
{
    return thermometer.getTemperature();
}
```

| Does this code violate the Principle of Least Knowledge? | **No** (volgens de regels) |
|---|---|
| Uitleg | `getTemp()` roept alleen een methode aan op een component (`station.getThermometer()`) en op het object zelf (`GetTempHelper(...)`). `GetTempHelper()` roept alleen een methode aan op zijn eigen parameter (`thermometer.getTemperature()`). Elke aanroep valt dus binnen de toegestane regels. Kanttekening: het is eigenlijk een trucje; `House` kent `Thermometer` nog steeds en de afhankelijkheid is alleen verplaatst, niet weggehaald. |
