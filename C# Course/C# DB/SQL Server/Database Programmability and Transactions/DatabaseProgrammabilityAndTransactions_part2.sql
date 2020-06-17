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

-- Problem 12 - Calculating Interest

CREATE PROCEDURE usp_CalculateFutureValueForAccount @AccountId INT, @InterestRate FLOAT
AS
	SELECT a.Id AS [Account Id], ah.FirstName AS [First Name],
	ah.LastName AS [Last Name], a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId

GO

-- Problem 13 - *Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(MAX))
RETURNS TABLE AS
RETURN
		SELECT SUM(a.Cash) AS [SumCash] FROM
		(SELECT ug.Cash AS Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS [RowNum], g.Name
		FROM UsersGames AS ug
		JOIN Games AS g ON g.Id = ug.GameId
		WHERE g.Name = @gameName) AS a
		WHERE a.RowNum % 2 = 1

GO