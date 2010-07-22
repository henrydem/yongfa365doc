CREATE FUNCTION [dbo].[f_num_chn] (@num numeric(14,2))
RETURNS varchar(100) WITH ENCRYPTION
AS
BEGIN
--版权所有：pbsql
  DECLARE @n_data VARCHAR(20),@c_data VARCHAR(100),@n_str VARCHAR(10),@i int

  SET @n_data=RIGHT(SPACE(14)+CAST(CAST(ABS(@num*100) AS bigint) AS varchar(20)),14)
  SET @c_data=''
  SET @i=1
  WHILE @i<=14
  BEGIN
    SET @n_str=SUBSTRING(@n_data,@i,1)
    IF @n_str<>' '
    BEGIN
      IF not ((SUBSTRING(@n_data,@i,2)='00') or
        ((@n_str='0') and ((@i=4) or (@i=8) or (@i=12) or (@i=14))))
        SET @c_data=@c_data+SUBSTRING('零壹贰叁肆伍陆柒捌玖',CAST(@n_str AS int)+1,1)
      IF not ((@n_str='0') and (@i<>4) and (@i<>8) and (@i<>12))
        SET @c_data=@c_data+SUBSTRING('仟佰拾亿仟佰拾万仟佰拾圆角分',@i,1)
      IF SUBSTRING(@c_data,LEN(@c_data)-1,2)='亿万'
        SET @c_data=SUBSTRING(@c_data,1,LEN(@c_data)-1)
    END
    SET @i=@i+1
  END
  IF @num<0
    SET @c_data='（负数）'+@c_data
  IF @num=0
    SET @c_data='零圆'
  IF @n_str='0'
    SET @c_data=@c_data+'整'
  RETURN(@c_data)
END