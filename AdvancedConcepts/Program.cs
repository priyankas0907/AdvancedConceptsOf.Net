using HRAdministrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolHRAdministration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            //foreach(IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}

            totalSalaries = employees.Sum(e => e.Salary);
            Console.WriteLine($"Total Salaries including Bonus = {totalSalaries}");

        }

        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = new Teacher
            {
                Id = 1,
                FirstName = "Mary",
                LastName = "Joseph",
                Salary = 40000
            };
            employees.Add(teacher1);

            IEmployee teacher2 = new Teacher
            {
                Id = 2,
                FirstName = "Rasmus",
                LastName = "Jenson",
                Salary = 40000
            };
            employees.Add(teacher2);

            IEmployee headOfDepartment = new HeadOfDepartment
            {
                Id = 3,
                FirstName = "Ram",
                LastName = "Gowda",
                Salary = 67500
            };
            employees.Add(headOfDepartment);

            IEmployee headMaster = new HeadMaster
            {
                Id = 4,
                FirstName = "Priya",
                LastName = "Singh",
                Salary = 100000
            };
            employees.Add(headMaster);

            IEmployee deputyHeadMaster = new DeputyHeadMaster
            {
                Id = 5,
                FirstName = "Hari",
                LastName = "Om",
                Salary = 160000
            };

            employees.Add(deputyHeadMaster);
        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.02m; }
    }

    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.03m; }
    }

    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary{ get => base.Salary + base.Salary * 0.04m; }
    }

    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.05m; }
    }
}
