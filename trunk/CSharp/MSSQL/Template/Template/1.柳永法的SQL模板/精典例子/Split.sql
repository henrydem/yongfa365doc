--SELECT * FROM [dbo].[Split]('1,2,3,qwe',',')

CREATE   FUNCTION [dbo].[Split]
(
 @c VARCHAR(2000) ,
 @split VARCHAR(2)
)
RETURNS @t TABLE (col VARCHAR(20))
AS 
BEGIN   
    WHILE (CHARINDEX(@split,@c) <> 0) 
        BEGIN   
            INSERT  @t (col)
            VALUES  (SUBSTRING(@c,1,CHARINDEX(@split,@c) - 1))   
            SET @c = STUFF(@c,1,CHARINDEX(@split,@c),'')   
        END   
    INSERT  @t (col)
    VALUES  (@c)   
    RETURN   
END   