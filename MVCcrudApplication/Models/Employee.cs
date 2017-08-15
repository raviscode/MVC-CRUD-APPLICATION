using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCcrudApplication.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
    }
}