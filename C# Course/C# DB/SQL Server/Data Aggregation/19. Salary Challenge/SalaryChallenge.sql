SELECT TOP(10) a.FirstName, a.LastName, a.DepartmentID
FROM Employees AS a
JOIN (SELECT e.DepartmentID, AVG(e.Salary) AS AVGSALARY
FROM Employees AS e
GROUP BY e.DepartmentID) AS e ON e.DepartmentID = a.DepartmentID
WHERE a.Salary > e.AVGSALARY