--日期相关

SELECT DATEADD(year,1,GETDATE())	--yy
SELECT DATEADD(month,1,GETDATE())	--mm
SELECT DATEADD(DAY,1,GETDATE())		--dd
SELECT DATEADD(hour,1,GETDATE())	--hh
SELECT DATEADD(minute,1,GETDATE())	--mi
SELECT DATEADD(second,1,GETDATE())	--ss
SELECT DATEADD(millisecond,1,GETDATE())	--ms

SELECT DATEDIFF(YEAR,'2010-1-1','2011-4-1')
SELECT DATEDIFF(YEAR,'2010-1-1','2009-4-1')

SELECT YEAR(GETDATE())
SELECT MONTH(GETDATE())
SELECT DAY(GETDATE())

SELECT DAY('2010-4-24')


--类型转换
SELECT CAST(1 AS VARCHAR(50)) + '数字连接字符前要先转为字符'
SELECT CONVERT(VARCHAR(50),12222)
Select CONVERT(varchar(100), GETDATE(), 20)		--2010-05-01 20:48:56
Select CONVERT(varchar(100), GETDATE(), 23)		--2006-05-16
Select CONVERT(varchar(100), GETDATE(), 112)	--20060516
Select CONVERT(varchar(100), GETDATE(), 12)		--060516

Select CONVERT(varchar(100), GETDATE(), 8)		--10:57:46
Select CONVERT(varchar(100), GETDATE(), 24)		--10:57:47
Select CONVERT(varchar(100), GETDATE(), 108)	--10:57:49


--字符串
SELECT REPLICATE('=',100)
SELECT SPACE(10) + '测试空格'
SELECT REVERSE('反转测试')
SELECT CHARINDEX('柳永法','我是柳永法')
SELECT PATINDEX('%_永法%','我是柳永法')--可使用通配符
SELECT SUBSTRING('我是柳永法',3,3)
SELECT STR(123.456,6,2)--数字转为字符串，第二位为长度，第三位为小数点后位数, 结果右对齐
SELECT STR(123.456)
SELECT ISNULL(NULL, '如果是NULL就用这个替换')
SELECT COALESCE(NULL,NULL,'多个参数，直到第一个不为NULL时显示它')
SELECT @@IDENTITY --所有地方
SELECT SCOPE_IDENTITY() --当前作用域


--制表符 CHAR(9) 
--换行符 CHAR(10) 
--回车   CHAR(13) 

--快速获取表记录数 --不是实时更新的，有误差
select rows from sysindexes where id = object_id('Articles2') and indid in (0,1)




