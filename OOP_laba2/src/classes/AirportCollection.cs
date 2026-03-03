using OOP_laba2.services;

namespace OOP_laba2.classes;

public delegate void ListChanged(string msg);

public class AirportCollection(List<Airport> list)
{
    public List<Airport> List = list;
    
    private readonly RandomGenerator _randomGenerator = new RandomGenerator();
    
    public event ListChanged ItemAdded;
    
    public event ListChanged ItemRemoved;


    public void Add(Airport airport)
    {
        List.Add(airport);
        ItemAdded?.Invoke($"Элемент с названием {airport.Name} добавлен" + Environment.NewLine);
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < List.Count)
        {
            List.RemoveAt(index);
            ItemRemoved?.Invoke($"Элемент с индексом {index} удален");
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void AddRandomItem()
    {
        Add(_randomGenerator.CreateRandomAirport());
    }
}