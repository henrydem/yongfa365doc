--http://blog.csdn.net/fredrickhu
--http://topic.csdn.net/u/20100424/07/29529d9d-bc54-4877-b198-4426b4d85024.html
--------------------------------------------------------------------------
--  Author : 原著：           改编：htl258(Tony)
--  Date   : 2010-04-24 06:39:55
--  Version:Microsoft SQL Server 2008 (RTM) - 10.0.1600.22 (Intel X86) 
--          Jul  9 2008 14:43:34 
--          Copyright (c) 1988-2008 Microsoft Corporation
--          Developer Edition on Windows NT 5.1 <X86> (Build 2600: Service Pack 3)
--  Blog   : http://blog.csdn.net/htl258
--  Subject: 完善SQL农历转换函数（显示中文格式，加入润月的显示）
--------------------------------------------------------------------------
--注：由于一时找不到原著作者，所以暂未填入。大家有知道的告知一下，谢谢！
--参考此地址的代码：http://dev.csdn.net/article/26/26487.shtm
--创建基础数据表
if object_id('SolarData') is not null
    drop table SolarData
go
create table SolarData  
(  
  yearid int not null,  
  data char(7) not null,  
  dataint int not null  
)   
--插入数据  
insert into   
SolarData select 1900,'0x04bd8',19416 union all select 1901,'0x04ae0',19168  
union all select 1902,'0x0a570',42352 union all select 1903,'0x054d5',21717  
union all select 1904,'0x0d260',53856 union all select 1905,'0x0d950',55632  
union all select 1906,'0x16554',91476 union all select 1907,'0x056a0',22176  
union all select 1908,'0x09ad0',39632 union all select 1909,'0x055d2',21970  
union all select 1910,'0x04ae0',19168 union all select 1911,'0x0a5b6',42422  
union all select 1912,'0x0a4d0',42192 union all select 1913,'0x0d250',53840  
union all select 1914,'0x1d255',119381 union all select 1915,'0x0b540',46400  
union all select 1916,'0x0d6a0',54944 union all select 1917,'0x0ada2',44450  
union all select 1918,'0x095b0',38320 union all select 1919,'0x14977',84343  
union all select 1920,'0x04970',18800 union all select 1921,'0x0a4b0',42160  
union all select 1922,'0x0b4b5',46261 union all select 1923,'0x06a50',27216  
union all select 1924,'0x06d40',27968 union all select 1925,'0x1ab54',109396  
union all select 1926,'0x02b60',11104 union all select 1927,'0x09570',38256  
union all select 1928,'0x052f2',21234 union all select 1929,'0x04970',18800  
union all select 1930,'0x06566',25958 union all select 1931,'0x0d4a0',54432  
union all select 1932,'0x0ea50',59984 union all select 1933,'0x06e95',28309  
union all select 1934,'0x05ad0',23248 union all select 1935,'0x02b60',11104  
union all select 1936,'0x186e3',100067 union all select 1937,'0x092e0',37600  
union all select 1938,'0x1c8d7',116951 union all select 1939,'0x0c950',51536  
union all select 1940,'0x0d4a0',54432 union all select 1941,'0x1d8a6',120998  
union all select 1942,'0x0b550',46416 union all select 1943,'0x056a0',22176  
union all select 1944,'0x1a5b4',107956 union all select 1945,'0x025d0',9680  
union all select 1946,'0x092d0',37584 union all select 1947,'0x0d2b2',53938  
union all select 1948,'0x0a950',43344 union all select 1949,'0x0b557',46423  
union all select 1950,'0x06ca0',27808 union all select 1951,'0x0b550',46416  
union all select 1952,'0x15355',86869 union all select 1953,'0x04da0',19872  
union all select 1954,'0x0a5d0',42448 union all select 1955,'0x14573',83315  
union all select 1956,'0x052d0',21200 union all select 1957,'0x0a9a8',43432  
union all select 1958,'0x0e950',59728 union all select 1959,'0x06aa0',27296  
union all select 1960,'0x0aea6',44710 union all select 1961,'0x0ab50',43856  
union all select 1962,'0x04b60',19296 union all select 1963,'0x0aae4',43748  
union all select 1964,'0x0a570',42352 union all select 1965,'0x05260',21088  
union all select 1966,'0x0f263',62051 union all select 1967,'0x0d950',55632  
union all select 1968,'0x05b57',23383 union all select 1969,'0x056a0',22176  
union all select 1970,'0x096d0',38608 union all select 1971,'0x04dd5',19925  
union all select 1972,'0x04ad0',19152 union all select 1973,'0x0a4d0',42192  
union all select 1974,'0x0d4d4',54484 union all select 1975,'0x0d250',53840  
union all select 1976,'0x0d558',54616 union all select 1977,'0x0b540',46400  
union all select 1978,'0x0b5a0',46496 union all select 1979,'0x195a6',103846  
union all select 1980,'0x095b0',38320 union all select 1981,'0x049b0',18864  
union all select 1982,'0x0a974',43380 union all select 1983,'0x0a4b0',42160  
union all select 1984,'0x0b27a',45690 union all select 1985,'0x06a50',27216  
union all select 1986,'0x06d40',27968 union all select 1987,'0x0af46',44870  
union all select 1988,'0x0ab60',43872 union all select 1989,'0x09570',38256  
union all select 1990,'0x04af5',19189 union all select 1991,'0x04970',18800  
union all select 1992,'0x064b0',25776 union all select 1993,'0x074a3',29859  
union all select 1994,'0x0ea50',59984 union all select 1995,'0x06b58',27480  
union all select 1996,'0x055c0',21952 union all select 1997,'0x0ab60',43872  
union all select 1998,'0x096d5',38613 union all select 1999,'0x092e0',37600  
union all select 2000,'0x0c960',51552 union all select 2001,'0x0d954',55636  
union all select 2002,'0x0d4a0',54432 union all select 2003,'0x0da50',55888  
union all select 2004,'0x07552',30034 union all select 2005,'0x056a0',22176  
union all select 2006,'0x0abb7',43959 union all select 2007,'0x025d0',9680  
union all select 2008,'0x092d0',37584 union all select 2009,'0x0cab5',51893  
union all select 2010,'0x0a950',43344 union all select 2011,'0x0b4a0',46240  
union all select 2012,'0x0baa4',47780 union all select 2013,'0x0ad50',44368  
union all select 2014,'0x055d9',21977 union all select 2015,'0x04ba0',19360  
union all select 2016,'0x0a5b0',42416 union all select 2017,'0x15176',86390  
union all select 2018,'0x052b0',21168 union all select 2019,'0x0a930',43312  
union all select 2020,'0x07954',31060 union all select 2021,'0x06aa0',27296  
union all select 2022,'0x0ad50',44368 union all select 2023,'0x05b52',23378  
union all select 2024,'0x04b60',19296 union all select 2025,'0x0a6e6',42726  
union all select 2026,'0x0a4e0',42208 union all select 2027,'0x0d260',53856  
union all select 2028,'0x0ea65',60005 union all select 2029,'0x0d530',54576  
union all select 2030,'0x05aa0',23200 union all select 2031,'0x076a3',30371  
union all select 2032,'0x096d0',38608 union all select 2033,'0x04bd7',19415  
union all select 2034,'0x04ad0',19152 union all select 2035,'0x0a4d0',42192  
union all select 2036,'0x1d0b6',118966 union all select 2037,'0x0d250',53840  
union all select 2038,'0x0d520',54560 union all select 2039,'0x0dd45',56645  
union all select 2040,'0x0b5a0',46496 union all select 2041,'0x056d0',22224  
union all select 2042,'0x055b2',21938 union all select 2043,'0x049b0',18864  
union all select 2044,'0x0a577',42359 union all select 2045,'0x0a4b0',42160  
union all select 2046,'0x0aa50',43600 union all select 2047,'0x1b255',111189  
union all select 2048,'0x06d20',27936 union all select 2049,'0x0ada0',44448  
GO
--创建农历日期函数  
if object_id('fn_GetLunar') is not null
    drop function fn_GetLunar
