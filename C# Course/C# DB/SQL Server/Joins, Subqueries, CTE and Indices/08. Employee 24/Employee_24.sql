SELECT ep.EmployeeID, e.FirstName,
CASE
	WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
	ELSE p.Name
END AS 'ProjectName'
FROM EmployeesProjects AS ep
JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
JOIN Projects as p on ep.ProjectID = p.ProjectID
WHERE ep.EmployeeID = 24