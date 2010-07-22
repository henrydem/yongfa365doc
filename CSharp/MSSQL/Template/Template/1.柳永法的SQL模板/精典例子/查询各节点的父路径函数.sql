--http://blog.csdn.net/htl258
--http://topic.csdn.net/u/20100428/14/51caf51d-bfc7-4832-9783-2805e13085e5.html




--------------------------------------------------------------------------
/*
标题：查询各节点的父路径函数
作者：爱新觉罗·毓华(十八年风雨,守得冰山雪莲花开)  
时间：2008-05-12
地点：广东深圳
*/

/*
原始数据及要求结果如下：
--食品 
  --水果 
    --香蕉 
    --苹果    
  --蔬菜 
    --青菜
id          pid         name                 
----------- ----------- -------------------- 
1           0           食品
2           1           水果
3           1           蔬菜
4           2           香蕉
5           2           苹果
6           3           青菜

要求得到各节点的父路径即如下结果：
id  pid name  路径                         
--- --- ----- ---------------
1   0   食品  食品
2   1   水果  食品,水果
3   1   蔬菜  食品,蔬菜
4   2   香蕉  食品,水果,香蕉
5   2   苹果  食品,水果,苹果
6   3   青菜  食品,蔬菜,青菜 
*/
--------------------------------------------------------------------------

IF OBJECT_ID('tb') IS NOT NULL 
DROP TABLE tb 

CREATE TABLE tb (id INT , pid INT , name NVARCHAR(10)) 
INSERT tb SELECT 1 , 0 , N'食品'
UNION ALL SELECT 2 , 1 , N'水果'
UNION ALL SELECT 3 , 1 , N'蔬菜'
UNION ALL SELECT 4 , 2 , N'香蕉'
UNION ALL SELECT 5 , 2 , N'苹果'
UNION ALL SELECT 6 , 3 , N'青菜'

UNION ALL SELECT 11 ,  0 , N'食品2'
UNION ALL SELECT 12 , 11 , N'水果2'
UNION ALL SELECT 13 , 11 , N'蔬菜2'
UNION ALL SELECT 14 , 12 , N'香蕉2'
UNION ALL SELECT 15 , 12 , N'苹果2'
UNION ALL SELECT 16 , 13 , N'青菜2'
go

--查询各节点的父路径函数
CREATE FUNCTION f_pid (@id INT)
RETURNS VARCHAR(100)
AS 
BEGIN
    DECLARE @re_str AS VARCHAR(50)
    SET @re_str = ''
    SELECT  @re_str = name FROM tb WHERE id = @id
    WHILE EXISTS ( SELECT 1 FROM tb WHERE id = @id AND pid <> 0 ) 
        BEGIN
            SELECT  @id = b.id,@re_str = b.name + ',' + @re_str
            FROM    tb a , tb b
            WHERE   a.id = @id AND a.pid = b.id
        END
    RETURN @re_str
END
go

SELECT  *,dbo.f_pid(id) 路径 FROM tb ORDER BY id

DROP TABLE tb
DROP FUNCTION f_pid

--------------------------------------------------------------------------







--------------------------------------------------------------------------

/*
标题：查询所有节点及其所有子节点的函数
作者：爱新觉罗·毓华(十八年风雨,守得冰山雪莲花开) 
时间：2009-04-12
地点：广东深圳
*/
--------------------------------------------------------------------------
--生成测试数据 

IF OBJECT_ID('tb') IS NOT NULL 
DROP TABLE tb 

create table tb(id varchar(10),pid varchar(10)) 
insert into tb select 'a', null 
insert into tb select 'b', 'a' 
insert into tb select 'c', 'a' 
insert into tb select 'd', 'b' 
insert into tb select 'e', 'b' 
insert into tb select 'f', 'c' 
insert into tb select 'g', 'c' 
go 

--创建用户定义函数 
create function f_getchild(@id varchar(10))
returns varchar(8000) 
as 
begin 
  declare @i int , @ret varchar(8000) 
  declare @t table(id varchar(10) , pid varchar(10) , level int) 
  set @i = 1 
  insert into @t select id , pid , @i from tb where id = @id 
  while @@rowcount <> 0 
  begin 
    set @i = @i + 1 
    insert into @t select a.id , a.pid , @i from tb a , @t b where a.pid = b.id and b.level = @i - 1
  end 
  select @ret = isnull(@ret , '') + id + ',' from @t 
  return left(@ret , len(@ret) - 1)
end 
go 

--执行查询 
select id , children = isnull(dbo.f_getchild(id) , '') from tb group by id
go 