go 
create function dbo.fn_GetLunar(@solarday datetime)      
returns nvarchar(30)    
as      
begin      
  declare @soldata int      
  declare @offset int      
  declare @ilunar int      
  declare @i int       
  declare @j int       
  declare @ydays int      
  declare @mdays int      
  declare @mleap int  
  declare @mleap1 int    
  declare @mleapnum int      
  declare @bleap smallint      
  declare @temp int      
  declare @year nvarchar(10)       
  declare @month nvarchar(10)      
  declare @day nvarchar(10)  
  declare @chinesenum nvarchar(10)         
  declare @outputdate nvarchar(30)       
  set @offset=datediff(day,'1900-01-30',@solarday)      
  --确定农历年开始      
  set @i=1900      
  --set @offset=@soldata      
  while @i<2050 and @offset>0      
  begin      
    set @ydays=348      
    set @mleapnum=0      
    select @ilunar=dataint from solardata where yearid=@i      
     
    --传回农历年的总天数      
    set @j=32768      
    while @j>8      
    begin      
      if @ilunar & @j >0      
        set @ydays=@ydays+1      
      set @j=@j/2      
    end      
    --传回农历年闰哪个月 1-12 , 没闰传回 0      
    set @mleap = @ilunar & 15      
    --传回农历年闰月的天数 ,加在年的总天数上      
    if @mleap > 0      
    begin      
      if @ilunar & 65536 > 0      
        set @mleapnum=30      
      else       
        set @mleapnum=29           
      set @ydays=@ydays+@mleapnum      
    end      
    set @offset=@offset-@ydays      
    set @i=@i+1      
  end      
  if @offset <= 0      
  begin      
    set @offset=@offset+@ydays      
    set @i=@i-1      
  end      
  --确定农历年结束        
  set @year=@i      
  --确定农历月开始      
  set @i = 1      
  select @ilunar=dataint from solardata where yearid=@year    
  --判断那个月是润月      
  set @mleap = @ilunar & 15  
  set @bleap = 0     
  while @i < 13 and @offset > 0      
  begin      
    --判断润月      
    set @mdays=0      
    if (@mleap > 0 and @i = (@mleap+1) and @bleap=0)      
    begin--是润月      
      set @i=@i-1      
      set @bleap=1 
      set @mleap1= @mleap              
      --传回农历年闰月的天数      
      if @ilunar & 65536 > 0      
        set @mdays = 30      
      else       
        set @mdays = 29      
    end      
    else      
    --不是润月      
    begin      
      set @j=1      
      set @temp = 65536       
      while @j<=@i      
      begin      
        set @temp=@temp/2      
        set @j=@j+1      
      end      
     
      if @ilunar & @temp > 0      
        set @mdays = 30      
      else      
        set @mdays = 29      
    end      
       
    --解除润月    
    if @bleap=1 and @i= (@mleap+1)    
      set @bleap=0    
   
    set @offset=@offset-@mdays      
    set @i=@i+1      
  end      
     
  if @offset <= 0      
  begin      
    set @offset=@offset+@mdays      
    set @i=@i-1      
  end      
   
  --确定农历月结束        
  set @month=@i    
     
  --确定农历日结束        
  set @day=ltrim(@offset) 
  --输出日期
  set @chinesenum=N'〇一二三四五六七八九十'   
  while len(@year)>0
  select @outputdate=isnull(@outputdate,'')
         + substring(@chinesenum,left(@year,1)+1,1)
         , @year=stuff(@year,1,1,'')
  set @outputdate=@outputdate+N'年'
         + case @mleap1 when @month then N'润' else '' end
  if cast(@month as int)<10
    set @outputdate=@outputdate 
         + case @month when 1 then N'正'
             else substring(@chinesenum,left(@month,1)+1,1) 
           end
  else if cast(@month as int)>=10
    set @outputdate=@outputdate
         + case @month when '10' then N'十' when 11 then N'十一' 
           else N'十二' end 
  set @outputdate=@outputdate + N'月'
  if cast(@day as int)<10
    set @outputdate=@outputdate + N'初'
         + substring(@chinesenum,left(@day,1)+1,1)
  else if @day between '10' and '19'
    set @outputdate=@outputdate
         + case @day when '10' then N'初十' else N'十'+
           substring(@chinesenum,right(@day,1)+1,1) end
  else if @day between '20' and '29'
    set @outputdate=@outputdate
         + case @day when '20' then N'二十' else N'廿' end
         + case @day when '20' then N'' else 
           substring(@chinesenum,right(@day,1)+1,1) end
  else 
    set @outputdate=@outputdate+N'三十'
  return @outputdate
end
GO 
select dbo.fn_GetLunar(getdate()) as [改编日期(农历)],    getdate() as [改编日期(公历)]
