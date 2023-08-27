// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;

Console.WriteLine("Hello, World!");

Func<decimal, decimal, decimal> calculateAnnualSalary = (anualSalary, bonusPercentage) => (anualSalary +( bonusPercentage / 100 * anualSalary));
Console.WriteLine(calculateAnnualSalary(6000, 2));

Action<int, string ,string, decimal, bool> displayDetails =(id,name,gender,salary,isManager) => Console.WriteLine($"EmployeeId: {id} Name: {name}  Gender: {gender} Salary: {salary} IsManager: {isManager}");

List<Employee> employees = new List<Employee>();

employees.Add(new Employee { Id = 1, Name = "Priyanka", Gender = "F", Salary = 30000000 , IsManager =true});

employees.Add(new Employee { Id = 1, Name = "Shalimi", Gender = "F", Salary = 10000000 , IsManager = true });
employees.Add(new Employee { Id = 1, Name = "Sarthak", Gender = "M", Salary = 15000000 , IsManager = true });
employees.Add(new Employee { Id = 1, Name = "Nimmi", Gender = "F", Salary = 10000000 , IsManager = false });
employees.Add(new Employee { Id = 1, Name = "Utkarsh", Gender = "M", Salary = 10000000, IsManager = false });

var filteredEmployees = employees.FilterEmployees( e => e.Gender == "F");

foreach (Employee employee in filteredEmployees)
{
    displayDetails(employee.Id, employee.Name,employee.Gender, calculateAnnualSalary(employee.Salary,5),employee.IsManager);
}

 public static class ExtensionClass
{
   public static List<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
    {
        List<Employee> result = new List<Employee>();
        foreach (Employee employee in employees)
        {
            if (predicate(employee)) result.Add(employee);
        }
        return result;
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public decimal Salary { get; set; }
    public bool IsManager { get; set; }
}