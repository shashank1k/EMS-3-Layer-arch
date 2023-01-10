using Capgemini.EMS.DataAccessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;
using System.Collections.Generic;

namespace Capgemini.EMS.BussinessLayer
{
    public class EmployeeBL
    {
        public static bool Add(Employee emp)
        {
            //Buissiness Validations
            //Throw UDE

            if (emp.Id <= 0)  //invalid
            {
                throw new EmsException("Employee Id should be greater than Zero");
            }

            //call DAL method
            bool isAdded = EmployeeDAL.Add(emp);
            return isAdded;
        }

        public static List<Employee> GetList()
        {
            var list = EmployeeDAL.GetList();
            return list;

        }
        public static Employee GetById(int id)
        {
            var emp = EmployeeDAL.GetById(id);
            return emp;
        }
        public static bool Update(Employee emp)
        {
            bool isUpdate = EmployeeDAL.Update(emp);
            return isUpdate;

        }
        public static bool DelEmployee(int empId)
        {
            return EmployeeDAL.DelEmployee(empId);

        }

    }
}
