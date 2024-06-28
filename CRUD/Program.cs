
//Create a c# mini project to CRUD(Create, Read, Update and Delete) Employees and Departments
//Department has Id, Name, Remarks and Employee has Id, Name, DepartmentId, Salary.
//Search employees by name(Handle case sensitivity). Peter "peter"
//Search department whose name starts with ‘B’.
//Search department whose name ends with ‘E’.

using System;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            string userInput;
            do
            {
                Employee employee = new Employee();

                Console.Write("Enter Employee ID: ");
                employee.E_id = int.Parse(Console.ReadLine());

                Console.Write("Enter Employee Name: ");
                employee.E_Name = Console.ReadLine();

                Console.Write("Enter Department ID: ");
                employee.D_id = int.Parse(Console.ReadLine());

                Console.Write("Enter Salary: ");
                employee.E_Salary = decimal.Parse(Console.ReadLine());

                employees.Add(employee);

                Console.Write("Do you want to add another employee? (y/n): ");
                userInput = Console.ReadLine();
            }
            while (userInput.Equals("y", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\nList of Employees:");

            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.E_id}, \nName: {emp.E_Name}, \nDepartment ID: {emp.D_id}, \nSalary: {emp.E_Salary}\n\n");
            }

            bool continueSearching = true;
            while (continueSearching)
            {

                Console.WriteLine("Choose search option:");
                Console.WriteLine("1. Search by name\n2. Search by initials\n3. Search by ends\n4. Exit\n");
                Console.WriteLine("Enter your choice:");
                string searchOption = Console.ReadLine();
                switch (searchOption)
                {
                    case "1":
                        //search by name
                        Console.Write("\nEnter an Employee Name to search: ");
                        string searchName = Console.ReadLine();
                        Employee foundEmployee = employees.FirstOrDefault(e => e.E_Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

                        if (foundEmployee != null)
                        {
                            Console.WriteLine($"Found Employee: ID: {foundEmployee.E_id}, Name: {foundEmployee.E_Name}, Department ID: {foundEmployee.D_id}, Salary: {foundEmployee.E_Salary}\n");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case "2":
                        //search by initials
                        Console.Write("\nEnter an Employee Initials to search: ");
                        string searchNameByInitial = Console.ReadLine();
                        Employee foundEmployeeByInitial = employees.FirstOrDefault(e => e.E_Name.StartsWith(searchNameByInitial, StringComparison.OrdinalIgnoreCase));

                        if (foundEmployeeByInitial != null)
                        {
                            Console.WriteLine($"Found Employee: ID: {foundEmployeeByInitial.E_id}, Name: {foundEmployeeByInitial.E_Name}, Department ID: {foundEmployeeByInitial.D_id}, Salary: {foundEmployeeByInitial.E_Salary}\n");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case "3":
                        //search by ends
                        Console.Write("\nEnter an Employee Ends to search: ");
                        string searchNameByEnd = Console.ReadLine();
                        Employee foundEmployeeByEnd = employees.FirstOrDefault(e => e.E_Name.EndsWith(searchNameByEnd, StringComparison.OrdinalIgnoreCase));

                        if (foundEmployeeByEnd != null)
                        {
                            Console.WriteLine($"Found Employee: ID: {foundEmployeeByEnd.E_id}, Name: {foundEmployeeByEnd.E_Name}, Department ID: {foundEmployeeByEnd.D_id}, Salary: {foundEmployeeByEnd.E_Salary}\n");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case "4":
                        continueSearching = false;
                        break;  

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2,3 or 4");
                        break;
                }
            }
        }
    }
}