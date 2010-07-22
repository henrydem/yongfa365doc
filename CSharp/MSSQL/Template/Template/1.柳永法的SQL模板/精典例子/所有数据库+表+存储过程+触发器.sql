
--用查询分析器连接远程服务器,执行下面的语句,可以列出服务器上所有用户数据库+表+存储过程+触发器:   

declare   @sql   varchar(8000)   
declare   @dbname   varchar(250)   

declare   #aa   cursor   for   
select   name   from   master..sysdatabases   where   name   not   in('master','tempdb','model','msdb')   
open   #aa   
fetch   next   from   #aa   into   @dbname   
while   @@fetch_status=0   
begin   
set   @sql='select   re=''数据库名='+@dbname+''''   
+'   union   all   select   ''--表名:'''   
+'   union   all   select   name   from   ['+@dbname+']..sysobjects   where   xtype=''U'''   
+'   union   all   select   ''--存储过程:'''   
+'   union   all   select   name   from   ['+@dbname+']..sysobjects   where   xtype=''P'''   
+'   union   all   select   ''--触发器:'''   
+'   union   all   select   name   from   ['+@dbname+']..sysobjects   where   xtype=''T'''   
print   @sql   
exec(@sql)   
fetch   next   from   #aa   into   @dbname   
end   
close   #aa   
deallocate   #aa  

select   name   from   master.dbo.sysdatabases where  LEN(sid)>1
select   name   from   master.dbo.sysdatabases where dbid>4