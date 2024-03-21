using Containers.Containers;

namespace Containers;

public class ContainerShip
{
    private List<Container> containers = new(); // kontenery ktore transportuje dany statek
    
    private double maxSpeed; // maksymalna prędkość
    private int maxCountOfContainers; // maksymalna liczba kontenerów
    private double maxWeightOfContainers; // maksymalna waga wszystkich kontenerów
    private double weight;
    private int countOfContainers;

    public ContainerShip(double maxSpeed, int maxCountOfContainers, double maxWeightOfContainers)
    {
        this.maxSpeed = maxSpeed;
        this.maxCountOfContainers = maxCountOfContainers;
        this.maxWeightOfContainers = maxWeightOfContainers;
    }

    public void LoadContainerShip(Container container)
    {
        weight += container.LoadWeight + container.OwnWeight;
        countOfContainers += 1;
        if (weight > maxWeightOfContainers || countOfContainers > maxCountOfContainers)
        {
            Console.WriteLine("Weight exceeds the maximum");
            weight -= container.LoadWeight + container.OwnWeight;
            countOfContainers -= 1;
            return;
        }
        containers.Add(container);
    }

    public void LoadListOfContainerShip(List<Container> containersToLoad)
    {
        for (int i = 0; i < containersToLoad.Count; i++)
        {
            weight += containersToLoad[i].LoadWeight + containersToLoad[i].OwnWeight;
            if (weight > maxWeightOfContainers)
            {
                Console.WriteLine("Weight exceeds the maximum");
                weight -= containersToLoad[i].LoadWeight + containersToLoad[i].OwnWeight;
                return;
            }
            containers.Add(containersToLoad[i]);
        }
    }
    
    public static void PrintContainerInfo(Container container)
    {
        Console.WriteLine($"Container {container.SerialNumber}:");
        Console.WriteLine($"  Type: {container.GetType().Name}");
        Console.WriteLine($"  Load Weight: {container.LoadWeight} kg");
    }
    
    public void PrintShipInfo()
    {
        Console.WriteLine("Ship information:");
        Console.WriteLine($"  Max Speed: {maxSpeed} knots");
        Console.WriteLine($"  Max Container Count: {maxCountOfContainers}");
        Console.WriteLine($"  Max Total Weight: {maxWeightOfContainers} tons");
        Console.WriteLine($"  Count of Container: {countOfContainers}");
        Console.WriteLine("Containers on the ship:");
        foreach (var container in containers)
        {
            PrintContainerInfo(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].SerialNumber == container.SerialNumber)
            {
                containers.Remove(containers[i]);
                countOfContainers -= 1;
            }
        }
    }

    public void ChangeContainer(string contNumber, Container newContainer)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].SerialNumber == contNumber)
            {
                containers.Remove(containers[i]);
                containers[i] = newContainer;
            }
        }
    }
    
    public static void TransferContainer(Container container, ContainerShip sourceShip, ContainerShip destinationShip)
    {
        if (destinationShip.containers.Count >= destinationShip.maxCountOfContainers)
        {
            throw new InvalidOperationException("Destination ship cannot accept more containers. Maximum container count reached.");
        }

        double totalWeight = destinationShip.containers.Sum(c => c.LoadWeight) + container.LoadWeight;
        if (totalWeight > destinationShip.maxWeightOfContainers)
        {
            throw new InvalidOperationException("Cannot transfer container. Destination ship's maximum total weight exceeded.");
        }

        sourceShip.containers.Remove(container);
        destinationShip.containers.Add(container);
    }
    
}