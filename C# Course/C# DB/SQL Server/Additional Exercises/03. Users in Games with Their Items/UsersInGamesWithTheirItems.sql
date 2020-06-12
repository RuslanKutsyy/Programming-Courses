SELECT u.Username, g.Name AS Game, COUNT(ugi.ItemId) AS 'Items Count', SUM(i.Price) AS 'Items Price'
FROM Users AS u
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name 
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY COUNT(ugi.ItemId) DESC, SUM(i.Price) DESC, u.Username