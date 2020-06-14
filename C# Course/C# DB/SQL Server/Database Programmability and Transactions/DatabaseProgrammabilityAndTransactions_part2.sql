-- Problem 9 - Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
	FROM AccountHolders AS ah

GO