// See https://aka.ms/new-console-template for more information
DelegatesClass.GetIceCarDetails();
public static class DelegatesClass
{
    delegate Car CarFactoryDel(int id, string name); //Covariannce , return type is the base class
    delegate void LogIceCarDetails(IceCar carDetails); // Contravariance, parameters are derived class
    delegate void LogEvCarDetails(EvCar carDetails);// Contravariance, parameters are derived class
    public static void GetIceCarDetails()
    {
        CarFactoryDel carFactoryDel = CarFactory.ReturnIceCar;
        Car iceCar = carFactoryDel(1, "Audi R8");
        Console.WriteLine($"Object type : {iceCar.GetType()}");
        Console.WriteLine($"Car Details : {iceCar.GetCarDetail()}");
        LogIceCarDetails logdel = LogCarDetails;
        logdel(iceCar as IceCar);

        carFactoryDel = CarFactory.ReturnEvCar;
        Car evCar = carFactoryDel(2, "tesla");
        Console.WriteLine($"Object type: {evCar.GetType()}");
        Console.WriteLine($"Car Details : {evCar.GetCarDetail()}");
       

        LogEvCarDetails logdel2 = LogCarDetails;
        logdel2(evCar as EvCar);

        Console.ReadKey();



    }

    static void LogCarDetails(Car car) //Contravariance , Parameter of target method is base class
    {
            Console.WriteLine("Logs");
        if (car is IceCar)
        {
            Console.WriteLine($"Object type {car.GetType()}");
            Console.WriteLine($"Object type {car.GetCarDetail()}");
        }
        else if (car is EvCar)
        {
            Console.WriteLine($"Object type {car.GetType()}");
            Console.WriteLine($"Object type {car.GetCarDetail()}");
        }
        else
        {
            throw new ArgumentException();
        }
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
    public static IceCar ReturnIceCar(int id, string name) => new IceCar { Id = id, Name = name }; //Covariance , return type of target method is dervied class
    public static EvCar ReturnEvCar(int id, string name) => new EvCar { Id = id, Name = name }; //Covariance , return type of target method is dervied class
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


