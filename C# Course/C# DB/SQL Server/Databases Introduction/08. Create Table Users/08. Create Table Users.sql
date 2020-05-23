CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime TIME,
	IsDeleted BIT
)

INSERT INTO Users(Username,[Password],ProfilePicture,LastLoginTime,IsDeleted) Values
('Ivan', 'kajsdhksjdhj8883', null, '2016-04-18', 1),
('Rus', 'kajsdhksjdhj8883', null, '2016-04-18', 1),
('Kseniya', 'kajsdhksjdhj8883', null, '2016-04-18', 1),
('Alex', 'kajsdhksjdhj8883', null, '2016-04-18', 0),
('KS', 'kajsdhksjdhj8883', null, '2016-04-18', 1)