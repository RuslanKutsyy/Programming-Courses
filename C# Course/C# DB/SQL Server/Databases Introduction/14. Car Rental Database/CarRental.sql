CREATE TABLE Categories (
	Id INT NOT NULL CONSTRAINT PK_Cat_Id PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(MAX) NOT NULL,
	DailyRate DECIMAL NOT NULL,
	WeeklyRate DECIMAL NOT NULL,
	MonthlyRate DECIMAL NOT NULL,
	WeekendRate DECIMAL NOT NULL
);
CREATE TABLE Cars (
	Id INT NOT NULL CONSTRAINT PK_Cars_Id PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(50) NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture NVARCHAR(MAX) NOT NULL,
	Condition NVARCHAR(MAX) NOT NULL,
	Available VARCHAR(50) NOT NULL
);
CREATE TABLE Employees (
	Id INT NOT NULL CONSTRAINT PK_EMPL_ID PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);
CREATE TABLE Customers(
	Id INT NOT NULL CONSTRAINT PK_CUST_ID PRIMARY KEY IDENTITY,
	DriverLicenceNumber NVARCHAR(100) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode NVARCHAR(20),
	Notes NVARCHAR(MAX)
);
CREATE TABLE RentalOrders (
	Id INT NOT NULL CONSTRAINT PK_RENT_ID PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied NVARCHAR(50) NOT NULL,
	TaxRate DECIMAL NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);
INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Category', 10.5, 10.5, 10.5, 10.5),
('Category', 10.5, 10.5, 10.5, 10.5),
('Category', 10.5, 10.5, 10.5, 10.5);
INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('CA 1234 CC', 'Maker', 'model', '2018', 1, 3, 'picture', 'car_condition', 'Yes'),
('CA 1234 CC', 'Maker', 'model', '2018', 1, 3, 'picture', 'car_condition', 'Yes'),
('CA 1234 CC', 'Maker', 'model', '2018', 1, 3, 'picture', 'car_condition', 'Yes');
INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('FirstName', 'LastName', 'title', 'notes'),
('FirstName2', 'LastName2', 'title', 'notes'),
('FirstName3', 'LastName3', 'title', 'notes');
INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('111111111111111', 'FullName', 'address', 'city', 1528, 'notes'),
('111111111111111', 'FullName2', 'address', 'city', 1528, 'notes'),
('111111111111111', 'FullName3', 'address', 'city', 1528, 'notes');
INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(2, 1, 3, 44.4, 100000, 100500, 100, '2018-01-02', '2018-01-18', 3, 'rate_applied', 20.5, 'order_status', 'notes'),
(2, 1, 3, 44.4, 100000, 100500, 100, '2018-01-02', '2018-01-18', 3, 'rate_applied', 20.5, 'order_status', 'notes'),
(2, 1, 3, 44.4, 100000, 100500, 100, '2018-01-02', '2018-01-18', 3, 'rate_applied', 20.5, 'order_status', 'notes');