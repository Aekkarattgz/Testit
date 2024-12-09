CREATE DATABASE Test_WSCRound1
GO

USE Test_WSCRound1;
GO

CREATE TABLE ItemTypes(
	ID int PRIMARY KEY IDENTITY(1,1) NOT NULL,	
	Name nvarchar(50) NOT NULL,
);

CREATE TABLE UserTypes(
	ID int PRIMARY KEY IDENTITY(1,1) NOT NULL,	
	Name varchar(50) NOT NULL,
);

CREATE TABLE Users(
	ID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UserTypeID int NOT NULL,
	Username varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	Gender bit NOT NULL,
	BirthDate date NOT NULL,
	FamilyCount int NOT NULL,
	CONSTRAINT FK_UserType FOREIGN KEY (UserTypeID) REFERENCES UserTypes(ID)
);

CREATE TABLE Items(
	ID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UserID int NOT NULL,
	ItemTypeID int NOT NULL,
	Title varchar(50) NOT NULL,
	Capacity int NOT NULL,
	NumberOfBeds int NOT NULL,
	NumberOfBedrooms int NOT NULL,
	NumberOfBathrooms int NOT NULL,
	ExactAddress varchar(500) NOT NULL,
	ApproximateAddress varchar(250) NOT NULL,
	Description nvarchar(2000) NOT NULL,
	HostRules nvarchar(2000) NOT NULL,
	MinimumNights int NOT NULL,
	MaximumNights int NOT NULL,
	CONSTRAINT FK_ItemType FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ID),
	CONSTRAINT FK_Users FOREIGN KEY (UserID) REFERENCES Users(ID)
);

