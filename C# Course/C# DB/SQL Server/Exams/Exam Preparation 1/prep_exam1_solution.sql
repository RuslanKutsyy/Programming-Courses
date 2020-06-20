--01. DDL

CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights 
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	Address VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30)
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id)  NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id)  NOT NULL,
	Price DECIMAL(15,2) NOT NULL
)


--02. Insert

INSERT INTO Planes (Name, Seats, Range)
VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432,	5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387,	1342),
('Boeing 128', 345,	5541)

INSERT INTO LuggageTypes (Type)
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')


--03. Update

UPDATE Tickets
SET Price = 1.13 * Price
WHERE Tickets.FlightId IN
(SELECT f.Id FROM Flights AS f
WHERE f.Destination = 'Carlsbad')


--04. Delete

DELETE FROM Tickets
WHERE FlightId IN
(SELECT Id FROM Flights
WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'