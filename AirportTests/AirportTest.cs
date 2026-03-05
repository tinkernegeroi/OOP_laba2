using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_laba2.classes;
using OOP_laba2.exceptions;

namespace AirportTests;

[TestClass]
public sealed class AirportTest
{
    private Airport airport = null!;

    [TestMethod]
    public void ZeroParamConstructor()
    {
        airport = new Airport();
        Assert.AreEqual(0, airport.EmployeesCount);
    }

    [TestMethod]
    public void OneParamConstructor()
    {
        string name = "Домодедово";
        airport = new Airport(name);
        Assert.AreEqual(name, airport.Name);
    }

    [TestMethod]
    public void TwoParamConstructor()
    {
        string name = "Шереметьево";
        string location = "Москва";
        airport = new Airport(name, location);

        Assert.AreEqual(location, airport.Location);
    }

    [TestMethod]
    public void AllParamConstructor()
    {
        string name = "Домодедово";
        string location = "Московская область";
        int flightsPerDay = 150;
        int ticketsSold = 2000;
        decimal balance = 503232106;
        double rating = 4.92;
        int employeesCount = 3124;

        airport = new Airport(name, location, flightsPerDay, ticketsSold, balance, rating, employeesCount);

        Assert.AreEqual(flightsPerDay, airport.FlightsPerDay);
        Assert.AreEqual(ticketsSold, airport.TicketsSold);
        Assert.AreEqual(balance, airport.Balance);
        Assert.AreEqual(rating, airport.Rating);
        Assert.AreEqual(employeesCount, airport.EmployeesCount);
    }

    [TestMethod]
    public void ObjectCountTest()
    {
        int count = Airport.ObjectsCount;
        var airport1 = new Airport();
        var airport2 = new Airport();
        Assert.AreEqual(count + 2, Airport.ObjectsCount);
    }

    [TestMethod]
    public void InvalidCastTest()
    {
        try
        {
            airport = new Airport("Домодедово", "Московская область", 150, 2000, -503232106, 4.92, 3124);
            Assert.Fail("Ожидалось исключение AirportInvalidCastException");
        }
        catch (AirportInvalidCastException) { }
    }

    [TestMethod]
    public void FlightsPerDayHexTest()
    {
        int flightsPerDay = 150;
        airport = new Airport("Домодедово", "Московская область", flightsPerDay, 2000, 503232106, 4.92, 3124);

        Assert.AreEqual(flightsPerDay.ToString("X"), airport.GetFlightsPerDayHex());
    }
}