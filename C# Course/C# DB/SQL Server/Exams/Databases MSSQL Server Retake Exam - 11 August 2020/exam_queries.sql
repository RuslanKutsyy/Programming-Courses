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