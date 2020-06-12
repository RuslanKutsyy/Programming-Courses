SELECT DISTINCT g.Name AS 'Game', gt.Name AS 'Game Type', u.Username, ug.Level, ug.Cash, ch.Name AS 'Character'
FROM Games AS g, UsersGames AS ug, UserGameItems AS ugi, Users AS u,
GameTypes AS gt, Characters AS ch
WHERE u.Id = ug.UserId AND ug.GameId = ugi.UserGameId
AND ug.GameId = g.Id AND g.GameTypeId = gt.Id
AND ug.CharacterId = ch.Id
ORDER BY ug.Level DESC, u.Username, g.Name