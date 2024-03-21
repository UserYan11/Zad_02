using Containers;
using Containers.Containers;

public class Program
{
    public static void Main(string[] args)
    {
        
        ContainerL liquidContainer = new ContainerL(100, 200, 100, 150, true);
        Console.WriteLine($"Liquid Container Serial Number: {liquidContainer.SerialNumber}");

        ContainerG gasContainer = new ContainerG(300, 150, 80, 120, 20);
        Console.WriteLine($"Gas Container Serial Number: {gasContainer.SerialNumber}");
        
        ContainerC refrigeratedContainer = new ContainerC(1000, 250, 150, 200, "Bananas", 13.3);
        Console.WriteLine($"Refrigerated Container Serial Number: {refrigeratedContainer.SerialNumber}");

        
        
        ContainerShip containerShip = new ContainerShip(80, 2, 1000000);
        containerShip.PrintShipInfo();
        
        Console.WriteLine("== +2 =====================");
        containerShip.LoadContainerShip(liquidContainer);
        containerShip.LoadContainerShip(gasContainer);
        containerShip.PrintShipInfo();
        
        Console.WriteLine("== -1 =====================");
        containerShip.RemoveContainer(liquidContainer);
        containerShip.PrintShipInfo();
        
        Console.WriteLine("== +1 =====================");
        containerShip.LoadContainerShip(liquidContainer);
        containerShip.PrintShipInfo();
        
        Console.WriteLine("== -> =====================");
        // containerShip.ChangeContainer(refrigeratedContainer.serialNumber, liquidContainer);
        // containerShip.PrintShipInfo();

    }
}