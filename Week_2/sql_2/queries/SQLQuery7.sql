-- Drop and recreate the table (if no important data)
DROP PROCEDURE IF EXISTS sp_InsertEmployee;
DROP TABLE IF EXISTS Employees;

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

