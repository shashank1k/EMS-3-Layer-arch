using Capgemini.EMS.BussinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;

namespace Capgemini.EMS.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("1 Add Employee, 2 Employee List, 3 Update Employee, 4 Delete Employee, 5 Exit");
                Console.WriteLine("Enter Your Choice");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid Input");

                }
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;

                    case 2:
                        EmployeeList();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DelEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

            }
            
        }

        private static void DelEmployee()
        {
            int empId;
            string input;
            do
            {
                Console.WriteLine("Enter Employee ID");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out empId));

            //check emp id
            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee not Found");
                return;
            }

            //delete now
            var isDeleted = EmployeeBL.DelEmployee(empId);
            if(isDeleted)
            {
                Console.WriteLine("Employee deleted Successfully");
            }
            else
            {
                Console.WriteLine("Employee deletion failed");
            }

        }

        private static void UpdateEmployee()
        {
            //Emp Id
            int empId;
            string input;
            do
            {
                Console.WriteLine("Enter Employee ID");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out empId));

            //check emp id
            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee not Found");
                return;
            }

            //name//doj
            //create a new employee object and then assign that with ID, name and DOJ and then pass that to update
            Employee newEmp = new Employee();
            newEmp.Id = empId;


            do
            {
                Console.WriteLine("Enter Employee Name");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            newEmp.Name = input;

            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter Date of Joining");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmp.DateOfJoining = dateOfJoining;

            //update
            var isUpdated = EmployeeBL.Update(newEmp);
            if (isUpdated)
            {
                Console.WriteLine("Employee Updated Successfully");
            }
            else
            {
                Console.WriteLine("Employee Updated failed");
            }
           

        }

        private static void EmployeeList()
        {
            var list = EmployeeBL.GetList();
            Console.WriteLine(" Employee List :-");
            Console.WriteLine("------------------------------------------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();
            int empId;
            string input;
            do
            {
                Console.WriteLine("Enter Employee ID");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out empId));
            newEmployee.Id = empId;

            do
            {
                Console.WriteLine("Enter Employee Name");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmployee.Name = input;

            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter Date of Joining");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input,out dateOfJoining));
            newEmployee.DateOfJoining = dateOfJoining;

            //call BL


            try
            {
                bool isAdded = EmployeeBL.Add(newEmployee);
                if (isAdded)
                {
                    Console.WriteLine("Employee added Successfully");
                }
                else
                {
                    Console.WriteLine("Employee Add Failed");
                }
            }
            catch (EmsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
