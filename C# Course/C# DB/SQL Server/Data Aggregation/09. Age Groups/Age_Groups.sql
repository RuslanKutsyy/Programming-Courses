SELECT a.AgeGroup, COUNT(a.AgeGroup) as WizardCount
FROM (SELECT 
CASE
	WHEN wd.Age <= 10 THEN '[0-10]'
	WHEN wd.Age >= 11 AND wd.Age <= 20 THEN '[11-20]'
	WHEN wd.Age >= 21 AND wd.Age <= 30 THEN '[21-30]'
	WHEN wd.Age >= 31 AND wd.Age <= 40 THEN '[31-40]'
	WHEN wd.Age >= 41 AND wd.Age <= 50 THEN '[41-50]'
	WHEN wd.Age >= 50 AND wd.Age <= 60 THEN '[51-60]'
	WHEN wd.Age >= 61 THEN '[61+]'
END AS AgeGroup
FROM WizzardDeposits AS wd) AS a
GROUP BY a.AgeGroup