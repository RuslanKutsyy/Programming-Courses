SELECT mc.CountryCode, COUNT(mc.CountryCode) AS MountainRange
FROM MountainsCountries AS mc
WHERE mc.CountryCode LIKE 'BG' OR mc.CountryCode LIKE 'RU' OR mc.CountryCode LIKE 'US'
GROUP BY CountryCode