using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var result = new Dictionary<string, int>();
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                result.Add(company, (int)Math.Round(employees.Where(x => x.Company == company).Average(y => y.Age), 0));
            }

            return result;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var result = new Dictionary<string, int>();
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                result.Add(company, employees.Count(x => x.Company == company));
            }

            return result;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var result = new Dictionary<string, Employee>();
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                result.Add(company, employees.Where(x => x.Company == company).OrderByDescending(y => y.Age).First());
            }

            return result;
        }

        public static void Main(string[] args)  // Changed to static method
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            var averageAges = Solution.AverageAgeForEachCompany(employees);  // Static method called using class name
            var employeeCounts = Solution.CountOfEmployeesForEachCompany(employees);  // Static method called using class name
            var oldestEmployees = Solution.OldestAgeForEachCompany(employees);  // Static method called using class name

            foreach (var emp in averageAges)
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in employeeCounts)
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in oldestEmployees)
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
