using Containers.Containers;
using Containers.Intefaces;

namespace Containers;

public class ContainerL : Container, IHazardNotifier
{

    private readonly bool _isHazardous;

    public ContainerL(int maxLoadMass, int height, int ownWeight, int depth, bool isHazardous) :
        base(maxLoadMass, height, ownWeight, depth, "L")
    {
        _isHazardous = isHazardous;
    }

    public override void Notify(string message)
    {
        if (_isHazardous)
        {
            Console.WriteLine($"A dangerous situation! Container {SerialNumber}: {message}");
        }
    }

    public override void LoadContainer(int weight)
    {
        if (_isHazardous)
        {
            if (weight >= MaxLoadMass * 0.5)
            {
                Notify("Attempted to load hazardous cargo beyond safety limi");
                return;
            }
        }
        else if (!_isHazardous)
        {
            if (weight >= MaxLoadMass * 0.9)
            {
                Notify("Attempted to load non-hazardous cargo beyond safety limit");
                return;
            } 
        }
        base.LoadContainer(weight);
    }
    
}