SELECT g.Name AS 'Game', gt.Name AS 'Game Type', u.Username, ug.Level,
ug.Cash, ch.Name
FROM Games AS g
JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
JOIN UsersGames AS ug ON g.Id = ug.GameId
JOIN Users AS u ON u.Id = ug.UserId
JOIN Characters AS ch ON ug.CharacterId = ch.Id
ORDER BY ug.Level DESC, u.Username, g.Name