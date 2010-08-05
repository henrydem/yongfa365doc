-------------------------------存储过程-----------------------------------------

create proc usp_AddUser
@UserName varchar(50)
@UserPassword varchar(50)
as
begin
	insert into Users(UserName,UserPassword) values (@UserName,@UserPassword)
	select @@IDENTITY
end

-------------------------------触发器-----------------------------------------
-------------------------inserted-----------------------------
CREATE TRIGGER [dbo].[插入留言时更新文章数] ON [dbo].[ly]
    AFTER INSERT
AS
    BEGIN 

        UPDATE  a
        SET     a.Replys = a.Replys+1
        FROM    Articles a ,
                inserted b
        WHERE   a.ID = b.ArticleId

    END


--------------------------deleted----------------------------
CREATE TRIGGER [dbo].[删除留言时更新文章数] ON [dbo].[ly]
    AFTER DELETE
AS
    BEGIN 

        UPDATE  a
        SET     a.Replys = a.Replys-1
        FROM    Articles a ,
                deleted b
        WHERE   a.ID = b.ArticleId

    END

----------------------UPDATE, INSERT, DELETE-----------------
    
CREATE  TRIGGER [dbo].[Dept变化时在Configs里更新版本] ON [dbo].[Dept]
FOR UPDATE, INSERT, DELETE
AS
BEGIN 
UPDATE  dbo.Configs  SET  dept = dept + 1
END

-----------------------------------------------------------
CREATE TRIGGER UpdateTJ ON [dbo].[Dept]
AFTER UPDATE
AS
IF UPDATE(id) 
BEGIN
--------------
END

------------------------------------------------------------------------

--------------------------------索引----------------------------------------
--index_name
--非聚集：	CREATE INDEX 索引名 ON 表名(字段名) --也可以是字段名列表（复合索引）
--聚集：	CREATE CLUSTERED INDEX 索引名 ON 表名(字段名)
--唯一：	CREATE UNIQUE INDEX 索引名 ON 表名(字段名)--也可以是字段名列表（复合索引）



--------------------------------------------------------------------------
update 表一  
set a = 表二.b  
from 表二  
where id = 表二.id  


------------------------------------------------------------------------
--从table 表中取出从第 m 条到第 n 条的记录：(not in 版本)  
select top n-m+1 * from [表名] where id not in (select top m-1 id from [表名])



---------------------------------------------------------------------------
--having使用方法  
--一个表中的UserName有很多重复,  
--只显示重复项:   
select UserName,COUNT(*) from Users group by UserName having count(*)>1   
--不显示重复项:   
select UserName,COUNT(*) from Users group by UserName having count(*)=1 