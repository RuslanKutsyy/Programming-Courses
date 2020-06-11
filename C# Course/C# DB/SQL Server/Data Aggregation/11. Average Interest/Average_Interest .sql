SELECT a.DepositGroup, a.IsDepositExpired, AVG(a.DepositInterest) AS AverageInterest
FROM (SELECT wd.DepositGroup, wd.DepositInterest, wd.IsDepositExpired
FROM WizzardDeposits AS wd
WHERE wd.DepositStartDate > '01/01/1985') AS a
GROUP BY a.DepositGroup, a.IsDepositExpired
ORDER BY a.DepositGroup DESC, a.IsDepositExpired