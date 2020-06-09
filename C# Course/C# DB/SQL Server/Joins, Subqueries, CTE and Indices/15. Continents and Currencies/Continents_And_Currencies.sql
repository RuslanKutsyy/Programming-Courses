SELECT a.ContinentCode, a.CurrencyCode, a.CurrencyUsage
FROM (
SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS [CurrencyUsage],
DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode) AS a
WHERE a.Rank = 1 AND a.CurrencyUsage > 1