using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_laba2.classes;

namespace AirportTests;

[TestClass]
public class AirportCollectionTests
{
    private AirportCollection _collection = null!;

    [TestInitialize]
    public void Setup()
    {
        _collection = new AirportCollection();
    }

    // --- Add ---

    [TestMethod]
    public void Add_ShouldIncreaseCount()
    {
        var airport = new Airport("Шереметьево");
        _collection.Add(airport);

        Assert.AreEqual(1, _collection.GetItemCount());
    }

    [TestMethod]
    public void Add_ShouldStoreCorrectAirport()
    {
        var airport = new Airport("Домодедово", "Москва");
        _collection.Add(airport);

        Assert.AreEqual("Домодедово", _collection.List[0].Name);
        Assert.AreEqual("Москва", _collection.List[0].Location);
    }

    [TestMethod]
    public void Add_ShouldFireItemAddedEvent()
    {
        var airport = new Airport("Внуково");
        string? receivedMessage = null;

        _collection.ItemAdded += msg => receivedMessage = msg;
        _collection.Add(airport);

        StringAssert.Contains(receivedMessage, "Внуково");
    }

    [TestMethod]
    public void Add_MultipleAirports_ShouldIncreaseCountCorrectly()
    {
        _collection.Add(new Airport("A"));
        _collection.Add(new Airport("B"));
        _collection.Add(new Airport("C"));

        Assert.AreEqual(3, _collection.GetItemCount());
    }

    // --- Remove ---

    [TestMethod]
    public void Remove_ShouldDecreaseCount()
    {
        _collection.Add(new Airport("Шереметьево"));
        _collection.Remove(0);

        Assert.AreEqual(0, _collection.GetItemCount());
    }

    [TestMethod]
    public void Remove_ShouldFireItemRemovedEvent()
    {
        _collection.Add(new Airport("Пулково"));
        string? receivedMessage = null;

        _collection.ItemRemoved += msg => receivedMessage = msg;
        _collection.Remove(0);

        StringAssert.Contains(receivedMessage, "0");
    }

    [TestMethod]
    public void Remove_WithNegativeIndex_ShouldThrowIndexOutOfRangeException()
    {
        _collection.Add(new Airport("Шереметьево"));

        try
        {
            _collection.Remove(-1);
            Assert.Fail("Ожидалось исключение IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException) { }
    }

    [TestMethod]
    public void Remove_WithIndexEqualToCount_ShouldThrowIndexOutOfRangeException()
    {
        _collection.Add(new Airport("Шереметьево"));

        try
        {
            _collection.Remove(1);
            Assert.Fail("Ожидалось исключение IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException) { }
    }

    [TestMethod]
    public void Remove_FromEmptyCollection_ShouldThrowIndexOutOfRangeException()
    {
        try
        {
            _collection.Remove(0);
            Assert.Fail("Ожидалось исключение IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException) { }
    }

    // --- GetItemCount ---

    [TestMethod]
    public void GetItemCount_EmptyCollection_ShouldReturnZero()
    {
        Assert.AreEqual(0, _collection.GetItemCount());
    }

    [TestMethod]
    public void GetItemCount_AfterAddAndRemove_ShouldReturnCorrectCount()
    {
        _collection.Add(new Airport("A"));
        _collection.Add(new Airport("B"));
        _collection.Remove(0);

        Assert.AreEqual(1, _collection.GetItemCount());
    }

    // --- AddRandomItem ---

    [TestMethod]
    public void AddRandomItem_ShouldIncreaseCount()
    {
        _collection.AddRandomItem();

        Assert.AreEqual(1, _collection.GetItemCount());
    }

    [TestMethod]
    public void AddRandomItem_ShouldAddNonNullAirport()
    {
        _collection.AddRandomItem();

        Assert.IsNotNull(_collection.List[0]);
    }
}