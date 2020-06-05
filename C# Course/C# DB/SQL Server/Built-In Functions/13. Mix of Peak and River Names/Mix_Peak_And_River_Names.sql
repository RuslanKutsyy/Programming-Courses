SELECT p.PeakName, r.RiverName,
LOWER(p.PeakName + RIGHT(r.RiverName, LEN(r.RiverName) - 1)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r ON RIGHT(p.PeakName, 1) LIKE LOWER(LEFT(r.RiverName, 1))
ORDER BY Mix