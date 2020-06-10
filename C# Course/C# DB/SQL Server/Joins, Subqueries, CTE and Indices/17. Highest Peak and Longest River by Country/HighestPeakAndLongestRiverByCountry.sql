SELECT TOP(5) a.CountryName, a.HighestPeakElevation, a.LongestRiverLength
FROM (SELECT c.CountryName, p.Elevation AS HighestPeakElevation, r.Length AS LongestRiverLength,
DENSE_RANK() OVER (
PARTITION BY c.CountryName ORDER BY p.Elevation DESC, r.Length DESC) AS [Rank]
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Peaks AS p ON p.MountainId = mc.MountainId
JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
JOIN Rivers AS r ON r.Id = cr.RiverId) AS a
WHERE a.Rank = 1
ORDER BY a.HighestPeakElevation DESC, a.LongestRiverLength DESC, a.CountryName