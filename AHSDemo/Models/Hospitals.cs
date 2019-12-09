using System;
using System.Collections.Generic;

namespace AHSDemo.Models
{
    public partial class Hospitals
    {
        public Hospitals()
        {
            Departments = new HashSet<Departments>();
        }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string Hours { get; set; }
        public bool? HasEmergencyRoom { get; set; }

        public virtual ICollection<Departments> Departments { get; set; }
    }
}
