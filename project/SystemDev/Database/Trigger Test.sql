/*create database test
go
use test

create table Parent(
ParentID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50),
);
go

CREATE TRIGGER DELETE_Parent
   ON Parent
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Child1 WHERE Child1ID IN (SELECT ParentID FROM DELETED)
 DELETE FROM Child2 WHERE Child2ID IN (SELECT ParentID FROM DELETED)
 DELETE FROM Parent WHERE ParentID IN (SELECT ParentID FROM DELETED)
END
go

create table Child1(
Child1ID int FOREIGN KEY REFERENCES Parent(ParentID) PRIMARY KEY,
name varchar(50),
);
go

CREATE TRIGGER DELETE_Child1
   ON Child1
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Grandchild WHERE Child1ID IN (SELECT Child1ID FROM DELETED)
 DELETE FROM Child1 WHERE Child1ID IN (SELECT Child1ID FROM DELETED)
END
go
--CHILD2
create table Child2(
Child2ID int FOREIGN KEY REFERENCES Parent(ParentID) PRIMARY KEY,
name varchar(50),
);
go

CREATE TRIGGER DELETE_Child2
   ON Child2
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Grandchild WHERE Child2ID IN (SELECT Child2ID FROM DELETED)
 DELETE FROM Child2 WHERE Child2ID IN (SELECT Child2ID FROM DELETED)
END
go
--GRANDCHILD
create table Grandchild(
Child1ID int foreign key REFERENCES Child1(Child1ID),
Child2ID int FOREIGN KEY REFERENCES Child2(Child2ID),
);
*/
/*
use test
insert into Parent values('parent1'),('parent2');
insert into Child1 values(1,'C11'),(2,'c14');
insert into Child2 values(1,'21'),(2,'c24');
insert into Grandchild values(1,1),(1,2);
*/
/*
use test
select * from Parent inner join Child1 on Parent.ParentID = Child1.Child1ID

select * from Grandchild

delete from Parent where ParentID = 2

select * from Grandchild
*/