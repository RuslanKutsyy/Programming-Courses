SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,
(SELECT m.FirstName + ' ' + m.LastName
FROM Employees AS m
WHERE m.EmployeeID = e.ManagerID) AS ManagerName,
(SELECT d.Name FROM Departments AS d
WHERE d.DepartmentID = e.DepartmentID) AS DepartmentName
FROM Employees AS e
ORDER BY e.EmployeeID