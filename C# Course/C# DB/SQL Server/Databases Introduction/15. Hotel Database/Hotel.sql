CREATE DATABASE Hotel;
USE Hotel;

CREATE TABLE Employees (
	Id INT CONSTRAINT PK_EMP_ID PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Ivanov', 'Receptionist', 'Some note here'),
('Alex', 'Petrov', 'Concierge', 'Something here'),
('Sergey', 'Sergeev', 'Cleaner', 'Another note')

CREATE TABLE Customers (
	AccountNumber NVARCHAR(100) NOT NULL CONSTRAINT UN_ACCNUM UNIQUE,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(100) NOT NULL,
	EmergencyName NVARCHAR(100) NOT NULL,
	EmergencyNumber NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('123456789', 'Rus', 'Kut', '359888777888', 'Test Name', '7708315342', 'some note'),
('123480933', 'Ks', 'Mar', '359888777888', 'Test Name 1', '7708315342', 'some note 2'),
('123454432', 'Ir', 'Kut', '359888777888', 'Test Name 2', '7708315342', 'some note 3')


CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('Status 1','Refill the minibar'),
('Status 2','Check the towels'),
('Status 3', NULL)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('Suite', 'Two beds'),
('Wedding suite', 'One king size bed'),
('Apartment', 'Up to 3 adults and 2 children')

CREATE TABLE BedTypes(
	BedType NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType, Notes) VALUES
('Double', 'One adult and one child'),
('King size', 'Two adults'),
('Couch', 'One child')

CREATE TABLE Rooms (
	RoomNumber INT CONSTRAINT PK_ROOM_ID PRIMARY KEY,
	RoomType NVARCHAR(50) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Rate INT,
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(12, 'Suite', 'Double', NULL, 'Status', 'Some notes'),
(15, 'Wedding suite', 'Double', NULL, 'Status', 'Some notes 1'),
(13, 'Apartment', 'King size', NULL, 'Status', 'Some notes 2')

CREATE TABLE Payments(
	Id INT CONSTRAINT PK_PAY_ID PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber NVARCHAR(100) NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL,
	TaxRate DECIMAL,
	TaxAmount DECIMAL,
	PaymentTotal DECIMAL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, TotalDays, AmountCharged)
VALUES
(1, '12/12/2018', 2, 6, 2000.40),
(2, '12/12/2018', 3, 4, 1500.40),
(3, '12/12/2018', 1, 8, 1000.40)

CREATE TABLE Occupancies(
	Id INT CONSTRAINT PK_OCC_ID PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATE,
	AccountNumber NVARCHAR(100),
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber, RateApplied, Notes) VALUES
(1, '123456789', 13, 55.55, 'too'),
(2, '123455949', 12, 15.55, 'much'),
(3, '123457776', 10, 35.55, 'typing')