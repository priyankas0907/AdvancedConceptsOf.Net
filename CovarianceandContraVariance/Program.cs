// See https://aka.ms/new-console-template for more information
DelegatesClass.GetIceCarDetails();
public static class DelegatesClass
{
    delegate Car CarFactoryDel(int id, string name);

    public static void GetIceCarDetails()
    {
        CarFactoryDel carFactoryDel = CarFactory.ReturnIceCar;
        Car iceCar = carFactoryDel(1, "Audi R8");
        Console.WriteLine($"Object type : {iceCar.GetType()}");
        Console.WriteLine($"Car Details : {iceCar.GetCarDetail()}");

        carFactoryDel = CarFactory.ReturnEvCar;
        Car evCar = carFactoryDel(2, "tesla");
        Console.WriteLine($"Object type: {evCar.GetType()}");
        Console.WriteLine($"Car Details : {evCar.GetCarDetail()}");
    }

    //public static void GetEvCarDetails(CarFactoryDel carFactoryDel)
    //{
    //    carFactoryDel = CarFactory.ReturnEvCar;
    //    Car evCar = carFactoryDel(2, "tesla");
    //    Console.WriteLine($"Object type: {evCar.GetType()}");
    //    Console.WriteLine($"Car Details : {evCar.GetCarDetail()}");
    //}
}



public static class CarFactory
{
    public static IceCar ReturnIceCar(int id, string name) => new IceCar { Id = id, Name = name };
    public static EvCar ReturnEvCar(int id, string name) => new EvCar { Id = id, Name = name };
}

public abstract class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual string GetCarDetail()
    {
        return $"{Id} - {Name}";
    }
}


public class IceCar : Car
{
    public override string GetCarDetail()
    {
        return $"{ base.GetCarDetail()} - Internal Combustion Engine";
    }
}

public class EvCar : Car
{
    public override string GetCarDetail()
    {
        return $"{base.GetCarDetail()} - Electric";
    }
}


