SELECT wd.DepositGroup, MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup