using CompanyTree.Models;

namespace CompanyTree.Managers
{
    /// <summary>
    /// This is abstract logic to work with tree.
    /// We can implement this logic in different ways for different trees.
    /// </summary>
    public abstract class TreeAbstractManager
    {
        public abstract void AddEmployeeInTree(Employee employee, Employee supervisor);
        public abstract void RemoveEmployeeFromTree(Employee employee);
        public abstract int GetSalary(Employee employee);
        public abstract int GetSumSalary(Employee employee);
    }

}
