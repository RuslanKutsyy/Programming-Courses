--01. DDL


CREATE TABLE Users
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId  INT NOT NULL REFERENCES Users(Id)
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Title NVARCHAR(255) NOT NULL,
	IssueStatus NVARCHAR(6) NOT NULL,
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL REFERENCES Users(Id)
)


CREATE TABLE Commits
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Files
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Size DECIMAL NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT NOT NULL REFERENCES Commits(Id)
)


GO


--02. Insert

INSERT INTO FILES ([Name], Size, ParentId, CommitId)
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', '9238.31',	2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus,	RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

GO

--03. Update

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6



--04. Delete

DELETE FROM RepositoriesContributors
WHERE RepositoryId IN
(SELECT Id FROM Repositories
WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId IN
(SELECT Id FROM Repositories
WHERE [Name] = 'Softuni-Teamwork')

--05. Commits

SELECT c.Id, c.Message, c.RepositoryId, c.ContributorId
FROM Commits AS c
ORDER BY c.Id, c.Message, c.RepositoryId

--06. Heavy HTML

SELECT f.Id, f.Name, f.Size
FROM Files AS f
WHERE f.Size > 1000 AND f.Name LIKE '%html%'
ORDER BY f.Size DESC, f.Id, f.Name


--07. Issues and Users

SELECT  i.Id,
		u.Username + ' : ' + i.Title AS [IssueAssignee]
FROM Issues AS i
JOIN Users AS u
	ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, u.Username

--08. Non-Directory Files

SELECT f.Id, f.Name, CONCAT(f.Size, 'KB') AS Size
FROM Files AS f
WHERE f.Id NOT IN (SELECT ISNULL(fi.ParentId, 0) FROM Files AS fi)
ORDER BY f.Id, f.Name, f.Size DESC


--09. Most Contributed Repositories

SELECT TOP(5) r.Id, r.Name, COUNT(c.RepositoryId) AS Commits
FROM Commits AS c
JOIN Repositories AS r ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name


--10. User and Files

SELECT u.Username, AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC, u.Username

GO

--11. User Total Commits

CREATE FUNCTION udf_UserTotalCommits (@username NVARCHAR(30))
RETURNS INT
AS
	BEGIN
		DECLARE @result INT;
		
		SET @result = (SELECT COUNT(c.Id)
		FROM Commits AS c
		JOIN Users AS u ON c.ContributorId = u.Id
		WHERE u.Username = @username);

		RETURN @result;
	END

GO


--12. Find by Extensions

CREATE PROCEDURE usp_FindByExtension(@extension NVARCHAR(10))
AS
	SELECT f.Id, f.Name, CONCAT(f.Size, 'KB') AS Size
	FROM Files AS f
	WHERE f.Name LIKE CONCAT('%',@extension)
	ORDER BY f.Id, f.Name, f.Size