--删除测试数据 
drop function f_getchild 
drop table tb
--------------------------------------------------------------------------
--输出结果 
/* 
id         children     
---------- -------------
a          a,b,c,d,e,f,g
b          b,d,e
c          c,f,g
d          d
e          e
f          f
g          g

（所影响的行数为 7 行）

*/ 

--------------------------------------------------------------------------







--------------------------------------------------------------------------
-- Author  :fredrickhu(小F，向高手学习)
-- Date    :2010-04-28 14:49:57
-- Version:
--      Microsoft SQL Server 2005 - 9.00.4035.00 (Intel X86) 
--    Nov 24 2008 13:01:59 
--    Copyright (c) 1988-2005 Microsoft Corporation
--    Developer Edition on Windows NT 5.1 (Build 2600: Service Pack 3)
--
--------------------------------------------------------------------------
IF OBJECT_ID('tb') IS NOT NULL 
DROP TABLE tb 

create table [tb]([col1] nvarchar(4),[col2] nvarchar(11))
INSERT tb SELECT N'食品','01'
UNION ALL SELECT N'蔬菜','01.01'
UNION ALL SELECT N'萝卜','01.01.01'
UNION ALL SELECT N'白菜','01.01.02'


UNION ALL SELECT N'水果','02'
UNION ALL SELECT N'香蕉','02.01'
UNION ALL SELECT N'苹果','02.02' 

--------------开始查询--------------------------
;with cte as
(
  select *,px=cast(col1 as varchar(50))  from tb where col2 NOT LIKE '%.%'
  union all
  select a.*,cast(b.px+'->'+ a.col1 as varchar(50)) from tb a , cte b where left(a.col2,len(a.col2)-3) = b.col2 and len(a.col2)>4
)
select * from cte 


--------------------------------------------------------------------------
--  Author : htl258(Tony)
--  Date   : 2010-04-28 14:58:10
--  Version:Microsoft SQL Server 2008 (RTM) - 10.0.1600.22 (Intel X86) 
--          Jul  9 2008 14:43:34 
--          Copyright (c) 1988-2008 Microsoft Corporation
--          Developer Edition on Windows NT 5.1 <X86> (Build 2600: Service Pack 3)
--  Blog   : http://blog.csdn.net/htl258
--------------------------------------------------------------------------


IF NOT OBJECT_ID('[tb]') IS NULL
    DROP TABLE [tb]
GO
CREATE TABLE [tb]([字段1] NVARCHAR(10),[字段2] NVARCHAR(20))
INSERT tb SELECT '一级','01'
UNION ALL SELECT N'二级','01.01'
UNION ALL SELECT N'三级','01.01.01'
UNION ALL SELECT N'四级','01.01.01.01'
UNION ALL SELECT N'四级','01.01.01.02'
UNION ALL SELECT N'四级','01.01.01.03'
UNION ALL SELECT N'一级2','02'
UNION ALL SELECT N'二级2','02.01'
UNION ALL SELECT N'三级2','02.01.01' 

GO
--SELECT * FROM [tb]

-->SQL查询如下:
;with t as
(
    select *,path=cast([字段1] as varchar(1000)) from tb a
    where not exists(
        select 1 from tb 
        where a.字段2 like 字段2+'%' 
            and LEN(a.字段2)>LEN(字段2))
    union all
    select a.*,CAST(path+'-->'+a.字段1 as varchar(1000))
    from tb a 
        join t b 
            on a.字段2 like b.字段2+'%' 
            and LEN(a.字段2)-3=LEN(b.字段2)
)
select * from t order by left(字段2,2)
/*
字段1    字段2    path
一级    01    一级
二级    01.01    一级-->二级
三级    01.01.01    一级-->二级-->三级
四级    01.01.01.01    一级-->二级-->三级-->四级
四级    01.01.01.02    一级-->二级-->三级-->四级
四级    01.01.01.03    一级-->二级-->三级-->四级
一级    02    一级
二级    02.01    一级-->二级
三级    02.01.01    一级-->二级-->三级
*/





-----------------------------------------------------
if object_id('[tb]') is not null drop table [tb]
go 
create table [tb](col1 varchar(4),col2 varchar(11))
INSERT tb SELECT '一级','01'
UNION ALL SELECT N'二级','01.01'
UNION ALL SELECT N'三级','01.01.01'
UNION ALL SELECT N'四级','01.01.01.01'
UNION ALL SELECT N'四级','01.01.01.02'
UNION ALL SELECT N'四级','01.01.01.03'
UNION ALL SELECT N'一级','02'
UNION ALL SELECT N'二级','02.01'
UNION ALL SELECT N'三级','02.01.01' 
go

select t.* ,
replace(stuff((select ','+col1 from tb where 
charindex('.'+col2+'.','.'+t.col2+'.') > 0 for xml path('')),1,1,''),',','->') as item
from tb t