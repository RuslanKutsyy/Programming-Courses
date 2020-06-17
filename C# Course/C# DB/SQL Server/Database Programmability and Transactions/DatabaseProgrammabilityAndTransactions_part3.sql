-- Problem 14 - Create Table Logs

CREATE TABLE Logs (
	LogId INT NOT NULL IDENTITY,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO

CREATE TRIGGER tr_AccountBalanceUpdate ON Accounts
AFTER UPDATE
AS
	INSERT INTO Logs
	VALUES 
	(
		(SELECT i.Id FROM inserted AS i),
		(SELECT d.Balance FROM deleted AS d),
		(SELECT i.Balance FROM inserted AS i)
	)

GO