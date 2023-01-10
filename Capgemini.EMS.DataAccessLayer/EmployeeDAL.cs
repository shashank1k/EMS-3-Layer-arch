using Capgemini.EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini.EMS.DataAccessLayer
{
    public class EmployeeDAL
    {
        static List<Employee> list = new List<Employee>();

        public static bool Add(Employee emp)
        {
            list.Add(emp);
            return true;

        }
        public static List<Employee> GetList()
        {
            
            return list;

        }
        /* public static bool isExists(int id)
        {

            //LINQ     for each employee in "list", get the employee that satisfies the condition
            var emp = list.Where(e => e.Id == id).FirstOrDefault();
            if (emp==null)
            {
                return false;
            }
            return true;
        }
        */

        public static Employee GetById(int id)
        {

            //LINQ     for each employee in "list", get the employee that satisfies the condition
            var emp = list.Where(e => e.Id == id).FirstOrDefault();
            return emp;
        }

        public static bool Update(Employee emp)
        {
            //get emp by ID
            var exisitingEmp = list.Where(e => e.Id == emp.Id).FirstOrDefault();
            exisitingEmp.Name = emp.Name;
            exisitingEmp.DateOfJoining = emp.DateOfJoining;
            return true;
            //update
        }
        public static bool DelEmployee(int empId)
        {

            var emp = list.Where(e => e.Id == empId).FirstOrDefault();
            list.Remove(emp);
            return true;

            //
            /*int i = 0;
            foreach (var item in list)
            {
                if(item.Id==empId)
                {
                    list.RemoveAt(i);
                    return true;
                }
                i++;
            }
            */
            
        }

    }
}
