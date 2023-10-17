using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(" ");
            Console.WriteLine(numbers.Average());
            Console.WriteLine(" ");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine(" ");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine(" ");
            numbers.Where(x  => x > 6).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine(" ");
            var orderedNums = numbers.OrderBy(x => x);

            foreach (var number in orderedNums.Take(4))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine(" ");
            numbers[4] = 31;

            var numbersDesc = numbers.OrderByDescending(x => x);

            foreach(var number in numbersDesc)
            {
                Console.WriteLine(number);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            Console.WriteLine(" ");

            var filterEmployees = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);

            foreach (var person  in filterEmployees)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine(" ");

            var employeesOver26 = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            foreach (var person in employeesOver26)
            {
                Console.WriteLine($"{person.FullName}, {person.Age}");
            }
            Console.WriteLine(" ");

            var excessiveTitle = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);

            Console.WriteLine($"Total years of exp: {excessiveTitle.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average years of exp: {excessiveTitle.Average(x => x.YearsOfExperience)}");

            employees = employees.Append(new Employee("Uther", "Pendragon", 35, 5)).ToList();


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
