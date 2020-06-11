SELECT *
FROM(SELECT LEFT(wd.FirstName, 1) AS FirstLetter
FROM WizzardDeposits AS wd
WHERE wd.DepositGroup LIKE 'Troll Chest') AS a
GROUP BY a.FirstLetter