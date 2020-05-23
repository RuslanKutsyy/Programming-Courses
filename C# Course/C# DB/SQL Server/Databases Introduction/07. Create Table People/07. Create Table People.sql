CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL CHECK (Gender IN ('m', 'f')),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name],Picture,Height,[Weight],Gender,Birthdate,Biography) Values
('Ivan',Null,1.65,44.55,'f','2000-09-22',Null),
('Rus',Null,2.15,95.55,'m','1989-11-02',Null),
('Alex',Null,1.55,33.00,'m','2010-04-11',Null),
('Sergey',Null,2.15,55.55,'f','2001-11-11',Null),
('Kseniya',Null,1.85,90.00,'m','1983-07-22',Null)