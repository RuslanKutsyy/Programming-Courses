UPDATE Countries
	SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries (Name, CountryCode)
(
	SELECT 'Hanga Abbey',
		    CountryCode
	FROM Countries
	WHERE CountryName='Tanzania'
)

INSERT INTO Monasteries (Name, CountryCode)
  (SELECT
     'Myin-Tin-Daik',
     CountryCode
   FROM Countries
WHERE CountryName = 'Myanmar')

SELECT cont.ContinentName, c.CountryName, COUNT(mon.Id) AS [MonasteriesCount]
FROM Countries AS c
JOIN Continents AS cont
	ON c.ContinentCode = cont.ContinentCode
LEFT JOIN Monasteries AS mon
	ON c.CountryCode = mon.CountryCode
WHERE c.IsDeleted = 0
GROUP BY c.CountryName, cont.ContinentName
ORDER BY [MonasteriesCount] DESC, c.CountryName