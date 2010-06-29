--http://topic.csdn.net/u/20090209/08/a945701c-e0d5-40cb-85f2-f4f56ac2999b.html
--------------------------------------------------------------------------
--  Author : htl258(Tony)
--  Date   : 2010-04-28 02:00:28
--  Version:Microsoft SQL Server 2008 (RTM) - 10.0.1600.22 (Intel X86)
--          Jul  9 2008 14:43:38
--          Copyright (c) 1988-2008 Microsoft Corporation
--          Developer Edition on Windows NT 5.1 <X86> (Build 2600: Service Pack 3)
--  Blog   : http://blog.csdn.net/htl258
--  Subject: SQL2000/2005字符串拆分为列表通用函数
--------------------------------------------------------------------------
--SQL2000/2005字符串拆分为列表通用函数
IF OBJECT_ID('f_getstr') IS NOT NULL
    DROP FUNCTION  f_getstr
GO
CREATE FUNCTION f_getstr(
@s     NVARCHAR(4000),  --待分拆的字符串
@flag  NVARCHAR(10)=''  --数据分隔符
)RETURNS @r TABLE(col NVARCHAR(1000))
AS
BEGIN
  IF ISNULL(@flag,'')='' AND LEN(ISNULL(@flag,'')+'a')=1
    INSERT @r
      SELECT SUBSTRING(@s,number+1,1)
      FROM master..spt_values
      WHERE TYPE='p' and number<LEN(@s+'a')-1
  ELSE
    INSERT @r
      SELECT SUBSTRING(@s,number,CHARINDEX(@flag,@s+@flag,number)-number)
      FROM master..spt_values
      WHERE TYPE='p' and number<=len(@s+'a')
         --AND SUBSTRING(@flag+@s,number,1)=@flag --用此条件或下面的条件均可
         AND CHARINDEX(@flag,@flag+@s,number)=number
  RETURN
END
GO
--本实例技巧，利用master库自带的spt_values表，取number字段作为连续的序号，
--省去创建序号表，尽量做到通用，再加上字符串处理函数取得最终结果。
--1.每个字符拆分取出
SELECT * FROM dbo.f_getstr(N'一个世界一个家',NULL)
SELECT * FROM dbo.f_getstr(N'一个世界一个家','')
SELECT * FROM dbo.f_getstr(N'一个世界一个家',default)
/*
col
-------
一
个
世
界
一
个
家
 
(7 行受影响)
*/
--2.指定分隔符拆分取出
SELECT * FROM dbo.f_getstr(N'一个 世界 一个 家',N' ')
SELECT * FROM dbo.f_getstr(N'一个,世界,一个,家',N',')
SELECT * FROM dbo.f_getstr(N'一个%世界%一个%家',N'%')
SELECT * FROM dbo.f_getstr(N'一个中国世界中国一个中国家',N'中国')
/*
col
---------
一个
世界
一个
家
 
(4 行受影响)
*/
 
 
--3.SQL2005以上版本可以结合apply进行拆分列值
IF OBJECT_ID('tb') IS NOT NULL
    DROP TABLE tb
GO
CREATE TABLE tb (id INT,col VARCHAR(30))
INSERT INTO tb VALUES(1,'aa,bb')
INSERT INTO tb VALUES(2,'aaa,bbb,ccc')
GO
 
SELECT id,b.col FROM tb CROSS APPLY f_getstr(col,',') b
SELECT id,b.col FROM tb OUTER APPLY f_getstr(col,',') b
/*
id          col
----------- -----------
1           aa
1           bb
2           aaa
2           bbb
2           ccc
 
(5 行受影响)
*/