
CompanyTree.dll  is a group of classes which allows to organize the hierarchy of company’s employees.
There are a model of an employee and a CompanyTreeManager which is used to manage the whole system, to create the tree, to add or to remove employees, 
as well as to return the employee’s salary and the total sum of the salaries of the whole company.
The salary calculation is proceeded according to the technical task. There is an abstract TreeAbstractManager class in the system with its corresponding
abstract functions, and in case of necessity another CompanyTreeManager can be created with different logic.

There is also a CompanyTreeTest project in the solution which covers all the important functionality and shows the proper operation of the system.
The operations and work of the DLL can also be checked with the test-project in other projects.

The functionality of the DLL can, for example, be expanded by adding employee class fields and making it a complex employee object.
Also another manage class can be added which will operate to keep the structure of the company in the database or in Json and XML files
and to bind the structure from the mentioned sources; afterwards to use it to create employees’ profiles and to visualize the company tree on Intranet.


In addition to this, the company tree can be organized according to the positions and each employee can be attached to the certain position node.