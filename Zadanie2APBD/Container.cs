namespace Zadanie2APBD;

public abstract class Container
{
    public string sNumber { get; set; }
    public double CargoMass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public double MaxPayload { get; set; }
    
    protected Container(string typeCode, double height, double tareWeight, double depth, double maxPayload)
    {
        sNumber = GenerateSerialNumber(typeCode);
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
    }
    
    private static int _containerCount = 0;

    private string GenerateSerialNumber(string typeCode)
    {
        int count = _containerCount++;
        return $"KON-{typeCode}-{count}";
    }

    public void LoadCargo(double maxkg)
    {
        if (maxkg > MaxPayload)
        {
            Console.WriteLine(" masa > Maks. ładowność - spróbuj ponownie");
        }
        CargoMass = maxkg;
    }

    public abstract void PrintInfo();
    
    
}

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double height, double tareWeight, double depth, double maxPayload, bool isHazardous)
        : base("Liqud", height, tareWeight, depth, maxPayload)
    {
        IsHazardous = isHazardous;
    }

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Wykryto niebezpieczną sytuację w kontenerze {containerNumber}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Kontener płynny {sNumber}: Masa ładunku = {CargoMass} kg, " +
                          $"Niebezpieczny = {IsHazardous}");
    }
}

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(double height, double tareWeight, double depth, double maxPayload, double pressure)
        : base("G", height, tareWeight, depth, maxPayload)
    {
        Pressure = pressure;
    }

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Wykryto niebezpieczną sytuację w kontenerze {containerNumber}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Kontener gazowy {sNumber}: Masa ładunku = {CargoMass} kg, " +
                          $"Ciśnienie = {Pressure}");
    }
}

public class RefrigeratedContainer : Container
{
    public string ProductType { get; private set; }
    public double Temperature { get; private set; }

    public RefrigeratedContainer(double height, double tareWeight, double depth, double maxPayload, string productType, double temperature)
        : base("C", height, tareWeight, depth, maxPayload)
    {
        ProductType = productType;
        Temperature = temperature;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Kontener chłodniczy {sNumber}: Masa ładunku = {CargoMass} kg, " +
                          $"Typ produktu = {ProductType}, " +
                          $"Temperatura = {Temperature}°C");
    }
}

