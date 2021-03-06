SELECT cont.ContinentName, SUM(c.AreaInSqKm) AS [CountriesArea], SUM(CAST(C.Population AS BIGINT)) AS [CountriesPopulation]
FROM Continents AS cont
LEFT JOIN Countries AS c
	ON cont.ContinentCode = c.ContinentCode
GROUP BY cont.ContinentName
ORDER BY [CountriesPopulation] DESC