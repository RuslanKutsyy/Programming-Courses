CREATE DATABASE WMS;

GO

--01. DDL

CREATE TABLE Clients (
	ClientId INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone VARCHAR(MAX) NOT NULL CHECK(LEN(Phone) = 12)
)

CREATE TABLE Mechanics (
	MechanicId INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(255) NOT NULL
)

CREATE TABLE Models (
	ModelId INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs (
	JobId INT NOT NULL PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId),
	[Status] VARCHAR(11) NOT NULL CHECK ([Status] IN ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending',
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId),
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATETIME NOT NULL,
	FinishDate DATETIME
)

CREATE TABLE Orders (
	OrderId INT NOT NULL PRIMARY KEY IDENTITY,
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	IssueDate DATETIME,
	Delivered BIT NOT NULL DEFAULT 0
)

CREATE TABLE Vendors (
	VendorId INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts (
	PartId INT NOT NULL PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	[Description] NVARCHAR(255),
	Price MONEY NOT NULL CHECK(Price > 0),
	VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL CHECK(StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts (
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT 1
	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded (
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT 1
	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)

GO


--02. Insert

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal',	117.86,	2),
('W10780048', 'Suspension Rod', '42.81', 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

GO


--03. Update


UPDATE Jobs
SET MechanicId = 3, Status = 'In Progress'
WHERE Status = 'Pending'

GO


--04. Delete

DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

GO


--05. Mechanic Assignments

SELECT  m.FirstName + ' ' + m.LastName AS Mechanic,
		j.Status,
		j.IssueDate
FROM Mechanics as m
JOIN Jobs AS j
	ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

GO


--06. Current Clients

SELECT  c.FirstName + ' ' + c.LastName AS Client,
		DATEDIFF(DAY, j.IssueDate, CAST('24 April 2017' AS date)) AS [Days going],
		j.Status
FROM Clients AS c
JOIN Jobs AS j
	ON c.ClientId = j.ClientId
WHERE j.FinishDate IS NULL
ORDER BY [Days going] DESC, c.ClientId

GO


--07. Mechanic Performance

SELECT  m.FirstName + ' ' + m.LastName AS Mechanic,
		AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j ON M.MechanicId = j.MechanicId
WHERE j.FinishDate IS NOT NULL
GROUP BY m.FirstName + ' ' + m.LastName, m.MechanicId
ORDER BY m.MechanicId

GO