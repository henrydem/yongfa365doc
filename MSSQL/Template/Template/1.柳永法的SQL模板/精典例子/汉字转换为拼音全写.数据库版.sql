--创建汉字拼音库
CREATE TABLE YingShe (CHR CHAR(2),PY VARCHAR(10))
INSERT  YingShe
select '长','chang'
 union all select '长','zhang'
 union all select '城','cheng'
 union all select '科','kel'
 union all select '技','ji'
 union all select '金','jin'
 union all select '立','li'
 union all select '章','zhang'
 union all select '公','gong'
 union all select '司','si'

/**//*--下面是两个函数,一个以表的形式返回某个字符串的全部拼音,一个返回某某个字符串的其中一个拼音
--*/

--获取汉字拼音的函数--返回所有的拼音
CREATE FUNCTION f_getpy_tb (@str VARCHAR(100))
RETURNS @tb TABLE (re VARCHAR(8000))
AS 
BEGIN
    DECLARE @re TABLE (id INT,re VARCHAR(8000))  --数据处理中间表

    DECLARE @i INT ,
        @ilen INT ,
        @splitchr VARCHAR(1)
    SELECT  @splitchr = ' ' --两个拼音之间的分隔符(目的是为了通用性考虑)
            ,@i = 1,@ilen = LEN(@str)

    INSERT  INTO @re
            SELECT  @i,py
            FROM    YingShe
            WHERE   chr = SUBSTRING(@str,@i,1)
    WHILE @i < @ilen 
        BEGIN
            SET @i = @i + 1
            INSERT  INTO @re
                    SELECT  @i,re + @splitchr + py
                    FROM    @re a ,
                            YingShe b
                    WHERE   a.id = @i - 1 AND b.chr = SUBSTRING(@str,@i,1)
        END

    INSERT  INTO @tb
            SELECT  re
            FROM    @re
            WHERE   id = @i
    RETURN 
END
go

--获取汉字拼音的函数--返回汉字的某一个拼音
CREATE FUNCTION f_getpy (@str VARCHAR(100))
RETURNS VARCHAR(8000)
AS 
BEGIN
    DECLARE @re VARCHAR(8000)

    DECLARE @i INT ,
        @ilen INT ,
        @splitchr VARCHAR(1)
    SELECT  @splitchr = ' ' --两个拼音之间的分隔符(目的是为了通用性考虑)
            ,@i = 1,@ilen = LEN(@str)

    SELECT  @re = py
    FROM    YingShe
    WHERE   chr = SUBSTRING(@str,@i,1)
    WHILE @i < @ilen 
        BEGIN
            SET @i = @i + 1
            SELECT TOP 1
                    @re = @re + @splitchr + py
            FROM    YingShe
            WHERE   chr = SUBSTRING(@str,@i,1)
        END

    RETURN(@re)
END
go

--测试
--返回'长城'的所有可能拼音
SELECT  *
FROM    dbo.f_getpy_tb('长城')

--返回'长城'的拼音
SELECT  dbo.f_getpy('长城')

--删除拼音函数
DROP FUNCTION f_getpy,f_getpy_tb
