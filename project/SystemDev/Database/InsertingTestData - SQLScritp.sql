use dmaj0916_197331

--inserting Uganda 123456 and hanes 123456 in Profile
DECLARE @salt UNIQUEIDENTIFIER=NEWID() INSERT INTO Profile(username, salt, passwordHash, email, nickname)OUTPUT INSERTED.profileID values ('Uganda', @salt, HASHBYTES('SHA2_512', '123456'+CAST(@salt AS NVARCHAR(36))), '959s9f+7w0g77dvgwrb0@sharklasers.com', 'Uganda' );
DECLARE @salt1 UNIQUEIDENTIFIER=NEWID() INSERT INTO Profile(username, salt, passwordHash, email, nickname)OUTPUT INSERTED.profileID values ('hanes', @salt1, HASHBYTES('SHA2_512', '123456'+CAST(@salt1 AS NVARCHAR(36))), 'mhmzqnbl@sharklasers.com', 'hanes' );
--inserting testGroup in Group and GroupMembers and Activity
insert into Activity(profileID, timeStamp) values(1, '2017-02-01 10:02:20');
insert into Activity(profileID, timeStamp) values(2, '2016-01-01 09:40:30');
insert into Groups(activityID, name) values(1, 'testGroup');
insert into GroupMembers(activityID, groupID)  values(1, 1);
insert into GroupMembers(activityID, groupID)  values(2, 1);