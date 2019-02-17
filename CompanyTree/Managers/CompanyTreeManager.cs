using CompanyTree.Models;
using System;

namespace CompanyTree.Managers
{
    /// <summary>
    /// TreeAbstractManager implementation. This class helps us to correctly add, remove node in tree. 
    /// Also get employee salary and all company salaries sum.
    /// </summary>

    public class CompanyTreeManager : TreeAbstractManager
    {
        #region abstract class implementation
        /// <summary>
        /// This method constracts company tree.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="supervisor"></param>
        /// <param name="ex">custom exception.When we call this method ,we can check return value and if it is not null handle it </param>
        /// <returns>true - employee successfuly added in tree. </returns>
        public override void AddEmployeeInTree(Employee employee, Employee supervisor)
        {
            if (supervisor.Type == EmployeeType.Employee)
            {
                throw new TreeOperationException(string.Format("Employee can`t have subordinates{0}", supervisor.Name));
            }
            else
            {
                #region check cycle
                Employee emp = supervisor;
                while (emp != null)
                {
                    if (emp == employee)
                    {
                        throw new TreeOperationException(string.Format("Ther is a cycle in tree.{0}", supervisor.Name));
                    }

                    emp = emp.Manager;
                }

                #endregion

                if (employee.Manager != null)
                {
                    // move employee

                    employee.Manager.Subordinates.Remove(employee);
                }

                employee.Manager = supervisor;

                supervisor.Subordinates.Add(employee);
            }
        }

        /// <summary>
        /// When any employee removed , all his subscribers go up through tree.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public override void RemoveEmployeeFromTree(Employee employee)
        {
            foreach (var item in employee.Subordinates)
            {
                item.Manager = employee.Manager;
                employee.Manager.Subordinates.Add(item);
            }

            employee.Manager.Subordinates.Remove(employee);
            employee.Manager = null;
        }

        /// <summary>
        /// this function returns all the salary sum of the employees.
        /// input parameter is just to define tree.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public override int GetSumSalary(Employee employee)
        {
            Employee rootEmployee = employee;

            while (rootEmployee.Manager != null)
            {
                rootEmployee = rootEmployee.Manager;

                if (rootEmployee.Manager == null)
                {
                    break;
                }
            }
            int sumSalary = GetSalary(rootEmployee);

            sumSalary += AllSubTreeSalaries(rootEmployee);

            return sumSalary;
        }

        /// <summary>
        /// This function returns employees' salaries in a recursive way according to the given logic.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public override int GetSalary(Employee employee)
        {
            if (employee.Type == EmployeeType.Employee)
            {
                return employee.BaseSalary + GetBonusByYears(employee);
            }
            else if (employee.Type == EmployeeType.Manager)
            {
                return employee.BaseSalary + GetBonusByYears(employee) + (int)(FirstLevelSubTreeSalaries(employee) * 0.5) / 100;
            }
            else
            {
                return employee.BaseSalary + GetBonusByYears(employee) + (int)(AllSubTreeSalaries(employee) * 0.3) / 100;
            }
        }
        #endregion


        /// <summary>
        /// This fucntion returns that part of the salary, which doesn't depend on subscribers.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int GetBonusByYears(Employee employee)
        {
            int years = DateTime.Now.Subtract(employee.StartDate).Days / 365;
            int bonus = 0;

            switch (employee.Type)
            {
                case EmployeeType.Employee:
                    bonus = (years >= 10) ? (employee.BaseSalary * 30) / 100 : (employee.BaseSalary * 3 * years) / 100;
                    break;
                case EmployeeType.Manager:
                    bonus = (years >= 8) ? (employee.BaseSalary * 40) / 100 : (employee.BaseSalary * 5 * years) / 100;
                    break;
                case EmployeeType.Sales:
                    bonus = (years >= 10) ? (employee.BaseSalary * 35) / 100 : (employee.BaseSalary * years) / 100;
                    break;
            }

            return bonus;
        }

        /// <summary>
        /// Return summary salaries of current nodes all subordinates.
        /// </summary>
        /// <param name="rootEmployee"></param>
        /// <returns></returns>
        public int AllSubTreeSalaries(Employee rootEmployee)
        {
            int sumSalary = 0;
            foreach (var item in rootEmployee.Subordinates)
            {
                sumSalary += GetSalary(item);

                sumSalary += AllSubTreeSalaries(item);
            }

            return sumSalary;
        }

        /// <summary>
        /// Return summary salaries of current nodes first level subordinates.
        /// </summary>
        /// <param name="rootEmployee"></param>
        /// <returns></returns>
        public int FirstLevelSubTreeSalaries(Employee rootEmployee)
        {
            int sumSalary = 0;
            foreach (var item in rootEmployee.Subordinates)
            {
                sumSalary += GetSalary(item);
            }

            return sumSalary;
        }

    }
}
