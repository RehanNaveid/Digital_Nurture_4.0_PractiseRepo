SELECT DepartmentID, COUNT(*) AS NumEmployees
FROM Employees
GROUP BY DepartmentID;
