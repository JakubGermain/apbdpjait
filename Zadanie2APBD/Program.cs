using Zadanie2APBD;

class Program
{
    static void Main(string[] args)
    {
        
        var liquidContainer = new LiquidContainer(200, 500, 100, 1000, true);
        var gasContainer = new GasContainer(250, 600, 120, 1500, 10);
        var refrigeratedContainer = new RefrigeratedContainer(300, 700, 150, 2000, "Bananas", 4);

 
            liquidContainer.LoadCargo(400);
            gasContainer.LoadCargo(1200);
            refrigeratedContainer.LoadCargo(1800);
        
            
        var ship = new ContainerShip(25, 100, 500);

        
        ship.LoadContainer(liquidContainer);
        ship.LoadContainer(gasContainer);
        ship.LoadContainer(refrigeratedContainer);
        
        ship.PrintShipInfo();
        
        var overloadedContainer = new LiquidContainer(200, 500, 100, 1000, false);
        
            overloadedContainer.LoadCargo(2000);
            ship.LoadContainer(overloadedContainer);
            
        ship.UnloadContainer(liquidContainer.sNumber);

        
        ship.PrintShipInfo();
    }
}
