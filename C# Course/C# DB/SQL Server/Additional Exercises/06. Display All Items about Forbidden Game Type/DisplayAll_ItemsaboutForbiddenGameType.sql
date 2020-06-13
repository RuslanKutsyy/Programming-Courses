SELECT i.Name AS Item, i.Price, i.MinLevel, gt.Name AS 'Forbidden Game Type'
FROM Items AS i
LEFT OUTER JOIN GameTypeForbiddenItems AS gtfi ON i.Id = gtfi.ItemId
LEFT OUTER JOIN GameTypes AS gt ON gt.Id = gtfi.GameTypeId
ORDER BY gt.Name DESC, i.Name