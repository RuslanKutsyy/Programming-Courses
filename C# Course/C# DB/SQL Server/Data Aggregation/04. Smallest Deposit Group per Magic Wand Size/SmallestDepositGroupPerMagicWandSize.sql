SELECT TOP(2) a.DepositGroup
FROM (SELECT wd.DepositGroup, AVG(wd.MagicWandSize) AS Size
FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup) AS a
ORDER BY a.Size