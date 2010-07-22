--数字转汉字 print dbo.[f_num_str](123456789)
CREATE FUNCTION [dbo].[f_num_str] (@num int)
RETURNS varchar(100)
AS
BEGIN
  DECLARE @n_str VARCHAR(20),@re VARCHAR(20),@i int
  SELECT @n_str=cast(@num as varchar),@i=1,@re=''
  WHILE @i<=len(@n_str)
  BEGIN
    SET @re=@re+SUBSTRING('零一二三四五六七八九',CAST(SUBSTRING(@n_str,@i,1) AS int)+1,1)
    SET @i=@i+1
  END
  RETURN @re
END