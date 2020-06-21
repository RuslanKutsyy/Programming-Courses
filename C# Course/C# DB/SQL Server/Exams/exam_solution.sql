--01. DDL

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode VARCHAR(2) NOT NULL CHECK(LEN(CountryCode) = 2)
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15, 2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id),
	Luggage INT NOT NULL
	PRIMARY KEY (AccountId, TripId)
)


--02. Insert

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16',	'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20',	'2015-02-02'),
(102, '2015-07-07',	'2015-07-15', '2015-07-22',	'2015-04-29'),
(103, '2013-07-17',	'2013-07-23', '2013-07-24',	NULL),
(104, '2012-03-17',	'2012-03-31', '2012-04-01',	'2012-01-10'),
(109, '2017-08-07',	'2017-08-28', '2017-08-29',	NULL)


--03. Update

UPDATE Rooms
SET Price = Price * 1.14
WHERE HotelId IN (5, 7, 9)


--04. Delete

DELETE FROM AccountsTrips
WHERE AccountId = 47

SELECT COUNT(*) FROM AccountsTrips


--05. EEE-Mails

SELECT a.FirstName, a.LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
		c.Name AS Hometown, a.Email
FROM Accounts as a
JOIN Cities AS c
	ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY Hometown


--06. City Statistics

SELECT c.Name AS City, COUNT(h.Id) AS Hotels
FROM Hotels AS h
JOIN Cities AS c
	ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC, City

--07. Longest and Shortest Trips
SELECT info.AccountId, info.FullName, MAX(info.LongestTrip) AS LongestTrip,
		MIN(info.ShortestTrip) AS ShortestTrip
FROM 
(SELECT  atr.AccountId,
		a.FirstName + ' ' + a.LastName AS FullName,
		DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS LongestTrip,
		DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS ShortestTrip
FROM Trips AS t
JOIN AccountsTrips AS atr
	ON t.Id = atr.TripId
JOIN Accounts AS a
	ON atr.AccountId = a.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL) AS info
GROUP BY info.AccountId, info.FullName
ORDER BY LongestTrip DESC, ShortestTrip


--08. Metropolis

SELECT TOP(10) c.Id, c.Name AS City,
		c.CountryCode AS Country,
		COUNT(a.Id) AS Accounts
FROM Cities AS c
JOIN Accounts AS a
	ON c.Id = a.CityId
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC


--09. Romantic Getaways


SELECT * FROM 
(SELECT ac.Id, ac.Email, c.Name AS City, COUNT(atr.TripId) AS Trips
FROM Accounts AS ac
JOIN AccountsTrips AS atr
	ON ac.Id = atr.AccountId
JOIN Trips AS tr
	ON atr.TripId = tr.Id
JOIN Rooms AS r
	ON r.Id = tr.RoomId
JOIN Hotels AS h
	ON h.Id = r.HotelId
JOIN Cities AS c
	ON c.Id = h.CityId
WHERE ac.CityId = h.CityId
GROUP BY ac.Id, ac.Email, c.Name) AS info
WHERE info.Trips >= 1
ORDER BY info.Trips DESC, info.Id


--10. GDPR Violation

SELECT  tr.Id,
		acc.FirstName + ' ' + ISNULL(acc.MiddleName, '') + ' ' + acc.LastName AS [Full Name],
		cFrom.Name AS [From],
		cTo.Name AS [To],
		CASE
			WHEN (tr.CancelDate IS NULL) THEN CONCAT(DATEDIFF(DAY, tr.ArrivalDate, tr.ReturnDate), ' days')
			ELSE 'Canceled'
		END AS Duration
FROM Trips AS tr
JOIN AccountsTrips AS atr
	ON tr.Id = atr.TripId
JOIN Accounts AS acc
	ON atr.AccountId = acc.Id
JOIN Cities AS cFrom
	ON cFrom.Id = acc.CityId
JOIN Rooms AS r
	ON r.Id = tr.RoomId
JOIN Hotels AS h
	ON h.Id = r.HotelId
JOIN Cities AS cTo
	ON cTo.Id = h.CityId
ORDER BY [Full Name], tr.Id

GO

--11. Available Room (IN Progress)

CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
DECLARE @result NVARCHAR(MAX);
DECLARE @takenRoomId INT;
DECLARE @roomTable TABLE (
	Id INT NOT NULL,
	[Type] NVARCHAR(MAX) NOT NULL,
	Beds INT NOT NULL,
	Price MONEY NOT NULL
)

SET @takenRoomId = (SELECT TOP(1) r.Id
		FROM Rooms AS r
		JOIN Trips AS tr
			ON tr.RoomId = r.Id
		WHERE r.HotelId = @HotelId
		AND tr.CancelDate IS NULL AND r.Beds >= @People
		AND (@Date NOT BETWEEN tr.ArrivalDate AND tr.ReturnDate)
		ORDER BY r.Price DESC);

IF(@takenRoomId IS NOT NULL)
BEGIN
	RETURN 'No rooms available';
END

INSERT INTO @roomTable
SELECT TOP(1) r.Id, r.Type, r.Beds, r.Price
	FROM Rooms AS r
	JOIN Trips AS tr
		ON tr.RoomId = r.Id
	WHERE r.HotelId = @HotelId
	AND tr.CancelDate IS NULL AND r.Beds >= @People
	AND (@Date NOT BETWEEN tr.ArrivalDate AND tr.ReturnDate)
	ORDER BY r.Price DESC;

DECLARE @roomID INT = (SELECT Id FROM @roomTable);
DECLARE @roomType NVARCHAR(MAX) = (SELECT [Type] FROM @roomTable);
DECLARE @rooBedsCount INT = (SELECT Beds FROM @roomTable);
DECLARE @roomPrice MONEY = (SELECT Price FROM @roomTable);
DECLARE @HotelBaseRate MONEY = CAST((SELECT h.BaseRate FROM Hotels AS h WHERE h.Id = @HotelId) AS MONEY);
DECLARE @PRICE MONEY = (@HotelBaseRate + @roomPrice) * @People;

SET @result = CONCAT('Room ', @roomID, ': ', @roomType, ' (', @rooBedsCount, ' beds) - $', @PRICE);

RETURN @result
END

GO