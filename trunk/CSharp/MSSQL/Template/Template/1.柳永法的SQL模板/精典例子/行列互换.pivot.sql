-----------------------------------------------------------------------------
http://www.ourcs.net/Article-89.aspx
http://blog.sina.com.cn/s/blog_4c142e330100dlma.html
http://topic.csdn.net/u/20090605/15/D77664A0-A728-475A-A87A-761358BFEA26.html
http://topic.csdn.net/u/20100312/00/9CF39500-8210-4E0A-AB97-FC3C4189A5FC.html good


------------------------------------------------------------------------------



/*
标题：普通行列转换(version 2.0)
作者：爱新觉罗.毓华(十八年风雨,守得冰山雪莲花开)
时间：2008-03-09
地点：广东深圳
说明：普通行列转换(version 1.0)仅针对sql server 2000提供静态和动态写法，version 2.0增加sql server 2005的有关写法。

问题：假设有张学生成绩表(tb)如下:
姓名 课程 分数
张三 语文 74
张三 数学 83
张三 物理 93
李四 语文 74
李四 数学 84
李四 物理 94
想变成(得到如下结果)： 
姓名 语文 数学 物理 
---- ---- ---- ----
李四 74   84   94
张三 74   83   93
-------------------
*/
drop table tb
create table tb(姓名 varchar(10) , 课程 varchar(10) , 分数 int)
insert into tb values('张三' , '语文' , 74)
insert into tb values('张三' , '数学' , 83)
insert into tb values('张三' , '物理' , 93)
insert into tb values('李四' , '语文' , 74)
insert into tb values('李四' , '数学' , 84)
insert into tb values('李四' , '物理' , 94)
insert into tb values('李四2' , '物理2' , 94)

go

--SQL SERVER 2000 静态SQL,指课程只有语文、数学、物理这三门课程。(以下同)
select 姓名 as 姓名 ,
  max(case 课程 when '语文' then 分数 else 0 end) 语文,
  max(case 课程 when '数学' then 分数 else 0 end) 数学,
  max(case 课程 when '物理' then 分数 else 0 end) 物理
from tb
group by 姓名

