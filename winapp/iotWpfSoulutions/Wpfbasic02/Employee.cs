using System;
using System.Collections.Generic;
using System.Text;

namespace Wpfbasic02
{
    public class Employee
    {

        public int Id { get; set; } ///pk

        public string Name { get; set; }

        public string Department { get; set; }

        public int Salary { get; set; }

        public DateTime HireDate {  get; set; }

        public bool IsActive { get; set; }

    }
}
