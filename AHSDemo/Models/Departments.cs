using System;
using System.Collections.Generic;

namespace AHSDemo.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? HospitalId { get; set; }

        public virtual Hospitals Hospital { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
