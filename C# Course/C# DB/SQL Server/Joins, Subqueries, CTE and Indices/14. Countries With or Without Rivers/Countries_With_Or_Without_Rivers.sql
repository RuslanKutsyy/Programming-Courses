SELECT TOP(5) c.CountryName,
(SELECT RiverName FROM Rivers WHERE Id = cr.RiverId) AS RiverName
FROM CountriesRivers AS cr
RIGHT JOIN Countries AS c ON cr.CountryCode = c.CountryCode
WHERE c.ContinentCode LIKE 'AF'
ORDER BY CountryName