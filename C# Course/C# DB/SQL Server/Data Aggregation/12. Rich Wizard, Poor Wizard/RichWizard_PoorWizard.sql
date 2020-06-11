SELECT SUM(wd.DepositAmount - a.DepositAmount) AS SumDifference
FROM WizzardDeposits AS wd
JOIN WizzardDeposits AS a ON a.Id = wd.Id + 1