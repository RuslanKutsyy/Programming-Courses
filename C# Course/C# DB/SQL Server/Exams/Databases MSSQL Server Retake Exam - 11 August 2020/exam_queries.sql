--01. DDL

CREATE TABLE Countries
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Customers
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender NVARCHAR(1) NOT NULL CHECK(GENDER IN ('M', 'f')),
	Age INT NOT NULL,
	PhoneNumber VARCHAR(MAX) CHECK(LEN(PhoneNumber) = 10),
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX) NOT NULL,
	Price MONEY NOT NULL CHECK(Price > 0)
)

CREATE TABLE Feedbacks
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Rate Decimal NOT NULL CHECK(Rate > 0 AND Rate <= 10),
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	AddressText  NVARCHAR(30) NOT NULL,
	[Summary] NVARCHAR(200) NOT NULL,
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[Description] NVARCHAR(200),
	OriginCountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT NOT NULL FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT NOT NULL FOREIGN KEY REFERENCES Ingredients(Id)

	CONSTRAINT PK_ProductIngredients PRIMARY KEY (ProductId, IngredientId)
)

GO;

--02. Insert

INSERT INTO Distributors([Name], CountryId, AddressText, Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People',	1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')


INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud',	22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

GO;

--03. Update

UPDATE Ingredients
SET DistributorId = 35
WHERE Name = 'Bay Leaf' OR Name = 'Paprika' OR Name = 'Poppy'

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

GO;

--04. Delete

DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

GO;

--05. Products By Price

SELECT p.Name, p.Price, p.Description
FROM Products as p
ORDER BY p.Price DESC, p.Name

GO;

--06. Negative Feedback

SELECT f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < 5
ORDER BY f.ProductId DESC, f.Rate

GO;

--07. Customers without Feedback
--3 OUF 6 FOR NOW
SELECT c.FirstName + ' ' + c.LastName AS CustomerName,
	   c.PhoneNumber,
	   c.Gender
FROM Customers AS c
WHERE c.Id NOT IN 
(SELECT f.CustomerId FROM Feedbacks AS f)
ORDER BY c.Id

SELECT d.CustomerName, d.PhoneNumber, d.Gender
FROM (SELECT c.FirstName + ' ' + c.LastName AS CustomerName,
	   c.PhoneNumber,
	   c.Gender, COUNT(f.Id) as FeedbackCount,
	   c.Id
FROM Customers AS c
LEFT JOIN Feedbacks AS f
	ON c.Id = f.CustomerId
GROUP BY c.Id, c.FirstName + ' ' + c.LastName, c.PhoneNumber, c.Gender) AS d
WHERE d.FeedbackCount = 0
ORDER BY D.Id

GO;

--08. Customers by Criteria

SELECT c.FirstName, c.Age, c.PhoneNumber
FROM Customers AS c
JOIN Countries AS cnt
	ON C.CountryId = cnt.Id
WHERE (c.Age >= 21 AND C.FirstName LIKE '%an%') OR (c.PhoneNumber LIKE '%38' AND cnt.Name NOT LIKE 'Greece')
ORDER BY c.FirstName, c.Age DESC

GO;

--09. Middle Range Distributors

SELECT *
FROM (SELECT  dist.Name AS DistributorName,
		i.Name AS IngredientName,
		prod.Name AS ProductName,
		AVG(f.Rate) AS AverageRate
FROM Ingredients AS i
JOIN ProductsIngredients AS pi
	ON i.Id = pi.IngredientId
JOIN Products AS prod
	ON pi.ProductId = prod.Id
JOIN Distributors AS dist
	ON i.DistributorId = dist.Id
JOIN Feedbacks AS f
	ON prod.Id = f.ProductId
GROUP BY dist.Name, i.Name, prod.Name) AS d
WHERE d.AverageRate >= 5 AND d.AverageRate <= 8
ORDER BY d.DistributorName, d.IngredientName, d.ProductName

GO;

--10. Country Representative

SELECT d.CountryName, d.DisributorName
FROM (SELECT  c.Name AS CountryName,
		dist.Name AS DisributorName,
		COUNT(ing.Id) AS IngredientsCount,
		DENSE_RANK()
		OVER(PARTITION BY c.Name ORDER BY COUNT(ing.Id) DESC) AS [Rank]
FROM Countries AS c
LEFT JOIN Distributors AS dist
	ON c.Id = dist.CountryId
LEFT JOIN Ingredients AS ing
	ON dist.Id = ing.DistributorId
GROUP BY c.Name, dist.Name) AS d
WHERE d.Rank = 1

GO;

--11. Customers With Countries

CREATE VIEW v_UserWithCountries AS
SELECT  c.FirstName + ' ' + c.LastName AS CustomerName,
		C.Age,
		c.Gender,
		cnt.Name
FROM Customers AS c
JOIN Countries AS cnt
	ON c.CountryId = cnt.Id

SELECT TOP 5 *
 FROM v_UserWithCountries
ORDER BY Age

GO;

--12. Delete Products

CREATE TRIGGER tr_DeleteProducts
    ON Products
    INSTEAD OF DELETE
AS
  BEGIN
	DELETE
	FROM Feedbacks
	WHERE ProductId IN 
	(SELECT P.Id FROM Products AS P
	JOIN deleted AS D
		ON P.Id = D.Id)

	DELETE FROM ProductsIngredients
	WHERE ProductId IN 
	(SELECT P.Id FROM Products AS P
	JOIN deleted AS D
		ON P.Id = D.Id)

	DELETE FROM Products
	WHERE Products.Id  IN 
	(SELECT P.Id FROM Products AS P
	JOIN deleted AS D
		ON P.Id = D.Id)
  END

Delete from Products
where Id = 30

DELETE FROM Feedbacks
WHERE ProductId = 5

GO;