CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Age INT NOT NULL,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK (Age >= 18 AND Age <=110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE Status (
	Id INT PRIMARY KEY IDENTITY,
	[Label] NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports (
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	StatusId INT NOT NULL REFERENCES [Status](Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)

GO

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21',	1),
('Niki', 'Stanaghan', '1969-11-26',	4),
('Ayrton', 'Senna',	'1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20',	5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1,	1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6,	3, '2015-09-05', '2015-12-06', 'Charity trail running',	3, 5),
(14, 2,	'2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4,	3,	'2017-07-03', '2017-07-06',	'Cut off streetlight on Str.11', 1, 1)

GO

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

GO

DELETE FROM Reports
WHERE StatusId = 4

GO

SELECT r.Description,
FORMAT(r.OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate, r.Description

GO

SELECT r.Description, c.Name AS [CategoryName]
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
ORDER BY r.Description, [CategoryName]

GO

SELECT TOP(5) c.Name AS CategoryName,
COUNT(*) AS ReportsNumber
FROM Reports AS r
JOIN Categories as c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY [ReportsNumber] DESC, c.Name

GO

SELECT u.Username, c.Name AS [CategoryName]
FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
AND DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
ORDER BY u.Username, c.Name

GO

SELECT e.FirstName + ' ' + e.LastName AS [FullName],
		COUNT(DISTINCT r.UserId) AS [UsersCount]
FROM Reports AS r
RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY [UsersCount] DESC, [FullName]

GO

SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS [Employee],
	   ISNULL(D.Name, 'None') AS [Department],
	   c.Name as [Category],
	   r.Description,
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
	   s.Label AS [Status],
	   u.Name AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN Status AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
ORDER BY e.FirstName DESC, e.LastName DESC, d.Name,
		 c.Name, r.Description, r.OpenDate,
		 s.Label, u.Name

GO

CREATE FUNCTION udf_HoursToComplete (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @HoursToComplete INT;
	IF(@StartDate IS NULL OR @EndDate IS NULL) RETURN 0;
	SET @HoursToComplete = DATEDIFF(HOUR, @StartDate, @EndDate)
		
	RETURN @HoursToComplete;
END

GO

CREATE PROCEDURE usp_AssignEmployeeToReport (@EmployeeId INT, @ReportId INT)
AS
	DECLARE @CategoryDepartmentID INT;
	DECLARE @EmployeeDepartmentId INT;
	
	SET @CategoryDepartmentID = 
	(SELECT c.DepartmentId
	FROM Reports AS r
	JOIN Categories AS c ON r.CategoryId = c.Id
	WHERE r.Id = @ReportId);

	SET @EmployeeDepartmentId = 
	(SELECT e.DepartmentId FROM Employees AS e
	WHERE e.Id = @EmployeeId)

	IF(@CategoryDepartmentID != @EmployeeDepartmentId)
		THROW 50000, 'Employee doesn''t belong to the appropriate department!', 1;

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId

GO