-- Problem 1 - Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS (SELECT e.FirstName, e.LastName
FROM Employees AS e
WHERE e.Salary > 35000)
GO

EXEC usp_GetEmployeesSalaryAbove35000
GO

-- Problem 2 - Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@SalaryLevel DECIMAL(18,4))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @SalaryLevel

GO