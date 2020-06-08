SELECT TOP(1) * FROM
(SELECT AVG(e.Salary) as MinAverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID) AS a
ORDER BY a.MinAverageSalary