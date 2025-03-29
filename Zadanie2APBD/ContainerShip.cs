namespace Zadanie2APBD;

public class ContainerShip
{
    public List<Container> Containers { get; private set; }
    public double MaxSpeed { get; private set; }
    public int MaxContainerCount { get; private set; }
    public double MaxWeight { get; private set; }

    public ContainerShip(double maxSpeed, int maxContainerCount, double maxWeight)
    {
        Containers = new List<Container>();
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new InvalidOperationException("Nie można załadować więcej kontenerów: osiągnięto maksymalną liczbę.");
        }

        double totalWeight = Containers.Sum(c => c.CargoMass + c.TareWeight) + container.CargoMass + container.TareWeight;
        if (totalWeight > MaxWeight * 1000) 
        {
            throw new InvalidOperationException("Nie można załadować kontenera: przekroczono maksymalną wagę.");
        }

        Containers.Add(container);
    }

    public void UnloadContainer(string sNumber)
    {
        var container = Containers.FirstOrDefault(c => c.sNumber == sNumber);
        if (container != null)
        {
            Containers.Remove(container);
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Informacje o statku: Maks. prędkość = {MaxSpeed} węzłów, " +
                          $"Maks. kontenerów = {MaxContainerCount}, " +
                          $"Maks. waga = {MaxWeight} ton");
    
        foreach (var container in Containers)
        {
            container.PrintInfo();
        }
    }
}