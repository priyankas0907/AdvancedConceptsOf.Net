using HRAdministrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolHRAdministration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        HeadMaster,
        DeputyHeadMaster

    }
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
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1,"Mary","Joseph",40000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Rasmus", "Jensen", 40000);
            employees.Add(teacher2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Ram", "Gowda", 67500);
            employees.Add(headOfDepartment);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 4, "Priya", "Singh", 100000);
            employees.Add(headMaster);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 5, "Hari", "Om", 150000);
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
        public override decimal Salary { get => base.Salary + base.Salary * 0.04m; }
    }

    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.05m; }
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName,  decimal salary)
        {
            IEmployee employee = null;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;

                case EmployeeType.HeadOfDepartment:
                    employee = new HeadOfDepartment { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;

                case EmployeeType.HeadMaster:
                    employee = new HeadMaster { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;

                case EmployeeType.DeputyHeadMaster:
                    employee = new DeputyHeadMaster { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                default: break;
            }

            return employee;
        }
    }
}
