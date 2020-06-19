CREATE TABLE Students (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL CHECK (Age >= 5 AND Age <=100),
	[Address] NVARCHAR(50),
	Phone NVARCHAR(10)
)

CREATE TABLE Subjects (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL CHECK(Lessons > 0)
)

CREATE TABLE StudentsSubjects (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	StudentId INT NOT NULL REFERENCES Students(Id),
	SubjectId INT NOT NULL REFERENCES Subjects(Id),
	Grade DECIMAL(15,2) NOT NULL CHECK(Grade >=2 AND Grade <=6),
)


CREATE TABLE Exams (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Date] DATETIME,
	SubjectId INT REFERENCES Subjects(Id)
)


CREATE TABLE StudentsExams (
	StudentId INT NOT NULL REFERENCES Students(Id),
	ExamId INT NOT NULL REFERENCES Exams(Id),
	Grade DECIMAL(15,2) NOT NULL CHECK (Grade >=2 AND Grade <= 6),
	PRIMARY KEY (StudentId, ExamId)
)


CREATE TABLE Teachers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NVARCHAR(10),
	SubjectId INT NOT NULL REFERENCES Subjects(Id),
)


CREATE TABLE StudentsTeachers (
	StudentId INT NOT NULL REFERENCES Students(Id),
	TeacherId INT NOT NULL REFERENCES Teachers(Id),
	PRIMARY KEY (StudentId, TeacherId)
)

GO

INSERT INTO Teachers(FirstName,	LastName, [Address], Phone,	SubjectId)
VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard',	'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile',	'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects ([Name], Lessons)
VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

GO

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1, 2) AND Grade >= 5.50

GO

DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE CHARINDEX('72', Phone) > 0

GO

SELECT s.FirstName, s.LastName, s.Age
FROM Students AS s
WHERE s.Age >= 12
ORDER BY s.FirstName, s.LastName


SELECT st.FirstName + ' ' + ISNULL(st.MiddleName, '') + ' ' + st.LastName AS [Full Name],
		st.Address
FROM Students AS st
WHERE st.Address LIKE '%road%'
ORDER BY st.FirstName, st.LastName, st.Address


SELECT st.FirstName, st.Address, st.Phone
FROM Students AS st
WHERE st.MiddleName IS NOT NULL AND st.Phone LIKE '42%'
ORDER BY st.FirstName


SELECT s.FirstName, s.LastName, COUNT(st.StudentId) AS TeachersCount
FROM StudentsTeachers as st
JOIN Students AS s ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName


SELECT CONCAT(t.FirstName, ' ', t.LastName) AS FullName,
	   CONCAT(s.Name, '-', s.Lessons) AS Subjects,
	   COUNT(st.StudentId) AS Students
FROM Teachers AS t
JOIN Subjects AS s ON t.SubjectId = s.Id
JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY CONCAT(t.FirstName, ' ', t.LastName), CONCAT(s.Name, '-', s.Lessons)
ORDER BY Students DESC, FullName, Subjects


SELECT s.FirstName + ' ' + s.LastName AS [Full Name]
FROM Students AS s
WHERE s.Id NOT IN (SELECT se.StudentId FROM StudentsExams AS se)
ORDER BY [Full Name]


SELECT TOP(10) t.FirstName, t.LastName,
	   COUNT(st.StudentId) AS StudentsCount
FROM Teachers AS t
JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName


SELECT TOP(10) s.FirstName AS [First Name], s.LastName AS [Last Name], CAST(AVG(se.Grade) AS decimal(3, 2)) AS Grade
FROM StudentsExams AS se
JOIN Students AS s ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, [First Name], [Last Name]


SELECT a.FirstName, a.LastName, a.Grade FROM
(SELECT s.FirstName, s.LastName, ss.SubjectId, ss.Grade,
		ROW_NUMBER() OVER (PARTITION BY s.FirstName, s.LastName ORDER BY ss.Grade DESC) AS [ROW_NUMBER]
FROM Students AS s
JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId) AS a
WHERE a.ROW_NUMBER = 2
ORDER BY a.FirstName, a.LastName


SELECT s.FirstName + ISNULL(' ' + s.MiddleName + ' ', ' ') + s.LastName AS [Full Name]
FROM Students AS s
WHERE s.Id NOT IN (SELECT ss.StudentId FROM StudentsSubjects AS ss)
ORDER BY [Full Name]