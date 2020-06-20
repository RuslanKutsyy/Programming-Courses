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


--05. The "Tr" Planes

SELECT p.Id, p.Name, p.Seats, p.Range FROM Planes AS p
WHERE p.Name LIKE '%tr%'

--06. Flight Profits

SELECT t.FlightId, SUM(t.Price) AS Price
FROM Tickets as t
GROUP BY t.FlightId
ORDER BY Price DESC, t.FlightId


--07. Passenger Trips

SELECT  p.FirstName + ' ' + p.LastName AS [Full Name],
		f.Origin,
		f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination


--08. Non Adventures People

SELECT p.FirstName, p.LastName, p.Age
FROM Passengers as p
WHERE p.Id NOT IN
(SELECT t.PassengerId FROM Tickets AS t)
ORDER BY P.Age DESC, p.FirstName, p.LastName


--09. Full Info

SELECT  p.FirstName + ' ' + p.LastName AS [Full Name],
		pl.Name AS [Plane Name],
		f.Origin + ' - ' + f.Destination AS [Trip],
		lt.Type AS [Luggage Type]
FROM Tickets AS t
JOIN Passengers AS p
	ON t.PassengerId = p.Id
JOIN Flights AS f
	ON t.FlightId = f.Id
JOIN Planes AS pl
	ON f.PlaneId = pl.Id
JOIN Luggages AS l
	ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt
	ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name],
		 f.Origin, f.Destination, [Luggage Type]


--10. PSP

SELECT p.Name, p.Seats, COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f
	ON p.Id = f.PlaneId
LEFT JOIN Tickets AS t
	ON f.Id = t.FlightId
GROUP BY p.Name, p.Seats
ORDER BY [Passengers Count] DESC, p.Name, p.Seats

GO
--11. Vacation

CREATE OR ALTER FUNCTION udf_CalculateTickets (@origin NVARCHAR(100), @destination NVARCHAR(100), @peopleCount INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

IF(@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!';
	END

DECLARE @flightID INT = (SELECT f.Id FROM Flights AS f
						JOIN Tickets AS t ON f.Id = t.FlightId
						WHERE Origin = @origin AND
						Destination = @destination);
		
IF (@flightID IS NULL)
	BEGIN
		RETURN 'Invalid flight!';
	END

DECLARE @ticketPrice MONEY = (SELECT Price FROM Tickets AS t
					JOIN Flights AS f ON t.FlightId = f.Id
					WHERE f.Origin = @origin and f.Destination = @destination);
DECLARE @totalPrice MONEY = @ticketPrice * @peopleCount;
RETURN CONCAT('Total price ', @totalPrice);
END

GO