--SQL SERVER 2000 动态SQL,指课程不止语文、数学、物理这三门课程。(以下同)
declare @sql varchar(8000)
set @sql = 'select 姓名 '
select @sql = @sql + ' , max(case 课程 when ''' + 课程 + ''' then 分数 else 0 end) [' + 课程 + ']'
from (select distinct 课程 from tb) as a
set @sql = @sql + ' from tb group by 姓名'
print @sql
exec(@sql) 



--SQL SERVER 2005 静态SQL。
select * from (select * from tb) a pivot (sum(分数) for 课程 in (语文,数学,物理)) b

--SQL SERVER 2005 动态SQL。
declare @sql varchar(8000)
select @sql = isnull(@sql + '],[' , '') + 课程 from tb group by 课程
set @sql = '[' + @sql + ']'
exec ('select * from (select * from tb) a pivot (max(分数) for 课程 in (' + @sql + ')) b')

---------------------------------

/*
问题：在上述结果的基础上加平均分，总分，得到如下结果：
姓名 语文 数学 物理 平均分 总分 
---- ---- ---- ---- ------ ----
李四 74   84   94   84.00  252
张三 74   83   93   83.33  250
*/

--SQL SERVER 2000 静态SQL。
select 姓名 姓名,
  max(case 课程 when '语文' then 分数 else 0 end) 语文,
  max(case 课程 when '数学' then 分数 else 0 end) 数学,
  max(case 课程 when '物理' then 分数 else 0 end) 物理,
  cast(avg(分数*1.0) as decimal(18,2)) 平均分,
  sum(分数) 总分
from tb
group by 姓名

--SQL SERVER 2000 动态SQL。
declare @sql varchar(8000)
set @sql = 'select 姓名 '
select @sql = @sql + ' , max(case 课程 when ''' + 课程 + ''' then 分数 else 0 end) [' + 课程 + ']'
from (select distinct 课程 from tb) as a
set @sql = @sql + ' , cast(avg(分数*1.0) as decimal(18,2)) 平均分 , sum(分数) 总分 from tb group by 姓名'
exec(@sql) 

--SQL SERVER 2005 静态SQL。
select m.* , n.平均分 , n.总分 from
(select * from (select * from tb) a pivot (max(分数) for 课程 in (语文,数学,物理)) b) m,
(select 姓名 , cast(avg(分数*1.0) as decimal(18,2)) 平均分 , sum(分数) 总分 from tb group by 姓名) n
where m.姓名 = n.姓名

--SQL SERVER 2005 动态SQL。
declare @sql varchar(8000)
select @sql = isnull(@sql + ',' , '') + 课程 from tb group by 课程
exec ('select m.* , n.平均分 , n.总分 from
(select * from (select * from tb) a pivot (max(分数) for 课程 in (' + @sql + ')) b) m , 
(select 姓名 , cast(avg(分数*1.0) as decimal(18,2)) 平均分 , sum(分数) 总分 from tb group by 姓名) n
where m.姓名 = n.姓名')

drop table tb    

------------------
------------------

/*
问题：如果上述两表互相换一下：即表结构和数据为：
姓名 语文 数学 物理
张三 74　　83　　93
李四 74　　84　　94
想变成(得到如下结果)： 
姓名 课程 分数 
---- ---- ----
李四 语文 74
李四 数学 84
李四 物理 94
张三 语文 74
张三 数学 83
张三 物理 93
--------------
*/

create table tb(姓名 varchar(10) , 语文 int , 数学 int , 物理 int)
insert into tb values('张三',74,83,93)
insert into tb values('李四',74,84,94)
go

--SQL SERVER 2000 静态SQL。
select * from
(
 select 姓名 , 课程 = '语文' , 分数 = 语文 from tb 
 union all
 select 姓名 , 课程 = '数学' , 分数 = 数学 from tb
 union all
 select 姓名 , 课程 = '物理' , 分数 = 物理 from tb
) t
order by 姓名 , case 课程 when '语文' then 1 when '数学' then 2 when '物理' then 3 end

--SQL SERVER 2000 动态SQL。
--调用系统表动态生态。
declare @sql varchar(8000)
select @sql = isnull(@sql + ' union all ' , '' ) + ' select 姓名 , [课程] = ' + quotename(Name , '''') + ' , [分数] = ' + quotename(Name) + ' from tb'
from syscolumns 
where name! = N'姓名' and ID = object_id('tb') --表名tb，不包含列名为姓名的其它列
order by colid asc
exec(@sql + ' order by 姓名 ')

--SQL SERVER 2005 动态SQL。
select 姓名 , 课程 , 分数 from tb unpivot (分数 for 课程 in([语文] , [数学] , [物理])) t

--SQL SERVER 2005 动态SQL，同SQL SERVER 2000 动态SQL。

--------------------
/*
问题：在上述的结果上加个平均分，总分，得到如下结果：
姓名 课程   分数
---- ------ ------
李四 语文   74.00
李四 数学   84.00
李四 物理   94.00
李四 平均分 84.00
李四 总分   252.00
张三 语文   74.00
张三 数学   83.00
张三 物理   93.00
张三 平均分 83.33
张三 总分   250.00
------------------
*/

select * from
(
 select 姓名 as 姓名 , 课程 = '语文' , 分数 = 语文 from tb 
 union all
 select 姓名 as 姓名 , 课程 = '数学' , 分数 = 数学 from tb
 union all
 select 姓名 as 姓名 , 课程 = '物理' , 分数 = 物理 from tb
 union all
 select 姓名 as 姓名 , 课程 = '平均分' , 分数 = cast((语文 + 数学 + 物理)*1.0/3 as decimal(18,2)) from tb
 union all
 select 姓名 as 姓名 , 课程 = '总分' , 分数 = 语文 + 数学 + 物理 from tb
) t
order by 姓名 , case 课程 when '语文' then 1 when '数学' then 2 when '物理' then 3 when '平均分' then 4 when '总分' then 5 end

drop table tb