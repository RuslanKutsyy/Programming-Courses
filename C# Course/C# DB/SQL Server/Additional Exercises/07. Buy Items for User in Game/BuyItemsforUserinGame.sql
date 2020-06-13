DECLARE @gameName NVARCHAR(20) = 'Edinburgh'
DECLARE @username NVARCHAR(20) = 'Alex'

DECLARE @userGameID INT = (
	SELECT ug.Id
	FROM UsersGames AS ug
	JOIN Users AS u ON ug.UserId = u.Id
	JOIN Games AS g ON ug.GameId = g.Id
	WHERE u.Username = @username
	AND g.Name = @gameName
)

DECLARE @gameCash MONEY = (
	SELECT ug.Cash
	FROM UsersGames AS ug
	WHERE ug.Id = @userGameID
)

DECLARE @purchaseCash MONEY = (
	SELECT SUM(I.Price)
	FROM Items AS i
	WHERE i.Name IN ('Blackguard', 'Bottomless Potion of Amplification',
	'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin',
	'Golden Gorget of Leoric and Hellfire Amulet')
)

IF(@purchaseCash <= @gameCash)
	BEGIN
		UPDATE UsersGames
		SET Cash -= @purchaseCash
		WHERE Id = @userGameID

		INSERT INTO UserGameItems (ItemId, UserGameId)
			(SELECT i.Id, @userGameID FROM Items AS i
			WHERE i.Name IN ('Blackguard', 'Bottomless Potion of Amplification',
			'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin',
			'Golden Gorget of Leoric and Hellfire Amulet'))
	END
ELSE RAISERROR ('Could not buy items', 16, 1)

SELECT u.Username, g.Name, ug.Cash, i.Name AS [Item Name]
FROM UsersGames AS ug
JOIN Users AS u 
	ON ug.UserId = u.Id
JOIN UserGameItems AS ugi 
	ON ugi.UserGameId = ug.Id
JOIN Games AS g 
	ON ug.GameId = g.Id
JOIN Items AS i 
	ON i.Id = ugi.ItemId
	WHERE g.Name = @gameName