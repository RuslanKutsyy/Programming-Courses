SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries mc
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE mc.CountryCode LIKE 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC