--调用方法：
--select * from GetChild('24')
--select id from GetChild('24')
--select * from KuCun where ProductType in(select id from GetChild('24'))

CREATE FUNCTION [dbo].[GetChild] (@ID VARCHAR(10))
RETURNS @t TABLE
(
 ID VARCHAR(10) ,
 ParentID VARCHAR(10) ,
 Level INT
)
AS 
BEGIN
    DECLARE @i INT
    SET @i = 1
    INSERT  INTO @t SELECT  @ID,@ID,0 --当前级，本级，如果不要的话可以注释掉或再加个参数来选择操作
    INSERT  INTO @t SELECT  ID,ParentID,@i FROM Dept WHERE ParentID = @ID

    WHILE @@rowcount <> 0 
        BEGIN
            SET @i = @i + 1
            INSERT  INTO @t
                    SELECT  a.ID,a.ParentID,@i
                    FROM    Dept a , @t b
                    WHERE   a.ParentID = b.ID AND b.Level = @i - 1
        END
    RETURN
END