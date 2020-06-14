-- Problem 1 - Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS (SELECT e.FirstName, e.LastName
FROM Employees AS e
WHERE e.Salary > 35000)

EXEC usp_GetEmployeesSalaryAbove35000