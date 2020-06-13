SELECT p.PeakName, m.MountainRange AS [Mountain], c.CountryName, cont.ContinentName
FROM Peaks AS p
JOIN Mountains AS m
	ON p.MountainId = m.Id
JOIN MountainsCountries AS mc
	ON p.MountainId = mc.MountainId
JOIN Countries AS c
	ON c.CountryCode = mc.CountryCode
JOIN Continents AS cont
	ON cont.ContinentCode = c.ContinentCode
ORDER BY p.PeakName, c.CountryName