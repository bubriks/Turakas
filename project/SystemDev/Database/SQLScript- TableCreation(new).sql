use dmaj0916_197331
--Login Table

CREATE TABLE Login(
loginID int IDENTITY(1,1) PRIMARY KEY,
username varchar(50) NOT NULL,
salt uniqueIdentifier NOT NULL,
passwordHash binary(64) NOT NULL,
email varchar(100) NOT NULL,
);
--Login Trigger
go
CREATE TRIGGER DELETE_Login
   ON Login
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Profile WHERE profileID IN (SELECT loginID FROM DELETED)
 DELETE FROM Login WHERE loginID IN (SELECT loginID FROM DELETED)
END
go

--Status Table
CREATE TABLE Status(
statusID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50) NOT NULL,
);

--Profile Table
CREATE TABLE Profile(
profileID int FOREIGN KEY REFERENCES Login(loginID) PRIMARY KEY NOT NULL,
statusID int FOREIGN KEY REFERENCES Status(statusID),
nickname varchar(50) NOT NULL,
);

--Profile Trigger
go
CREATE TRIGGER DELETE_Profile
   ON Profile
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Activity WHERE activityID IN (SELECT profileID FROM DELETED)
 DELETE FROM RelationShips WHERE partnerID IN (SELECT profileID FROM DELETED)
 DELETE FROM Profile WHERE profileID IN (SELECT profileID FROM DELETED)
END
go

--Chat Table
CREATE TABLE Chat(
chatID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50) NOT NULL,
type bit NOT NULL,
nrOfUsers int NOT NULL,
);

--Chat Trigger
go
CREATE TRIGGER DELETE_Chat
   ON Chat
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Message WHERE chatID IN (SELECT chatID FROM DELETED)
 DELETE FROM Chat WHERE chatID IN (SELECT chatID FROM DELETED)
END
go

--Activity Table
CREATE TABLE Activity(
activityID int IDENTITY(1,1) PRIMARY KEY,
profileID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
timeStamp datetime2 NOT NULL,
);

--Activity Trigger
go
CREATE TRIGGER DELETE_Activity
   ON Activity
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Notifications WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM RelationShips WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Liked WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Liked WHERE likedActivityID IN(SELECT activityID FROM DELETED)
 DELETE FROM Message WHERE activityID IN(SELECT activityID FROM DELETED)
 DELETE FROM PlayLists WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Song WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Activity WHERE activityID IN (SELECT activityID FROM DELETED)
END
go

--Notifications Table
CREATE TABLE Notifications(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
profileID int FOREIGN KEY REFERENCES Profile(profileID)  NOT NULL,
);

--RelationshipType Table
CREATE TABLE RelationshipType(
typeID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50) NOT NULL,
);

--RelationShips Table
CREATE TABLE RelationShips(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
partnerID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
typeID int FOREIGN KEY REFERENCES RelationshipType(typeID) NOT NULL,
);

--Liked Table
CREATE TABLE Liked(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
likedActivityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
);

--Message Table
CREATE TABLE Message(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
chatID int FOREIGN KEY REFERENCES Chat(chatID) NOT NULL,
message varchar(MAX) NOT NULL,
);

--Mood Table
CREATE TABLE Mood(
moodID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50) NOT NULL,
);

--PlayLists Table
CREATE TABLE PlayLists(
playListID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
moodID int FOREIGN KEY REFERENCES Mood(moodID) NOT NULL,
image image,
name varchar(50),
);

--PlayLists Trigger
go
CREATE TRIGGER DELETE_PlayLists
   ON PlayLists
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM TrackList WHERE playListID IN (SELECT playListID FROM DELETED)
 DELETE FROM PlayLists WHERE playListID IN (SELECT playListID FROM DELETED)
END
go

--Artists Table
CREATE TABLE Artists(
artistID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50) NOT NULL,
);

--Genres Table
CREATE TABLE Genres(
genreID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50) NOT NULL,
);

--Song Table
CREATE TABLE Song(
songID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
artistID int FOREIGN KEY REFERENCES Artists(artistID) NOT NULL,
genreID int FOREIGN KEY REFERENCES Genres(genreID) NOT NULL,
name varchar(50) NOT NULL,
duration int NOT NULL,
url varchar(200) NOT NULL,
);

--Song Trigger
go
CREATE TRIGGER DELETE_Song
   ON Song
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM TrackList WHERE songID IN (SELECT songID FROM DELETED)
 DELETE FROM Song WHERE songID IN (SELECT songID FROM DELETED)
END
go

--TrackList Table
CREATE TABLE TrackList(
songID int FOREIGN KEY REFERENCES Song(songID) NOT NULL,
playListID int FOREIGN KEY REFERENCES PlayLists(playListID) NOT NULL,
PRIMARY KEY(songID, playListID),
);