using Containers.Containers;
using Containers.Intefaces;

namespace Containers;

public class ContainerG : Container, IHazardNotifier
{
    private double _pressure;
    
    public ContainerG(int maxLoadMass, int height, int ownWeight, int depth,  int pressure) : 
        base(maxLoadMass, height, ownWeight, depth, "G")
    {
        _pressure = pressure;
    }

    public override void EmptyContainer()
    {
        LoadWeight *= 0.05;
    }

    public override void Notify(string message)
    {
        Console.WriteLine($"Dangerous situation! Container {SerialNumber}: {message}");
    }
}