SELECT COUNT(e.Salary) AS Count
FROM Employees AS e
WHERE e.ManagerID IS NULL