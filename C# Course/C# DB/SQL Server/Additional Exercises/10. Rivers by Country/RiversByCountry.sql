SELECT c.CountryName, cont.ContinentName, COUNT(cr.RiverId) AS [RiversCount], 
CASE
	WHEN (SUM(r.Length) IS NULL) THEN 0
	ELSE SUM(r.Length)
END AS [TotalLength]
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers AS r
	ON cr.RiverId = r.Id
JOIN Continents AS cont
	ON cont.ContinentCode = c.ContinentCode
GROUP BY c.CountryName, cont.ContinentName
ORDER BY COUNT(cr.RiverId) DESC, [TotalLength] DESC, c.CountryName