CREATE DATABASE ProjectDb
go
USE ProjectDb
CREATE TABLE Login(
loginID int IDENTITY(1,1) PRIMARY KEY,
username varchar(50),
passwordHash binary(64),
salt uniqueIdentifier,
);

CREATE TABLE Person(
personID int IDENTITY(1,1) PRIMARY KEY,
loginID int FOREIGN KEY REFERENCES Login(loginID) NOT NULL,
email varchar(100),
balance decimal(6,2),
accountStatus int,
);

CREATE TABLE Profile(
profileID int IDENTITY(1,1) PRIMARY KEY,
personID int FOREIGN KEY REFERENCES Person(personID) NOT NULL,
nickname varchar(20),
onlineStatus bit,
);

CREATE TABLE Activity(
activityID int IDENTITY(1,1) PRIMARY KEY,
profileID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
timeStamp datetime2,
);

CREATE TABLE Notification(
profileID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
PRIMARY KEY (profileID, activityID),
);

CREATE TABLE Relationship(
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
partnerID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
type int NOT NULL,
PRIMARY KEY (partnerID, activityID),
);

CREATE TABLE Chat(
chatID int IDENTITY(1,1) PRIMARY KEY,
name varchar(20),
type bit,
);

CREATE TABLE PersonsChats(
chatID int FOREIGN KEY REFERENCES Chat(chatID) NOT NULL,
profileID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
PRIMARY KEY(chatID, profileID),
);

CREATE TABLE Text(
textID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
message varbinary(MAX),
);

CREATE TABLE Message(
textID int FOREIGN KEY REFERENCES Text(textID) NOT NULL,
chatID int FOREIGN KEY REFERENCES Chat(chatID) NOT NULL,
PRIMARY KEY(textID),
);

CREATE TABLE Song(
songID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
name varchar(50),
artist varchar (50),
duration decimal(4,2),
url varchar(200),
genre varchar(50),
);

CREATE TABLE PlayLists(
playListID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
image image,
mood varchar(50),
);

CREATE TABLE TrackList(
songID int FOREIGN KEY REFERENCES Song(songID) NOT NULL,
playListID int FOREIGN KEY REFERENCES PlayLists(playListID) NOT NULL,
PRIMARY KEY(songID, playListID),
);

CREATE TABLE Comment(
textID int FOREIGN KEY REFERENCES Text(textID) NOT NULL,
playListID int FOREIGN KEY REFERENCES PlayLists(playListID) NOT NULL,
PRIMARY KEY(textID),
);

CREATE TABLE Purchases(
purchaseID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
amount decimal(6,2),
IBAN varchar(50),
);

CREATE TABLE Liked(
likedActivityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
PRIMARY KEY(likedActivityID, activityID),
);
