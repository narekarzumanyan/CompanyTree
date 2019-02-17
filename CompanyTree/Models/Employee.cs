using System;
using System.Collections.Generic;

namespace CompanyTree.Models
{
    /// <summary>
    /// Tree node types. If we need to add a new node type, new enum value must be added.
    /// </summary>
    public enum EmployeeType
    {
        Employee,
        Manager,
        Sales
    }

    /// <summary>
    /// This is an employee class object.
    /// </summary>
    public class Employee
    {
        #region Properties

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int BaseSalary { get; set; }

        public EmployeeType Type { get; set; }

        public Employee Manager { get; set; }

        public List<Employee> Subordinates { get; set; }

        #endregion

        #region Constructors

        public Employee(string name, DateTime date, int baseSalary, EmployeeType type)
        {
            this.Name = name;
            this.StartDate = date;
            this.BaseSalary = baseSalary;
            this.Type = type;
            this.Subordinates = new List<Employee>();
        }

        public Employee() :
            this("SampleEmployee", DateTime.Now, 2000, EmployeeType.Employee)
        {
        }

        public Employee(string name, DateTime date, EmployeeType type) :
            this(name, date, 2000, type)
        {
        }

        #endregion

    }
}
