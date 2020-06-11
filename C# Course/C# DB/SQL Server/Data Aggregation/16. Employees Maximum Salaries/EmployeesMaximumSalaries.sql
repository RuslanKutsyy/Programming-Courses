SELECT *
FROM (SELECT e.DepartmentID, MAX(e.Salary) AS MaxSalary
FROM Employees AS e
GROUP BY e.DepartmentID) AS a
WHERE a.MaxSalary NOT BETWEEN 30000 AND 70000