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

-- Problem 3 - Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith @StartPhrase VARCHAR(MAX)
AS
	SELECT t.Name
	FROM Towns AS t
	WHERE LEFT(t.Name, LEN(@StartPhrase)) LIKE @StartPhrase

GO

-- Problem 4 - Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(50)
AS
	SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]
	FROM Employees AS e
	JOIN Addresses AS ad
		ON e.AddressID = ad.AddressID
	JOIN Towns AS t
		ON ad.TownID = t.TownID
	WHERE t.Name = @townName

GO

EXEC usp_GetEmployeesFromTown @townName = 'Sofia'

GO
