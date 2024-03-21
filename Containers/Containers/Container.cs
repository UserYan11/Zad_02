using Containers.Exceptions;

namespace Containers.Containers;

public abstract class Container
{
    public double LoadWeight { get; set; } // masa ładunku
    public double Height { get; set; } // wysokość kontenera
    public double OwnWeight { get; set; } // własna waga kontenera
    public double Depth { get; set; } // głębokość kontenera
    public string SerialNumber { get; set; } // numer seryjny
    protected double MaxLoadMass { get; set; } // maksymalna ładowność 
    private static int _numberForSerialNumber = 0;
    private readonly string _containerType;

    public Container(int maxLoadMass, int height, int ownWeight, int depth, string containerType)
    {
        LoadWeight = 0;
        MaxLoadMass = maxLoadMass;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        _containerType = containerType;
        SerialNumber = GenerateSerialNumber();
    }
    
    protected string GenerateSerialNumber()
    {
        string serialNumber = $"KON-{_containerType}-{_numberForSerialNumber}";
        _numberForSerialNumber++;
        return serialNumber;
    }
    
    public virtual void EmptyContainer()
    {
        LoadWeight = 0;
    }
    
    public virtual void LoadContainer(int weight)
    {
        if (weight > MaxLoadMass)
        {
            throw new OverfillException("Cargo weight exceeds container capacity");
        }
        LoadWeight = weight;
    }

    public virtual void Notify(string message)
    {
        Console.WriteLine(message);
    }
}