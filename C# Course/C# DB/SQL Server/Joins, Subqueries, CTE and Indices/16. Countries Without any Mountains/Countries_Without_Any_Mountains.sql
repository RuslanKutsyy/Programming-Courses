SELECT COUNT(c.CountryCode) AS [Count]
FROM Countries AS c
WHERE c.CountryCode NOT IN
(SELECT mc.CountryCode
FROM MountainsCountries AS mc)