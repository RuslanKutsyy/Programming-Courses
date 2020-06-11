SELECT a.DepositGroup, SUM(a.DepositAmount) AS TotalSum
FROM (SELECT wd.DepositGroup, wd.DepositAmount, wd.MagicWandCreator
FROM WizzardDeposits AS wd) AS a
WHERE a.MagicWandCreator LIKE 'Ollivander family'
GROUP BY a.DepositGroup
HAVING SUM(a.DepositAmount) < 150000
ORDER BY TotalSum DESC