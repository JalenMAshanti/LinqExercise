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
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine(numbers.Sum());

            //TODO: Print the Average of numbers

            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ascending -------------");
            
            var ascending = numbers.OrderBy(x => x);
            foreach (var number in ascending) 
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("");
            
            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Descending -------------");
            
            var descending = numbers.OrderByDescending(x => x);
            foreach (var number in descending) 
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("");


            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than Six----------------");
           
            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var number in greaterThanSix) 
            { 
                Console.WriteLine(number);  
            }
            Console.WriteLine("");


            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Only 4 Descending ----------------");
            var Only4Descending = numbers.OrderByDescending(x => x).Take(4);
            foreach (var number in Only4Descending) 
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("");

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("Descending with my age at index 4 ----------------");
            
            numbers[4] = 23;
            var withMyAge = numbers.OrderByDescending(x =>x);
            foreach (var number in withMyAge) 
            { 
                Console.WriteLine(number);
            }
            Console.WriteLine("");


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            Console.WriteLine("Ascending Only if name starts with a C or S ----------------");
            
            var firstNameCorSAscending = from employee in employees
                                         where employee.FirstName.StartsWith("C") || employee.FirstName.StartsWith("S")
                                         orderby employee.FirstName.Length
                                         select employee;

            foreach (var employee in firstNameCorSAscending) 
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.WriteLine("");

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Older than 26 then sorted by age then first name ----------------");
           
            var over26byAgeThenName = from employee in employees
                                      where employee.Age > 26
                                      orderby employee.Age orderby employee.FirstName
                                      select employee;
            foreach (var employee in over26byAgeThenName)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine("");

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
         
            Console.WriteLine("Sum of Employees YOE <= 10 or Age > 35 ----------------");
            
            var sum = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);
            Console.WriteLine(sum);
            Console.WriteLine("");


            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
           
            Console.WriteLine("Average of Employees YOE <= 10 or Age > 35 ----------------");
           
            var average = employees.Where(x => x.YearsOfExperience <= 10 && x.Age >35).Average(x => x.YearsOfExperience);
            Console.WriteLine(average);
            Console.WriteLine("");

            //TODO: Add an employee to the end of the list without using employees.Add()

            Console.WriteLine("Append Employee-------------");

            Employee employee1 = new Employee();
            employee1.FirstName = "Jalen";
            employee1.LastName = "Ashanti";
            employee1.Age = 23;
            employee1.YearsOfExperience = 1;
            employees.Append(employee1);
            
            


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
