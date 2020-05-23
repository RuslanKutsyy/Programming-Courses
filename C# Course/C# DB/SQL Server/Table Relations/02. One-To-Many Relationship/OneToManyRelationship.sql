CREATE TABLE Manufacturers (
	ManufacturerID INT CONSTRAINT PK_MANUFACTURER_ID PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers ([Name], EstablishedOn) VALUES
('BMW',	'07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

CREATE TABLE Models (
	ModelID INT NOT NULL CONSTRAINT PK_MODEL_ID PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL CONSTRAINT FK_MANUFACTURER_ID REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models (ModelID, Name, ManufacturerID) VALUES
(101, 'X1',	1),
(102, 'i6',	1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)