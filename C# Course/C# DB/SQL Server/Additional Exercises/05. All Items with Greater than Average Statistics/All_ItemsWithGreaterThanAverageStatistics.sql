SELECT i.Name, i.Price, i.MinLevel, stat.Strength, stat.Defence, stat.Speed, stat.Luck, stat.Mind
FROM Items AS i, [Statistics] AS stat, 
(SELECT AVG(stat.Mind) AS AVGMind, AVG(stat.Luck) AS AVGLuck, AVG(stat.Speed) AS AVGSpeed
FROM [Statistics] AS stat) AS a
WHERE stat.Mind > a.AVGMind AND stat.Luck > a.AVGLuck
AND stat.Speed > a.AVGSpeed AND i.StatisticId = stat.Id