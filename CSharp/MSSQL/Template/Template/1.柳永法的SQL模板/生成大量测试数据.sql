CREATE DATABASE test

USE test
--通用建表结构  
CREATE TABLE [dbo].test
    (
      [Id] INT PRIMARY KEY
               IDENTITY(1, 1) ,--ID，主键，自动号  
      [txtTitle] NVARCHAR(255) ,--标题  
      [txtContent] NVARCHAR(MAX) ,--内容  
      [AddTime] DATETIME DEFAULT ( GETDATE() ) ,--提交时间  
      [ModiTime] DATETIME DEFAULT ( GETDATE() ) ,--修改时间  
      [Hits] INT DEFAULT ( 0 ) ,--点击数  
      [Flags] INT DEFAULT ( 0 ) ,--标识  
      [SortID] INT DEFAULT ( 0 ),--排序号  
    )  
 TRUNCATE TABLE dbo.test
 --生成一条
     
INSERT  INTO dbo.test
        ( txtTitle ,
          txtContent ,
          AddTime ,
          ModiTime ,
          Hits ,
          Flags ,
          SortID
	        
        )
VALUES  ( '柳永法' , -- txtTitle - nvarchar(255)
          '我是柳永法' , -- txtContent - nvarchar(max)
          GETDATE() ,
          GETDATE() ,
          0 , -- Hits - int
          0 , -- Flags - int
          0  -- SortID - int
	        
        )	

--执行20次copy表的操作,生成 1048576条记录
DECLARE @i INT
SET @i = 0
WHILE @i < 20 
    BEGIN
        INSERT  INTO dbo.test
                ( txtTitle ,
                  txtContent ,
                  AddTime ,
                  ModiTime ,
                  Hits ,
                  Flags ,
                  SortID
                )
                SELECT  txtTitle ,
                        txtContent+CAST(@i AS VARCHAR) ,
                        AddTime ,
                        ModiTime ,
                        Hits ,
                        Flags ,
                        SortID
                FROM    dbo.test

        SET @i = @i + 1
    END
    

--TRANSACTION是第二快
BEGIN TRANSACTION
DECLARE @i INT
SET @i = 0
WHILE @i < 1048576 
    BEGIN

        INSERT  INTO test
                ( txtTitle, txtContent )
        VALUES  ( '柳永法', 'show.aspx?id=12'+CAST(@i AS VARCHAR) )
        SET @i = @i + 1
    END
COMMIT
