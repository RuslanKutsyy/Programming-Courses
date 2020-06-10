SELECT a.DepositGroup, SUM(a.DepositAmount) AS TotalSum
FROM (SELECT wd.DepositGroup, wd.MagicWandCreator, wd.DepositAmount
FROM WizzardDeposits AS wd
WHERE wd.MagicWandCreator LIKE 'Ollivander family') AS a
GROUP BY a.DepositGroup