create table Users
(
	UserName varchar(255),
	UserPassword varchar(255),
	primary key(UserName)
)

USE [web01]
GO

INSERT INTO [dbo].[Users]
           ([UserName]
           ,[UserPassword])
     VALUES
           ('0385822258','Matkhau01!'),('0961622589','Matkhau02!');
GO


