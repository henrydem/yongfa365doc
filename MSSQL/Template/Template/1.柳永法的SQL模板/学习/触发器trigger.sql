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
