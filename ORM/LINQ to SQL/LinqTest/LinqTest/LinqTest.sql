CREATE DATABASE LinqTest

USE LinqTest

CREATE TABLE Articles
    (
      Id INT PRIMARY KEY IDENTITY(1, 1) ,
      txtTitle NVARCHAR(200) ,
	  txtContent NVARCHAR(max) ,
      AddTime DATETIME DEFAULT ( GETDATE() ) NOT NULL ,
      CategoryId INT NOT NULL
    )

CREATE TABLE Category
    (
      Id INT PRIMARY KEY IDENTITY(1, 1) ,
      Category VARCHAR(50)
    )

TRUNCATE TABLE category
TRUNCATE TABLE articles



CREATE FUNCTION [dbo].[GetOrderId]
()
RETURNS varchar(17)
AS
BEGIN
	declare @ok varchar(20)
	set @ok=CONVERT(varchar(12) , getdate(), 112 )+replace(replace(CONVERT(varchar(12) , getdate(), 114 ),':',''),'.','')
	return(@ok)
END



--NorthWnd,Pubs
--http://www.microsoft.com/downloads/details.aspx?FamilyId=06616212-0356-46A0-8DA2-EEBC53A68034&displaylang=en
