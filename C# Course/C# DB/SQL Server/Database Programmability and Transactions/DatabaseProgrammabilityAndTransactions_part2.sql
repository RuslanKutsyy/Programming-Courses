-- Problem 9 - Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
	FROM AccountHolders AS ah

GO

-- Problem 10 - People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@balanceLevel DECIMAL(16,2))
AS
	SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
	FROM AccountHolders AS ah
	JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @balanceLevel
	ORDER BY ah.FirstName, ah.LastName

GO

-- Problem 11 - Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY, @yearInterestRate float, @numOfYears INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @futureSum MONEY;
	SET @futureSum = @sum * POWER(1 + @yearInterestRate, @numOfYears);
	SET @futureSum = ROUND(@futureSum, 4);
	RETURN @futureSum;
END

GO