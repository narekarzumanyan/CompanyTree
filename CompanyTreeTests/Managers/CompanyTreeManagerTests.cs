using CompanyTree.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompanyTree.Managers.Tests
{
    [TestClass()]
    public class CompanyTreeManagerTests
    {
        [TestMethod()]
        [ExpectedException(typeof(TreeOperationException))]
        public void AddEmployeeInTreeTest_EmployeeSubordinates()
        {
            // Arrange
            CompanyTreeManager manager = new CompanyTreeManager();
            TreeOperationException ex = new TreeOperationException();


            Employee emp = new Employee("Jhon", DateTime.Now.AddYears(-9), EmployeeType.Employee);
            Employee emp1 = new Employee("Jhon", DateTime.Now.AddYears(-7), EmployeeType.Sales);

            // Act
            manager.AddEmployeeInTree(emp1, emp );
        }

        [TestMethod()]
        [ExpectedException(typeof(TreeOperationException))]
        public void AddEmployeeInTreeTest_CheckCycle()
        {
            // Arrange
            CompanyTreeManager manager = new CompanyTreeManager();

            Employee emp = new Employee("Jhon", DateTime.Now.AddYears(-9), EmployeeType.Manager);
            Employee emp1 = new Employee("Jhon", DateTime.Now.AddYears(-7), EmployeeType.Sales);
            Employee emp2 = new Employee("Jhon", DateTime.Now.AddYears(-4), EmployeeType.Manager);

            manager.AddEmployeeInTree(emp1, emp);
            manager.AddEmployeeInTree(emp2, emp1 );


            // Act
            manager.AddEmployeeInTree(emp, emp2 );

        }

        [TestMethod()]
        [ExpectedException(typeof(TreeOperationException))]
        public void AddEmployeeInTreeTest_CheckhimselfManager()
        {
            // Arrange
            CompanyTreeManager manager = new CompanyTreeManager();
            TreeOperationException ex = new TreeOperationException();

            Employee emp = new Employee("Jhon", DateTime.Now.AddYears(-9), EmployeeType.Manager);

            // Act
            manager.AddEmployeeInTree(emp, emp );

        }

        [TestMethod()]
        public void GetSumSalaryTest()
        {
            // Arrange
            CompanyTreeManager manager = new CompanyTreeManager();
            TreeOperationException ex = new TreeOperationException();

            int expected = 16156;


            Employee emp1 = new Employee("Jhon1", DateTime.Now.AddYears(-25), EmployeeType.Manager);
            Employee emp2 = new Employee("Jhon2", DateTime.Now.AddYears(-7), EmployeeType.Sales);
            Employee emp3 = new Employee("Jhon3", DateTime.Now.AddYears(-2), EmployeeType.Manager);
            Employee emp4 = new Employee("Jhon4", DateTime.Now.AddYears(-1), EmployeeType.Employee);

            Employee emp5 = new Employee("Jhon5", DateTime.Now.AddYears(-24), EmployeeType.Employee);
            Employee emp6 = new Employee("Jhon6", DateTime.Now.AddYears(-6), EmployeeType.Sales);
            Employee emp7 = new Employee("Jhon7", DateTime.Now.AddYears(-3), EmployeeType.Employee);

            manager.AddEmployeeInTree(emp2, emp1 );
            manager.AddEmployeeInTree(emp3, emp1 );
            manager.AddEmployeeInTree(emp4, emp1 );
            manager.AddEmployeeInTree(emp5, emp2 );
            manager.AddEmployeeInTree(emp6, emp2 );
            manager.AddEmployeeInTree(emp7, emp3 );

            // Act
            int actual = manager.GetSumSalary(emp1);

            // Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetSalaryTest_manager()
        {
            // Arrange
            CompanyTreeManager manager = new CompanyTreeManager();

            int expected = 2030;


            Employee emp1 = new Employee("Jhon1", DateTime.Now.AddYears(0), EmployeeType.Manager);
            Employee emp2 = new Employee("Jhon2", DateTime.Now.AddYears(0), EmployeeType.Sales);
            Employee emp3 = new Employee("Jhon3", DateTime.Now.AddYears(0), EmployeeType.Manager);
            Employee emp4 = new Employee("Jhon4", DateTime.Now.AddYears(0), EmployeeType.Employee);

            Employee emp5 = new Employee("Jhon5", DateTime.Now.AddYears(0), EmployeeType.Manager);
            Employee emp6 = new Employee("Jhon6", DateTime.Now.AddYears(0), EmployeeType.Employee);
            Employee emp7 = new Employee("Jhon7", DateTime.Now.AddYears(0), EmployeeType.Sales);
            Employee emp8 = new Employee("Jhon8", DateTime.Now.AddYears(0), EmployeeType.Employee);


            manager.AddEmployeeInTree(emp2, emp1 );
            manager.AddEmployeeInTree(emp3, emp1 );
            manager.AddEmployeeInTree(emp4, emp1 );

            manager.AddEmployeeInTree(emp5, emp2 );
            manager.AddEmployeeInTree(emp6, emp2 );
            manager.AddEmployeeInTree(emp7, emp2 );
            manager.AddEmployeeInTree(emp8, emp7 );

            // Act
            int actual = manager.GetSalary(emp1);

            // Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetSalaryTest_sales()
        {
            // Arrange
            CompanyTreeManager manager = new CompanyTreeManager();

            int expected = 2042;

            Employee emp1 = new Employee("Jhon1", DateTime.Now.AddYears(0), EmployeeType.Sales);
            Employee emp2 = new Employee("Jhon2", DateTime.Now.AddYears(0), EmployeeType.Sales);
            Employee emp3 = new Employee("Jhon3", DateTime.Now.AddYears(0), EmployeeType.Manager);
            Employee emp4 = new Employee("Jhon4", DateTime.Now.AddYears(0), EmployeeType.Employee);

            Employee emp5 = new Employee("Jhon5", DateTime.Now.AddYears(0), EmployeeType.Manager);
            Employee emp6 = new Employee("Jhon6", DateTime.Now.AddYears(0), EmployeeType.Employee);
            Employee emp7 = new Employee("Jhon7", DateTime.Now.AddYears(0), EmployeeType.Sales);
            Employee emp8 = new Employee("Jhon8", DateTime.Now.AddYears(0), EmployeeType.Employee);


            manager.AddEmployeeInTree(emp2, emp1);
            manager.AddEmployeeInTree(emp3, emp1);
            manager.AddEmployeeInTree(emp4, emp1);

            manager.AddEmployeeInTree(emp5, emp2);
            manager.AddEmployeeInTree(emp6, emp2);
            manager.AddEmployeeInTree(emp7, emp2);
            manager.AddEmployeeInTree(emp8, emp7);

            // Act
            int actual = manager.GetSalary(emp1);

            // Assert 
            Assert.AreEqual(expected, actual);
        }
    }
}