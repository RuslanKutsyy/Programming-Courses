CREATE TABLE Directors (
	Id INT IDENTITY CONSTRAINT PK_ID PRIMARY KEY,
	DirectorName NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres (
	Id INT IDENTITY CONSTRAINT PK_ID_Genres PRIMARY KEY,
	GenreName NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories (
	Id INT IDENTITY CONSTRAINT PK_ID_Categories PRIMARY KEY,
	CategoryName NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
	Id INT IDENTITY CONSTRAINT PK_ID_Movies PRIMARY KEY,
	Title NVARCHAR(MAX) NOT NULL,
	DirectorId INT NOT NULL CONSTRAINT FK_DirIT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL CONSTRAINT FK_GenreIT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT NOT NULL CONSTRAINT FK_CatId FOREIGN KEY REFERENCES Categories(Id),
	Rating INT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Ivan Ivanov', null),
('Ksen Ksen', null),
('Ivan Ivanovich', null),
('Alex Petrov', null),
('Rus K', 'some note to the director here')

INSERT INTO Genres(GenreName, Notes) VALUES
('Horors', null),
('Comedy', 'some comment'),
('Fantasy', null),
('Detective', null),
('Thriller', null)

INSERT INTO Categories (CategoryName, Notes) VALUES
('Cosmos', null),
('War', 'some comment'),
('Cat1', null),
('Category2', null),
('Cat3', null)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('Startrek', 1, 2009, 185, 3, 1, 5, 'cool'),
('Star Wars', 2, 1977, 150, 3, 1, 5, null),
('Some film', 3, 1970, 120, 4, 3, 2, null),
('Avengers', 4, 2015, 143, 3, 1, 5, 'cool'),
('Some Comedy', 5, 2003, 90, 5, 4, 4, 'cool')