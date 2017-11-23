USE dmaj0916_197331
--Login Table
go
CREATE TABLE Login(
loginID int IDENTITY(1,1) PRIMARY KEY,
username varchar(50) NOT NULL,
salt uniqueIdentifier NOT NULL,
passwordHash binary(64) NOT NULL,
email varchar(100) NOT NULL,
nickname varchar(50) NOT NULL,
);

--Activity Table
CREATE TABLE Activity(
activityID int IDENTITY(1,1) PRIMARY KEY,
loginID int FOREIGN KEY REFERENCES Login(loginID) NOT NULL,
timeStamp datetime2 NOT NULL,
);

--Chat Table
CREATE TABLE Chat(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
name varchar(50) NOT NULL,
type bit NOT NULL,
nrOfUsers int NOT NULL,
);

--Message Table
CREATE TABLE Message(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
chatActivityID int FOREIGN KEY REFERENCES Chat(activityID) NOT NULL,
message varchar(500),
);

--Group Table
CREATE TABLE Groups(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
name varchar(20),
);

--GroupMembers Table
CREATE TABLE GroupMembers(
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
groupID int FOREIGN KEY REFERENCES Groups(activityID) NOT NULL,
PRIMARY KEY(activityID, groupID),
);

--PlayLists Table
CREATE TABLE PlayLists(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
image image,
name varchar(50),
);

--Video Table
CREATE TABLE Video(
activityID int FOREIGN KEY REFERENCES Activity(activityID) PRIMARY KEY NOT NULL,
name varchar(50) NOT NULL,
duration int NOT NULL,
url varchar(200) NOT NULL,
);

--VideoList Table
CREATE TABLE VideoList(
videoID int FOREIGN KEY REFERENCES Video(activityID) NOT NULL,
playListActivityID int FOREIGN KEY REFERENCES PlayLists(activityID) NOT NULL,
PRIMARY KEY(videoID, playListActivityID),
);

--Login Trigger
go
CREATE TRIGGER DELETE_Login
   ON Login
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Activity WHERE activityID IN (SELECT loginID FROM DELETED)
 DELETE FROM Login WHERE loginID IN (SELECT loginID FROM DELETED)
END
go

--Chat Trigger
go
CREATE TRIGGER DELETE_Chat
   ON Chat
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Message WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Chat WHERE activityID IN (SELECT activityID FROM DELETED)
END
go

--Group Trigger
go
CREATE TRIGGER DELETE_Groups
   ON Groups
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM GroupMembers WHERE groupID IN (SELECT activityID FROM DELETED)
 DELETE FROM Groups WHERE activityID IN (SELECT activityID FROM DELETED)
END
go

--Video Trigger
go
CREATE TRIGGER DELETE_Video
   ON Video
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM VideoList WHERE videoID IN (SELECT activityID FROM DELETED)
 DELETE FROM Video WHERE activityID IN (SELECT activityID FROM DELETED)
END
go

--Activity Trigger
go
CREATE TRIGGER DELETE_Activity
   ON Activity
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Message WHERE activityID IN(SELECT activityID FROM DELETED)
 DELETE FROM Chat WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM PlayLists WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Video WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Groups WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM GroupMembers WHERE activityID IN (SELECT activityID FROM DELETED)
 DELETE FROM Activity WHERE activityID IN (SELECT activityID FROM DELETED)
END
go

--PlayLists Trigger
go
CREATE TRIGGER DELETE_PlayLists
   ON PlayLists
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM VideoList WHERE videoID IN (SELECT playListActivityID FROM DELETED)
 DELETE FROM PlayLists WHERE activityID IN (SELECT activityID FROM DELETED)
END
go