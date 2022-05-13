using System.Collections.Generic;

namespace RelationsRevisited.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeCvId { get; set; }
        public virtual EmployeeCv EmployeeCv { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Employee_Skills> Employees_Skills { get; set; }
    }
}
