using OOP_laba2.classes;

namespace OOP_laba2.services;

public class RandomGenerator
{
    private static readonly string[] Names = { "Шереметьево", "Домодедово", "Внуково", "Пулково", "Кольцово" };
    private static readonly string[] Locations = { "Москва", "Санкт-Петербург", "Екатеринбург", "Казань", "Новосибирск" };
    private readonly Random _random = new Random();

    public Airport CreateRandomAirport()
    {
        return new Airport(
            name: Names[_random.Next(Names.Length)],
            location: Locations[_random.Next(Locations.Length)],
            flightsPerDay: _random.Next(10, 200),
            ticketsSold: _random.Next(100, 5000),
            balance: (decimal)(_random.NextDouble() * 1_000_000),
            rating: Math.Round(_random.NextDouble() * 5, 1),
            employeesCount: _random.Next(50, 2000)
        );
    }
}