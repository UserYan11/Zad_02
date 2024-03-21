using Containers.Exceptions;

namespace Containers.Containers;

public class ContainerC : Container
{
    private string TypeOfProduct { get;  }
    private double Temperature { get; }

    private Dictionary<string, double> TempInfo = new()
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice Cream", -18},
        {"Frozen Pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    
    public ContainerC(int maxLoadMass, int height, int ownWeight, int depth, string typeOfProduct, double temperature) : 
        base(maxLoadMass, height, ownWeight, depth, "C")
    {
        TypeOfProduct = typeOfProduct;
        Temperature = temperature;
    }

    public void LoadContainer(int weight, string type)
    {
        if (weight > MaxLoadMass)
        {
            throw new OverfillException("Cargo weight exceeds container capacity");
        }

        if (LoadWeight > 0 && TypeOfProduct != type)
        {
            Console.WriteLine("Freezer container can only store products of the same type");
            return;
        }

        if (TempInfo.ContainsKey(TypeOfProduct))
        {
            double requiredTemperature = TempInfo[TypeOfProduct];
            if (requiredTemperature < 0 && LoadWeight < 0 && requiredTemperature < Temperature)
            {
                throw new ArgumentException("Temperature is too low for the product");
            }
            if (requiredTemperature > 0 && LoadWeight > 0 && requiredTemperature > Temperature)
            {
                throw new ArgumentException("Temperature is too high for the product");
            }
        }
        else
        {
            throw new ArgumentException($"Unknown product type: {TypeOfProduct}");
        }
        LoadWeight = weight;
    }
    
}