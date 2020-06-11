SELECT DISTINCT a.DepartmentID, a.Salary
FROM (SELECT e.DepartmentID, e.Salary,
DENSE_RANK() OVER (PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS [Rank]
FROM Employees AS e) AS a
WHERE a.Rank = 3