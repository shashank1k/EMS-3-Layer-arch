using System;

namespace Capgemini.EMS.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public DateTime DateOfJoining { get; set; }

        public override string ToString()
        {
            return $"  ID : {Id}\n  Name : {Name} \n  Date of Joining : {DateOfJoining.ToShortDateString()} \n------------------------------------------------------";

        }
    }
}
