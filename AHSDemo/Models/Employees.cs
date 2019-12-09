using System;
using System.Collections.Generic;

namespace AHSDemo.Models
{
    public partial class Employees
    {
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public int? Salary { get; set; }

        public virtual Departments Department { get; set; }
    }
}
