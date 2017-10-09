DROP DATABASE ProjectDb;

CREATE DATABASE ProjectDb

CREATE TABLE Login(
loginID int IDENTITY(1,1) PRIMARY KEY,
username varchar(50),
password varchar(50),
);

CREATE TABLE Person(
userID int IDENTITY(1,1) PRIMARY KEY,
loginID int FOREIGN KEY REFERENCES Login(loginID) NOT NULL,
email varchar(100),
balance decimal(6,2),
accountStatu bit,
);

CREATE TABLE Profile(
profileID int IDENTITY(1,1) PRIMARY KEY,
userID int FOREIGN KEY REFERENCES Person(userID) NOT NULL,
nickname varchar(10),
onlineStatus bit,
likes int,
);

CREATE TABLE Friends(
friendID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
profileID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
PRIMARY KEY (friendID, profileID),
);

CREATE TABLE Activity(
activityID int IDENTITY(1,1) PRIMARY KEY,
profileID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
timeStamp date,
);

CREATE TABLE Chat(
chatID int IDENTITY(1,1) PRIMARY KEY,
name varchar(20),
);

CREATE TABLE PersonsChats(
personsChatsID int IDENTITY(1,1) PRIMARY KEY,
chatID int FOREIGN KEY REFERENCES Chat(chatID) NOT NULL,
profileID int FOREIGN KEY REFERENCES Profile(profileID) NOT NULL,
);

CREATE TABLE Message(
messageID int IDENTITY(1,1) PRIMARY KEY,
chatID int FOREIGN KEY REFERENCES Chat(chatID) NOT NULL,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
message varchar(200),
likes int,
);

CREATE TABLE Purchases(
purchaseID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
amount decimal(6,2),
);

CREATE TABLE Liked(
likedID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
);

CREATE TABLE PlayLists(
playListID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
image image,
mood varchar(20),
likes int,
);

CREATE TABLE Comment(
commentID int IDENTITY(1,1) PRIMARY KEY,
activityID int FOREIGN KEY REFERENCES Activity(activityID) NOT NULL,
playListID int FOREIGN KEY REFERENCES PlayLists(playListID) NOT NULL,
message varchar(200),
likes int,
);

CREATE TABLE Song(
songID int IDENTITY(1,1) PRIMARY KEY,
name varchar(30),
artist varchar (30),
duration decimal(4,2),
url varchar(200),
genre varchar(30),
);

CREATE TABLE TrackList(
trackListID int IDENTITY(1,1) PRIMARY KEY,
songID int FOREIGN KEY REFERENCES Song(songID) NOT NULL,
playListID int FOREIGN KEY REFERENCES PlayLists(playListID) NOT NULL,
);