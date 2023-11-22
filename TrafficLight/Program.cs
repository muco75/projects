using System;

class TrafficLight
{
    // Kleur eigenschappen van het verkeerslichtobject
    public string Red { get; private set; }
    public string Yellow { get; private set; }
    public string Green { get; private set; }

    // Huidige kleur van het verkeerslicht
    private string currentColor;

    // Constructor om de kleuren in te stellen
    public TrafficLight()
    {
        Red = "Red";
        Yellow = "Yellow";
        Green = "Green";
        currentColor = Red; // Begin met de rode kleur
    }

    // Methode om de huidige kleur op te halen
    public string GetCurrentColor()
    {
        return currentColor;
    }

    // Methode om naar de volgende kleur over te schakelen
    public void NextState()
    {
        if (currentColor == Red)
        {
            currentColor = Yellow;
        }
        else if (currentColor == Yellow)
        {
            currentColor = Green;
        }
        else
        {
            currentColor = Red;
        }
    }
}

class Program
{
    static void Main()
    {
        TrafficLight trafficLight = new TrafficLight();

        // Toon de initiële staat
        Console.WriteLine($"Kleur van het verkeerslicht: {trafficLight.GetCurrentColor()}");

        // Oneindige lus wachtend op Enter-toets
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                trafficLight.NextState();
                Console.WriteLine($"Kleur van het verkeerslicht: {trafficLight.GetCurrentColor()}");
            }
        }
    }
}
