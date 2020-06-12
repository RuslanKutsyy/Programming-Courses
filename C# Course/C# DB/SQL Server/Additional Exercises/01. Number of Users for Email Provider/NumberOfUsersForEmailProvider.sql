SELECT a.[Email Provider], COUNT(a.[Email Provider])
FROM (SELECT RIGHT(u.Email, LEN(u.Email) - CHARINDEX('@', u.Email)) AS 'Email Provider'
FROM Users AS u) AS a
GROUP BY a.[Email Provider] ORDER BY COUNT(a.[Email Provider]) DESC, a.[Email Provider]